using UnityEngine;

namespace UGF.UI.Runtime.Layout
{
    [AddComponentMenu("Unity Game Framework/UI/Layout Fit In Parent", 2000)]
    public class LayoutFitInParentComponent : LayoutComponent
    {
        [SerializeField] private RectTransform m_root;
        [SerializeField] private bool m_autoAspectRatio;
        [SerializeField] private float m_aspectRatio;

        public RectTransform Root { get { return m_root; } set { m_root = value; } }
        public bool AutoAspectRatio { get { return m_autoAspectRatio; } set { m_autoAspectRatio = value; } }
        public float AspectRatio { get { return m_aspectRatio; } set { m_aspectRatio = value; } }

        protected override void OnCalculate()
        {
            if (m_autoAspectRatio)
            {
                LayoutRectTransformUtility.FitInParent(m_root);
            }
            else
            {
                LayoutRectTransformUtility.FitInParent(m_root, m_aspectRatio);
            }
        }
    }
}
