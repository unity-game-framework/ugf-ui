using System.Collections.Generic;
using UnityEngine;

namespace UGF.UI.Runtime.Layout
{
    [AddComponentMenu("Unity Game Framework/UI/Layout Group", 2000)]
    public class LayoutGroupComponent : LayoutCollectionComponent
    {
        [SerializeField] private RectTransform m_root;
        [SerializeField] private LayoutSettings m_settings;
        [SerializeField] private bool m_parentRelativeAlignment;
        [SerializeField] private bool m_ignoreInactive = true;
        [SerializeField] private bool m_ignoreZeroLength = true;
        [SerializeField] private List<RectTransform> m_ignore = new List<RectTransform>();

        public RectTransform Root { get { return m_root; } set { m_root = value; } }
        public LayoutSettings Settings { get { return m_settings; } set { m_settings = value; } }
        public bool ParentRelativeAlignment { get { return m_parentRelativeAlignment; } set { m_parentRelativeAlignment = value; } }
        public bool IgnoreInactive { get { return m_ignoreInactive; } set { m_ignoreInactive = value; } }
        public bool IgnoreZeroLength { get { return m_ignoreZeroLength; } set { m_ignoreZeroLength = value; } }
        public List<RectTransform> Ignore { get { return m_ignore; } }

        private List<RectTransform> m_childrenTransforms;
        private List<Rect> m_children;

        protected override void OnCalculate()
        {
            base.OnCalculate();

            CollectChildren();
            CalculateSize();
            CalculatePositions();
            UpdateChildren();
        }

        public void CalculateSize()
        {
            LayoutGroupUtility.CalculateSize(m_root, m_children, m_settings);

            if (m_parentRelativeAlignment && m_root.parent is RectTransform parent)
            {
                LayoutGroupUtility.AlignInParent(m_root, parent, m_settings.Direction, m_settings.Reverse);
            }
        }

        public void CalculatePositions()
        {
            LayoutGroupUtility.CalculatePositions(m_root, m_children, m_settings);
        }

        private void UpdateChildren()
        {
            for (int i = 0; i < m_childrenTransforms.Count; i++)
            {
                RectTransform rectTransform = m_childrenTransforms[i];
                Rect rect = m_children[i];

                rectTransform.anchoredPosition = rect.position;
            }
        }

        private void CollectChildren()
        {
            int axisIndex = LayoutGroupUtility.GetAxisAlongIndex(m_settings.Direction);

            m_childrenTransforms ??= new List<RectTransform>(m_root.childCount);
            m_childrenTransforms.Clear();

            for (int i = 0; i < m_root.childCount; i++)
            {
                if (m_root.GetChild(i) is RectTransform child && IsChildValid(child, axisIndex))
                {
                    m_childrenTransforms.Add(child);
                }
            }

            m_children ??= new List<Rect>(m_childrenTransforms.Count);
            m_children.Clear();

            for (int i = 0; i < m_childrenTransforms.Count; i++)
            {
                RectTransform rectTransform = m_childrenTransforms[i];
                Rect rect = rectTransform.rect;

                m_children.Add(rect);
            }
        }

        private bool IsChildValid(RectTransform rectTransform, int axisIndex)
        {
            return (!m_ignoreInactive || rectTransform.gameObject.activeSelf)
                   && (!m_ignoreZeroLength || rectTransform.rect.size[axisIndex] > 0F)
                   && !m_ignore.Contains(rectTransform);
        }
    }
}
