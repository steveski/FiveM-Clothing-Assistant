namespace FiveMClothingAssistant
{
    using GongSolutions.Wpf.DragDrop;
    using System.Collections.ObjectModel;

    public class ListBoxViewModel<TItemVm> : IDropTarget
        where TItemVm : class, IDropTargetItemViewModel<TItemVm>
    {
        public ObservableCollection<TItemVm> Items { get; set; } = new ObservableCollection<TItemVm>();

        public void DragOver(IDropInfo dropInfo)
        {
            var sourceItem = dropInfo.Data as TItemVm;
            var targetItem = dropInfo.TargetItem as TItemVm;

            if (sourceItem != null && targetItem != null && targetItem.CanAcceptChildren)
            {
                dropInfo.DropTargetAdorner = DropTargetAdorners.Highlight;
                dropInfo.Effects = System.Windows.DragDropEffects.Copy;
            }

        }

        public void Drop(IDropInfo dropInfo)
        {
            var sourceItem = dropInfo.Data as TItemVm;
            var targetItem = dropInfo.TargetItem as TItemVm;

            targetItem?.Children.Add(sourceItem);

        }

    }

}
