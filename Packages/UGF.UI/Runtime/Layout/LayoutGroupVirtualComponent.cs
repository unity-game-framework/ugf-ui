using System.Collections.Generic;
using UnityEngine;

namespace UGF.UI.Runtime.Layout
{
    [AddComponentMenu("Unity Game Framework/UI/Layout Group Virtual", 2000)]
    public class LayoutGroupVirtualComponent : LayoutComponent
    {
        [SerializeField] private RectTransform m_root;
        [SerializeField] private LayoutSettings m_settings;
        [SerializeField] private bool m_parentRelativeAlignment;

        public RectTransform Root { get { return m_root; } set { m_root = value; } }
        public LayoutSettings Settings { get { return m_settings; } set { m_settings = value; } }
        public bool ParentRelativeAlignment { get { return m_parentRelativeAlignment; } set { m_parentRelativeAlignment = value; } }
        public List<Rect> Children { get; } = new List<Rect>();

        protected override void OnCalculate()
        {
            CalculateSize();
            CalculatePositions();
        }

        public void CalculateSize()
        {
            LayoutGroupUtility.CalculateSize(m_root, Children, m_settings);

            if (m_parentRelativeAlignment && m_root.parent is RectTransform parent)
            {
                LayoutGroupUtility.AlignInParent(m_root, parent, m_settings.Direction, m_settings.Reverse);
            }
        }

        public void CalculatePositions()
        {
            LayoutGroupUtility.CalculatePositions(m_root, Children, m_settings);
        }
    }
}
