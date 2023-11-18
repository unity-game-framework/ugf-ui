using System;
using UnityEngine;

namespace UGF.UI.Runtime.Layout
{
    [Serializable]
    public struct LayoutSettings
    {
        [SerializeField] private LayoutDirection m_direction;
        [SerializeField] private LayoutDirectionAlignment m_alignment;
        [SerializeField] private bool m_reverse;
        [SerializeField] private float m_spacing;
        [SerializeField] private float m_paddingStart;
        [SerializeField] private float m_paddingEnd;
        [SerializeField] private bool m_adjustSizeAlongDirection;
        [SerializeField] private bool m_useMinSizeAlongDirection;
        [SerializeField] private float m_minSizeAlongDirection;
        [SerializeField] private bool m_useMaxSizeAlongDirection;
        [SerializeField] private float m_maxSizeAlongDirection;
        [SerializeField] private bool m_adjustSizeCrossDirection;

        public LayoutDirection Direction { get { return m_direction; } set { m_direction = value; } }
        public LayoutDirectionAlignment Alignment { get { return m_alignment; } set { m_alignment = value; } }
        public bool Reverse { get { return m_reverse; } set { m_reverse = value; } }
        public float Spacing { get { return m_spacing; } set { m_spacing = value; } }
        public float PaddingStart { get { return m_paddingStart; } set { m_paddingStart = value; } }
        public float PaddingEnd { get { return m_paddingEnd; } set { m_paddingEnd = value; } }
        public bool AdjustSizeAlongDirection { get { return m_adjustSizeAlongDirection; } set { m_adjustSizeAlongDirection = value; } }
        public bool UseMinSizeAlongDirection { get { return m_useMinSizeAlongDirection; } set { m_useMinSizeAlongDirection = value; } }
        public float MinSizeAlongDirection { get { return m_minSizeAlongDirection; } set { m_minSizeAlongDirection = value; } }
        public bool UseMaxSizeAlongDirection { get { return m_useMaxSizeAlongDirection; } set { m_useMaxSizeAlongDirection = value; } }
        public float MaxSizeAlongDirection { get { return m_maxSizeAlongDirection; } set { m_maxSizeAlongDirection = value; } }
        public bool AdjustSizeCrossDirection { get { return m_adjustSizeCrossDirection; } set { m_adjustSizeCrossDirection = value; } }
    }
}
