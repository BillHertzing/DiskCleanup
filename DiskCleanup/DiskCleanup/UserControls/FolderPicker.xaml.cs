using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace DiskCleanup.UserControls
{
    /// <summary>
    /// Interaction logic for FolderPicker.xaml
    /// </summary>
    public partial class FolderPicker : UserControl
    {
        public FolderPicker()
        {
            InitializeComponent();
        }

        private void bt_PickClick(object sender, RoutedEventArgs e)
        {
            PickRoot(tb_FolderName.Text);
        }

        private void PickRoot(String str)
        {
            var dlg = new OpenFileDialog();
            dlg.InitialDirectory = str;
            Nullable<bool> result = dlg.ShowDialog();
            if (result == true)
            {
                string newRootDirSubTreeName = dlg.FileName;
            }
        }
    }
}
