using System;
using UGF.RuntimeTools.Runtime.Containers;

namespace UGF.UI.Runtime.Layout
{
    public abstract class LayoutGroupVirtualScrollConstructor : ILayoutGroupVirtualScrollConstructor
    {
        public ContainerComponent Create(int index)
        {
            if (index < 0) throw new ArgumentOutOfRangeException(nameof(index));

            return OnCreate(index);
        }

        public void Delete(int index, ContainerComponent component)
        {
            if (index < 0) throw new ArgumentOutOfRangeException(nameof(index));
            if (component == null) throw new ArgumentNullException(nameof(component));

            OnDelete(index, component);
        }

        protected abstract ContainerComponent OnCreate(int index);
        protected abstract void OnDelete(int index, ContainerComponent component);
    }
}
