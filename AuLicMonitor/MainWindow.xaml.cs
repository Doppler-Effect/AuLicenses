using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using AuLicCore;

namespace AuLicMonitor
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Dictionary<string, string> fileNames = new Dictionary<string, string>();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void addLicFileToTree(string filename)
        {
            string[] pathTokens = filename.Split('\\');
            string rootName = pathTokens.Last();
            licFile file = new licFile(rootName, filename);
            TreeViewItem RootItem = new TreeViewItem();
            RootItem.Header = file.Name;
            RootItem.IsExpanded = true;
            foreach (Product p in file.Products)
            {
                TreeViewItem product = new TreeViewItem();
                product.Header = p.ID + ": " + p.currUsers + " of " + p.maxUsers + " users.";
                product.IsExpanded = false;
                foreach (user u in p.Users)
                {
                    product.Items.Add(u.Name);
                }
                RootItem.Items.Add(product);
            }
            treeView.Items.Add(RootItem);
            fileNames.Add(rootName, filename);
        }

        private string getLicFilePath()
        {
            string filename = null;
            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();
            dlg.Filter = "txt Files|*.txt";
            dlg.InitialDirectory = Microsoft.Win32.FileDialogCustomPlaces.Desktop.Path;
            dlg.Multiselect = false;
            if (dlg.ShowDialog() == true)
            {
                filename = dlg.FileName;
            }
            return filename;
        }

        private void buttonAdd_Click(object sender, RoutedEventArgs e)
        {
            string filename = getLicFilePath();
            if (filename != null)
            {
                addLicFileToTree(filename);
            }
        }

        private void buttonRemove_Click(object sender, RoutedEventArgs e)
        {
            object item = treeView.SelectedItem;
            if (item != null)
            {
                treeView.Items.Remove(item);
                string headerText = ((TreeViewItem)item).Header.ToString();
                if (fileNames.ContainsKey(headerText))
                    fileNames.Remove(headerText);
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

        }
    }
}