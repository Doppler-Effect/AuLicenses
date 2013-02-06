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
        SerializableFilenamesSaver fileNames;

        public MainWindow()
        {
            InitializeComponent();
            fileNames = new SerializableFilenamesSaver();
            foreach (string s in fileNames.Members)
            {
                bool fileExists = false;
                if (System.IO.File.Exists(s))
                    fileExists = true;
                addLicFileToTree(s, fileExists);
            }
        }

        private void addLicFileToTree(string filename, bool fileExists = true)
        {
            TreeViewItem RootItem = new TreeViewItem();
            RootItem.IsExpanded = true;
            RootItem.Tag = filename;
            string rootItemName = filename.Split('\\').Last();
            RootItem.Header = rootItemName;

            if (fileExists)
            {
                licFile file = new licFile(rootItemName, filename);
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
            }
            else
            {
                TreeViewItem notFoundReport = new TreeViewItem();
                notFoundReport.Header = "Файл не найден";
                RootItem.Items.Add(notFoundReport);
            }

            treeView.Items.Add(RootItem);
            fileNames.Add(filename);
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
            TreeViewItem item = treeView.SelectedItem as TreeViewItem;
            if (item != null)
            {
                treeView.Items.Remove(item);
                string fileName = item.Tag.ToString();
                fileNames.Remove(fileName);
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

        }
    }
}