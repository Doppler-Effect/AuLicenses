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
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            licFile file = new licFile("venera", "D:\\Dropbox\\work\\status_venera.txt");
            foreach (Product p in file.Products)
            {
                TreeViewItem item = new TreeViewItem();
                item.Name = p.ID;
                item.Items.Add(p.maxUsers);
                TreeViewItem usersItem = new TreeViewItem();
                usersItem.Name = p.currUsers + " users";
                foreach (user u in p.Users)
                {
                    usersItem.Items.Add(u.Name);
                }
                item.Items.Add(usersItem);
                treeView.Items.Add(item);
            }
        }
    }
}
