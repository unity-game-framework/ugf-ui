using UGF.RuntimeTools.Runtime.Containers;

namespace UGF.UI.Runtime.Layout
{
    public interface ILayoutGroupVirtualScrollConstructor
    {
        ContainerComponent Create(int index);
        void Delete(int index, ContainerComponent component);
    }
}
