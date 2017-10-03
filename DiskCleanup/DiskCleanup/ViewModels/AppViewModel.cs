using DiskCleanup.Models;
using System.IO;

namespace DiskCleanup.ViewModels
{
    //using DiskCleanup.Models;

    /// <summary>
    /// Implements an Application viewmodel that contains main viewmodel
    /// objects, commands, and properties.
    /// </summary>
    internal class AppViewModel : Base.BaseViewModel
    {
        private readonly FSViewModel _FSL = null;
        private readonly FSViewModel _FSR = null;

        /// <summary>
        /// Class constructor
        /// </summary>
        public AppViewModel()
        {
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
    }
}
