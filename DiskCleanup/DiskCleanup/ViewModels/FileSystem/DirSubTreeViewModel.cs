using DiskCleanup.Interfaces;
using DiskCleanup.Models;
using System;
using System.IO;
using System.Linq;

namespace DiskCleanup.ViewModels
{

    /// <summary>
    /// Implements a viewmodel item in the collection of FileSystem Directory tree items.
    /// </summary>
    internal class DirSubTreeViewModel :  ViewModels.Base.BaseViewModel, ICloneable, IDirSubTreeViewModel
    {
        #region fields
        private DirSubTree _dirSubTree = null;
        private IFSItemViewModel _parent = null;
        private readonly SortableObservableDictionaryCollection _children = null;
        private bool _IsItemExpanded = false;
        private bool _IsItemSelected = false;
        #endregion fields

        #region constructors
        /// <summary>
        /// Class constructor
        /// </summary>
        public DirSubTreeViewModel(IDirSubTreeViewModel parent, DirSubTree dirSubTree)
        {
            _dirSubTree = dirSubTree;
            _parent = parent;
            _children = new SortableObservableDictionaryCollection();
            foreach (DirSubTree child in _dirSubTree.Children)
            {
                _children.AddItem(new DirSubTreeViewModel(this, child));
            }
        }

        /// <summary>
        /// Copy constructor copies only _dirSubTree property.
        /// Children and State properties are not automatically copied.
        /// </summary>
        /// <param name="copyThis"></param>
        public DirSubTreeViewModel(DirSubTreeViewModel copyThis)
        {
            if (copyThis == null)
                return;

            this._dirSubTree = copyThis._dirSubTree;
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
                return _dirSubTree.DirInfo.Name;
            }

            set
            {
                if (_dirSubTree.DirInfo.Name != value)
                {
                    _dirSubTree.DirInfo.MoveTo(Path.Combine(_dirSubTree.DirInfo.Parent.FullName, value));
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
                return _children;
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
            _children.AddItem(item);
        }

        /// <summary>
        /// Copies only Name property.
        /// Children and State properties are not automatically copied.
        /// </summary>
        /// <returns></returns>
        public object Clone()
        {
            return new DirSubTreeViewModel(this);
        }
        #endregion methods
    }
}
