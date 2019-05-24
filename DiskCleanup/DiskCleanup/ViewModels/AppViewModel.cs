using DiskCleanup.Models;
using System;
using System.IO;
using System.Collections.Generic;

namespace DiskCleanup.ViewModels
{
    //using DiskCleanup.Models;

    /// <summary>
    /// Implements an Application viewmodel that contains main viewmodel
    /// objects, commands, and properties.
    /// </summary>
    internal class AppViewModel : Base.BaseViewModel
    {
        int _NumDirSubTrees;
        private SortableObservableCollection<FSViewModel> _fsViews;
        private readonly FSViewModel _FSL = null;
        private readonly FSViewModel _FSR = null;

        /// <summary>
        /// Class constructor
        /// </summary>
        public AppViewModel()
        {
            _fsViews = new SortableObservableCollection<FSViewModel>();
            // ToDo Get list of last used rootDirSubTree names /paths from settings
            List<string> lastused = new List<string>() { "D:\\ncatlt02LastDump\\Temp" , "D:\\ncatlt02LastDump"};
            foreach (string rootDirSubTreeName in lastused)
            {
                // Create a DirSubTree item and the items below it
                DirSubTree rootDirSubTree = new DirSubTree(rootDirSubTreeName);
                // Wraps the FileSystem items in UI-Friendly ViewModel Items
                var root = new DirSubTreeViewModel(null, rootDirSubTree);
                // create a new FSViewModel instance 
                FSViewModel _fsv = new FSViewModel();
                // Add the new DirSubtreeViewModel to the new FSViewModel instance
                _fsv.AddRoot(root);
                // Sort the roots children and expand the root node
                root.Children.Sort(item => item.Name);
                root.IsItemExpanded = true;
                // add the new FSViewModel instance to the collection of FSViewModel
                _fsViews.Add(_fsv);
            }
            // create a new FSViewModel instance for each and store it in the _fsviews collection
            _FSL = new FSViewModel();

            // Create a DirSubTree item and the items below it
            DirSubTree rootDirSubTreeL = new DirSubTree("D:\\ncatlt02LastDump\\Temp");

            // Wraps the FileSystem items in UI-Friendly ViewModel Items
            var rootL = new DirSubTreeViewModel(null, rootDirSubTreeL);
            _FSL.AddRoot(rootL);

            //var list = CreateTest.GetData();
            //list = CreateTest.GetDataMoreData(list);

            //foreach (var item in list)
           //     root.AddChildItem(new GitHubProjectViewModel(root, item));

           rootL.Children.Sort(item => item.Name);
           rootL.IsItemExpanded = true;


            _FSR = new FSViewModel();

            // Create a DirSubTree item and the items below it
            DirSubTree rootDirSubTreeR = new DirSubTree("D:\\ncatlt02LastDump");

            // Wraps the FileSystem items in UI-Friendly ViewModel Items
            var rootR = new DirSubTreeViewModel(null, rootDirSubTreeR);
            _FSR.AddRoot(rootR);

            //var list = CreateTest.GetData();
            //list = CreateTest.GetDataMoreData(list);

            //foreach (var item in list)
            //     root.AddChildItem(new GitHubProjectViewModel(root, item));

            rootR.Children.Sort(item => item.Name);
            rootR.IsItemExpanded = true;
        }

        /// <summary>
        /// Gets a property that can be used to display
        /// a treeview on FileSystem items.
        /// </summary>
        public FSViewModel FSL
        {
            get
            {
                return _FSL;
            }
        }
        public FSViewModel FSR
        {
            get
            {
                return _FSR;
            }
        }
        public SortableObservableCollection<FSViewModel> FSViews
        {
            get
            {
                return _fsViews;
            }
        }
    }
}
