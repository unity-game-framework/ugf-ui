using System;
using System.Collections.Generic;
using UGF.RuntimeTools.Runtime.Containers;
using UnityEngine;
using UnityEngine.UI;

namespace UGF.UI.Runtime.Layout
{
    [AddComponentMenu("Unity Game Framework/UI/Layout Group Virtual Scroll", 2000)]
    public class LayoutGroupVirtualScrollComponent : MonoBehaviour
    {
        [SerializeField] private ScrollRect m_scroll;
        [SerializeField] private LayoutGroupVirtualComponent m_layout;
        [SerializeField] private Vector4 m_viewportPadding;
        [SerializeField] private Vector2 m_entryDefaultSize = Vector2.one * 100F;

        public ScrollRect Scroll { get { return m_scroll; } set { m_scroll = value; } }
        public LayoutGroupVirtualComponent Layout { get { return m_layout; } set { m_layout = value; } }
        public Vector4 ViewportPadding { get { return m_viewportPadding; } set { m_viewportPadding = value; } }
        public Vector2 EntryDefaultSize { get { return m_entryDefaultSize; } set { m_entryDefaultSize = value; } }
        public Dictionary<Rect, ContainerComponent> Containers { get; } = new Dictionary<Rect, ContainerComponent>();
        public bool HasHandlers { get { return m_createHandler != null && m_deleteHandler != null; } }

        private LayoutGroupVirtualScrollCreateHandler m_createHandler;
        private LayoutGroupVirtualScrollDeleteHandler m_deleteHandler;

        private void Awake()
        {
            m_scroll.onValueChanged.AddListener(OnChanged);
        }

        private void OnDestroy()
        {
            m_scroll.onValueChanged.RemoveListener(OnChanged);
        }

        public void AddEntryDefault(int count)
        {
            if (count <= 0) throw new ArgumentOutOfRangeException(nameof(count));

            for (int i = 0; i < count; i++)
            {
                AddEntryDefault();
            }
        }

        public void AddEntryDefault(float height)
        {
            if (height <= 0F) throw new ArgumentOutOfRangeException(nameof(height));

            m_layout.Children.Add(new Rect(0F, 0F, m_entryDefaultSize.x, height));
        }

        public void AddEntryDefault()
        {
            m_layout.Children.Add(new Rect(Vector2.zero, m_entryDefaultSize));
        }

        public void DeleteAll()
        {
            if (!HasHandlers) throw new InvalidOperationException("No handlers specified.");

            for (int i = 0; i < m_layout.Children.Count; i++)
            {
                Rect rect = m_layout.Children[i];

                if (Containers.Remove(rect, out ContainerComponent container))
                {
                    m_deleteHandler.Invoke(i, container);
                }
            }

            m_layout.Children.Clear();

            Containers.Clear();
        }

        public void SetHandlers(LayoutGroupVirtualScrollCreateHandler createHandler, LayoutGroupVirtualScrollDeleteHandler deleteHandler)
        {
            m_createHandler = createHandler ?? throw new ArgumentNullException(nameof(createHandler));
            m_deleteHandler = deleteHandler ?? throw new ArgumentNullException(nameof(deleteHandler));
        }

        public void ClearHandlers()
        {
            m_createHandler = default;
            m_deleteHandler = default;
        }

        public void Clear()
        {
            DeleteAll();
            ClearHandlers();
        }

        public void Calculate()
        {
            if (!HasHandlers) throw new InvalidOperationException("No handlers specified.");

            Rect viewportRect = m_scroll.viewport.rect;

            viewportRect.xMin += m_viewportPadding.x;
            viewportRect.xMax -= m_viewportPadding.y;
            viewportRect.yMin += m_viewportPadding.w;
            viewportRect.yMax -= m_viewportPadding.z;

            Rect viewportRectWorld = UIUtility.GetWorldRect(viewportRect, m_scroll.viewport);

            for (int i = 0; i < m_layout.Children.Count; i++)
            {
                Rect rect = m_layout.Children[i];
                Rect rectWorld = UIUtility.GetWorldRect(rect, m_scroll.content);

                rectWorld.position -= rectWorld.size * 0.5F;

                if (viewportRectWorld.Overlaps(rectWorld))
                {
                    if (!Containers.ContainsKey(rect))
                    {
                        ContainerComponent container = m_createHandler.Invoke(i);

                        Containers.Add(rect, container);

                        if (container.transform is RectTransform rectTransform)
                        {
                            rectTransform.localPosition = rect.position;
                        }
                    }
                }
                else if (Containers.Remove(rect, out ContainerComponent container))
                {
                    m_deleteHandler.Invoke(i, container);
                }
            }
        }

        private void OnChanged(Vector2 position)
        {
            if (HasHandlers)
            {
                Calculate();
            }
        }
    }
}
