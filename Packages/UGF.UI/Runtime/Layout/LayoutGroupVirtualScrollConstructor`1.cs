using System;

namespace UGF.UI.Runtime.Layout
{
    public abstract class LayoutGroupVirtualScrollConstructor<TArguments> : LayoutGroupVirtualScrollConstructor
    {
        public TArguments Arguments { get { return HasArguments ? m_arguments : throw new ArgumentException("Value not specified."); } }
        public bool HasArguments { get; private set; }

        private TArguments m_arguments;

        public void SetArguments(TArguments arguments)
        {
            m_arguments = arguments;

            HasArguments = true;
        }

        public void ClearArguments()
        {
            m_arguments = default;

            HasArguments = false;
        }
    }
}
