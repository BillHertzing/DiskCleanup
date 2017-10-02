namespace DiskCleanup.ViewModels
{
    using DiskCleanup.Interfaces;
    using System.Collections.Generic;

    internal class SortableObservableDictionaryCollection : SortableObservableCollection<IFSItemViewModel>
    {
        Dictionary<string, IFSItemViewModel> _dictionary = null;

        public SortableObservableDictionaryCollection()
        {
            _dictionary = new Dictionary<string, IFSItemViewModel>();
        }

        public bool AddItem(IFSItemViewModel item)
        {
            _dictionary.Add(item.Name, item);
            this.Add(item);

            return true;
        }

        public bool RemoveItem(IFSItemViewModel item)
        {
            _dictionary.Remove(item.Name);
            this.Remove(item);

            return true;
        }

        public IFSItemViewModel TryGet(string key)
        {
            IFSItemViewModel o;

            if (_dictionary.TryGetValue(key, out o))
                return o;

            return null;
        }

        public void RenameItem(IFSItemViewModel item, string newName)
        {
            _dictionary.Remove(item.Name);
            item.Name = newName;
            _dictionary.Add(newName, item);
        }
    }
}
