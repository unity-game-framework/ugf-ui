using System.Collections.Generic;
using UnityEngine;

namespace UGF.UI.Runtime.Layout
{
    [AddComponentMenu("Unity Game Framework/UI/Layout Collection", 2000)]
    public class LayoutCollectionComponent : LayoutComponent
    {
        [SerializeField] private List<LayoutComponent> m_layouts = new List<LayoutComponent>();

        public List<LayoutComponent> Layouts { get { return m_layouts; } }

        protected override void OnCalculate()
        {
            for (int i = 0; i < m_layouts.Count; i++)
            {
                LayoutComponent layout = m_layouts[i];

                layout.Calculate();
            }
        }
    }
}
