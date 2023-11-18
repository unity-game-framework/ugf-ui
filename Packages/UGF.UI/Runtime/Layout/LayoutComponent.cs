using UnityEngine;

namespace UGF.UI.Runtime.Layout
{
    public abstract class LayoutComponent : MonoBehaviour
    {
        public void Calculate()
        {
            OnCalculate();
        }

        protected abstract void OnCalculate();
    }
}
