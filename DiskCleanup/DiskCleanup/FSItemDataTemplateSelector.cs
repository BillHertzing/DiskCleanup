namespace DiskCleanup
{
    using DiskCleanup.Interfaces;
    using System.Windows;
    using System.Windows.Controls;

    class FSItemDataTemplateSelector : DataTemplateSelector
    {
        public DataTemplate DirectoryTemplate { get; set; }
        public DataTemplate FileTemplate { get; set; }

        public override DataTemplate SelectTemplate(object item, DependencyObject container)
        {
            if (item is IDirSubTreeViewModel)
                return DirectoryTemplate;

            if (item is IFileViewModel)
                return FileTemplate;

            // Got her ebecause given argument was not understood :-(
            throw new System.ArgumentException();
        }
    }
}
