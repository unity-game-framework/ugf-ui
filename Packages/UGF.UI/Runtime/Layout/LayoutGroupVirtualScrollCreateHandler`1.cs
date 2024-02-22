using UGF.RuntimeTools.Runtime.Containers;

namespace UGF.UI.Runtime.Layout
{
    public delegate ContainerComponent LayoutGroupVirtualScrollCreateHandler<in TArguments>(int index, TArguments arguments);
}
