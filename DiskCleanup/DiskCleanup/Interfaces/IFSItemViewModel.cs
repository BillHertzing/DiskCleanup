namespace DiskCleanup.Interfaces
{
    using DiskCleanup.ViewModels;
    internal interface IFSItemViewModel
    {
        SortableObservableDictionaryCollection Children { get; }
        bool IsItemExpanded { get; set; }
        bool IsItemSelected { get; set; }

        string Name { get; set; }

        IFSItemViewModel Parent { get; }

        void AddChildItem(IFSItemViewModel item);
        object Clone();
    }
}
