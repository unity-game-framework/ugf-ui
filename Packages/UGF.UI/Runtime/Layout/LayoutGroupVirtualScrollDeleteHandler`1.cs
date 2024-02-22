using UGF.RuntimeTools.Runtime.Containers;

namespace UGF.UI.Runtime.Layout
{
    public delegate void LayoutGroupVirtualScrollDeleteHandler<in TArguments>(int index, ContainerComponent container, TArguments arguments);
}
