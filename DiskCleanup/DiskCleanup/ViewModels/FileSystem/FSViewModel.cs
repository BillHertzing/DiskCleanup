namespace DiskCleanup.ViewModels

{
    using DiskCleanup.Interfaces;
    using DiskCleanup.ViewModels.Base;
    using System.Collections.ObjectModel;
    using System.Threading;
    using System.Threading.Tasks;
    using System.Windows.Input;

    /// <summary>
    /// Implements a FileSystem tree viewmodel that manages the rootitem
    /// and provides base functions for the items stored in the tree.
    /// </summary>
    internal class FSViewModel : ViewModels.Base.BaseViewModel
    {
        #region fields
        private string _Name = string.Empty;

        private readonly ObservableCollection<IFSItemViewModel> _Root = null;
        private IFSItemViewModel _rootItem = null;

        private IFSItemViewModel _SelectedItem = null;
        private ICommand _SelectedFolderChangedCommand;
        private RelayCommand<object> _RenameSelectedItemCommand;
        #endregion fields

        #region constructors
        /// <summary>
        /// Class constructor
        /// </summary>
        /// <param name="name"></param>
        public FSViewModel()
        {
            _Root = new ObservableCollection<IFSItemViewModel>();
        }
        #endregion constructors

        #region properties
        /// <summary>
        /// Gets the root of this tree collection.
        /// </summary>
        public ObservableCollection<IFSItemViewModel> Root
        {
            get
            {
                return _Root;
            }
        }

        /// <summary>
        /// Gets a copy of the currently selected item in the treeview.
        /// This copy is used to edit the item and make editing cancelable.
        /// 
        /// -> User has to execute am explizit command (eg. Rename)
        ///    to manipulate the actual items in the tree.
        /// </summary>
        public IFSItemViewModel SelectedItem
        {
            get
            {
                return _SelectedItem;
            }

            private set
            {
                if (_SelectedItem != value)
                {
                    _SelectedItem = value;
                    NotifyPropertyChanged(() => SelectedItem);
                }
            }
        }

        /// <summary>
        /// Gets/sets a private non-bindable item
        /// that is currently selected in the treeview.
        /// 
        /// This item is only used if the actual items in the treeview
        /// are supposed to be manipulated.
        /// </summary>
        private IFSItemViewModel CurrentlySelectedItem { get; set; }

        /// <summary>
        /// Gets a command that executes when the selected item in the treeview has changed.
        /// This updates a text property to inform other attached dependencies property controls
        /// about this change in selection state.
        /// </summary>
        public ICommand SelectedFolderChangedCommand
        {
            get
            {
                if (_SelectedFolderChangedCommand == null)
                {
                    _SelectedFolderChangedCommand = new RelayCommand<object>((p) =>
                    {
                        if (p is IFSItemViewModel == false)
                            return;

                        var param = p as IFSItemViewModel;

                        CurrentlySelectedItem = param;
                        SelectedItem = (IFSItemViewModel)param.Clone();
                    });
                }

                return _SelectedFolderChangedCommand;
            }
        }

        /// <summary>
        /// Gets a command that renames the currently selected item with
        /// a new name that is expected as command parameter.
        /// </summary>
        public ICommand RenameSelectedItemCommand
        {
            get
            {
                if (_RenameSelectedItemCommand == null)
                {
                    _RenameSelectedItemCommand = new RelayCommand<object>((p) =>
                    {
                        if (p is string == false)
                            return;

                        var param = p as string;

                        if (SelectedItem != null)
                            SelectedItem.Name = param;

                        if (CurrentlySelectedItem != null)
                        {
                            var parent = (CurrentlySelectedItem.Parent == null ? _rootItem : CurrentlySelectedItem.Parent);

                            if (parent == null)
                                return;

                            var selitem = CurrentlySelectedItem;

                            // Strange: BringIntoView does not work for scroll up
                            // Unless the next 2 lines are implemented...
                            parent.IsItemSelected = true;
                            parent.IsItemExpanded = true;

                            parent.Children.RenameItem(selitem, param);

                            selitem.Name = param;

                            if (_rootItem != null)
                            {
                                _rootItem.Children.Sort(item => item.Name);
                            }

                            // Select item and bring into view when its posiition has changed
                            selitem.IsItemSelected = true;
                        }
                    });
                }

                return _RenameSelectedItemCommand;
            }
        }

        private void Children_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            throw new System.NotImplementedException();
        }
        #endregion properties

        #region methods
        /// <summary>
        /// Adds or replaces the current rootItem in the ViewModel.
        /// </summary>
        /// <param name="item"></param>
        public void AddRoot(IFSItemViewModel item)
        {
            _Root.Clear();
            _rootItem = item;
            _Root.Add(item);
        }
        #endregion methods
    }
}
