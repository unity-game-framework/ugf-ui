using System;
using UGF.RuntimeTools.Runtime.Containers;

namespace UGF.UI.Runtime.Layout
{
    public class LayoutGroupVirtualScrollConstructorHandlers : LayoutGroupVirtualScrollConstructor
    {
        public LayoutGroupVirtualScrollCreateHandler CreateHandler { get; }
        public LayoutGroupVirtualScrollDeleteHandler DeleteHandler { get; }

        public LayoutGroupVirtualScrollConstructorHandlers(LayoutGroupVirtualScrollCreateHandler createHandler, LayoutGroupVirtualScrollDeleteHandler deleteHandler)
        {
            CreateHandler = createHandler ?? throw new ArgumentNullException(nameof(createHandler));
            DeleteHandler = deleteHandler ?? throw new ArgumentNullException(nameof(deleteHandler));
        }

        protected override ContainerComponent OnCreate(int index)
        {
            return CreateHandler.Invoke(index);
        }

        protected override void OnDelete(int index, ContainerComponent component)
        {
            DeleteHandler.Invoke(index, component);
        }
    }
}
