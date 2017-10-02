

namespace DiskCleanup.ViewModels
{
    using DiskCleanup.Interfaces;
    using System;

    /// <summary>
    /// Implements a viewmodel item in the collection of FileSystem file items.
    /// </summary>
    internal class FileViewModel : ViewModels.Base.BaseViewModel, ICloneable, IDirectoryViewModel
    {
        #region fields
        private IFSItemViewModel _parent = null;
        private string _Name = string.Empty;

        private readonly SortableObservableDictionaryCollection _Children = null;
        private bool _IsItemExpanded = false;
        private bool _IsItemSelected = false;
        #endregion fields

        #region constructors
        /// <summary>
        /// Class constructor
        /// </summary>
        /// <param name="name"></param>
        public FileViewModel(
            IFSItemViewModel parent
            , string name)
        {
            _parent = parent;
            _Name = name;
            _Children = new SortableObservableDictionaryCollection();
        }

        /// <summary>
        /// Copy constructor copies only Name property.
        /// Children and State properties are not automatically copied.
        /// </summary>
        /// <param name="copyThis"></param>
        public FileViewModel(FileViewModel copyThis)
        {
            if (copyThis == null)
                return;

            this.Name = copyThis.Name;
        }
        #endregion constructors

        #region properties
        public IFSItemViewModel Parent
        {
            get
            {
                return _parent;
            }
        }

        /// <summary>
        /// Gets the name of this item.
        /// </summary>
        /// <param name="name"></param>
        public string Name
        {
            get
            {
                return _Name;
            }

            set
            {
                if (_Name != value)
                {
                    _Name = value;
                    NotifyPropertyChanged(() => Name);
                }
            }
        }

        /// <summary>
        /// Gets the Children items below this item.
        /// </summary>
        public SortableObservableDictionaryCollection Children
        {
            get
            {
                return _Children;
            }
        }

        /// <summary>
        /// Gets/sets whether this item is expanded or not.
        /// </summary>
        public bool IsItemExpanded
        {
            get
            {
                return _IsItemExpanded;
            }

            set
            {
                if (_IsItemExpanded != value)
                {
                    _IsItemExpanded = value;
                    NotifyPropertyChanged(() => IsItemExpanded);
                }
            }
        }

        /// <summary>
        /// Gets/sets whether this item is selected or not.
        /// </summary>
        public bool IsItemSelected
        {
            get
            {
                return _IsItemSelected;
            }

            set
            {
                if (_IsItemSelected != value)
                {
                    _IsItemSelected = value;
                    NotifyPropertyChanged(() => IsItemSelected);
                }
            }
        }
        #endregion properties

        #region methods
        /// <summary>
        /// Adds another child into the collection of items.
        /// </summary>
        /// <param name="item"></param>
        public void AddChildItem(IFSItemViewModel item)
        {
            _Children.AddItem(item);
        }

        /// <summary>
        /// Copies only Name property.
        /// Children and State properties are not automatically copied.
        /// </summary>
        /// <returns></returns>
        public object Clone()
        {
            return new FileViewModel(this);
        }
        #endregion methods
    }
}
