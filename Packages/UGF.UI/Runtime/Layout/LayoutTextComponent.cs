using TMPro;
using UnityEngine;

namespace UGF.UI.Runtime.Layout
{
    [AddComponentMenu("Unity Game Framework/UI/Layout Text", 2000)]
    public class LayoutTextComponent : LayoutComponent
    {
        [SerializeField] private RectTransform m_root;
        [SerializeField] private TextMeshProUGUI m_text;
        [SerializeField] private bool m_width;
        [SerializeField] private bool m_height;

        public RectTransform Root { get { return m_root; } set { m_root = value; } }
        public TextMeshProUGUI Text { get { return m_text; } set { m_text = value; } }
        public bool Width { get { return m_width; } set { m_width = value; } }
        public bool Height { get { return m_height; } set { m_height = value; } }

        protected override void OnCalculate()
        {
            if (m_width)
            {
                m_root.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, m_text.preferredWidth);
            }

            if (m_height)
            {
                m_root.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, m_text.preferredHeight);
            }
        }
    }
}
