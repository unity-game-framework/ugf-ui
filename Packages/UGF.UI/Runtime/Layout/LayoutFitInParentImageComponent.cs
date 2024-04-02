using UnityEngine;
using UnityEngine.UI;

namespace UGF.UI.Runtime.Layout
{
    [AddComponentMenu("Unity Game Framework/UI/Layout Fit In Parent Image", 2000)]
    public class LayoutFitInParentImageComponent : LayoutComponent
    {
        [SerializeField] private RectTransform m_root;
        [SerializeField] private Image m_image;

        public RectTransform Root { get { return m_root; } set { m_root = value; } }
        public Image Image { get { return m_image; } set { m_image = value; } }

        protected override void OnCalculate()
        {
            LayoutRectTransformUtility.SetSizeFromImage(m_root, m_image);
            LayoutRectTransformUtility.FitInParent(m_root);
        }
    }
}
