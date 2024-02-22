using System;
using UGF.RuntimeTools.Runtime.Containers;

namespace UGF.UI.Runtime.Layout
{
    public class LayoutGroupVirtualScrollConstructorHandlers<TArguments> : LayoutGroupVirtualScrollConstructor<TArguments>
    {
        public LayoutGroupVirtualScrollCreateHandler<TArguments> CreateHandler { get; }
        public LayoutGroupVirtualScrollDeleteHandler<TArguments> DeleteHandler { get; }

        public LayoutGroupVirtualScrollConstructorHandlers(TArguments arguments, LayoutGroupVirtualScrollCreateHandler<TArguments> createHandler, LayoutGroupVirtualScrollDeleteHandler<TArguments> deleteHandler) : this(createHandler, deleteHandler)
        {
            SetArguments(arguments);
        }

        public LayoutGroupVirtualScrollConstructorHandlers(LayoutGroupVirtualScrollCreateHandler<TArguments> createHandler, LayoutGroupVirtualScrollDeleteHandler<TArguments> deleteHandler)
        {
            CreateHandler = createHandler ?? throw new ArgumentNullException(nameof(createHandler));
            DeleteHandler = deleteHandler ?? throw new ArgumentNullException(nameof(deleteHandler));
        }

        protected override ContainerComponent OnCreate(int index)
        {
            return CreateHandler.Invoke(index, Arguments);
        }

        protected override void OnDelete(int index, ContainerComponent component)
        {
            DeleteHandler.Invoke(index, component, Arguments);
        }
    }
}
