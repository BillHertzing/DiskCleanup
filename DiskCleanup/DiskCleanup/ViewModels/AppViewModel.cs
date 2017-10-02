namespace DiskCleanup.ViewModels
{
    using DiskCleanup.Models;

    /// <summary>
    /// Implements an Application viewmodel that contains main viewmodel
    /// objects, commands, and properties.
    /// </summary>
    internal class AppViewModel : Base.BaseViewModel
    {
        private readonly FSViewModel _FS = null;

        /// <summary>
        /// Class constructor
        /// </summary>
        public AppViewModel()
        {
            _FS = new FSViewModel();

            // Adds a Directory item and items below it

            // Wraps the FileSystem items in UI-Friendly ViewModel Items
            var root = new DirectoryViewModel(null, "D:\\ncatlt02LastDump\\Temp");
            _FS.AddRoot(root);

            //var list = CreateTest.GetData();
            //list = CreateTest.GetDataMoreData(list);

            //foreach (var item in list)
           //     root.AddChildItem(new GitHubProjectViewModel(root, item));

           // root.Children.Sort(item => item.Name);
            //root.IsItemExpanded = true;
        }

        /// <summary>
        /// Gets a property that can be used to display
        /// a treeview on FileSystem items.
        /// </summary>
        public FSViewModel FS
        {
            get
            {
                return _FS;
            }
        }
    }
}
