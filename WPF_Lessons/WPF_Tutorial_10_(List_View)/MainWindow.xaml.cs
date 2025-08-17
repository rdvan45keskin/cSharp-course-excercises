using System;
using System.Collections;
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

namespace WPF_Tutorial_10__List_View_
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            lvEntries.Items.Add(tbxEntry.Text);
            tbxEntry.Text = "";
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            //int index = lvEntries.SelectedIndex;
            //object item = lvEntries.SelectedItem;
            var items = lvEntries.Items;
            
            var result = MessageBox.Show($"Are you sure you want to delete {items.Count} items?", "Sure?" , MessageBoxButton.YesNo);
            if (result == MessageBoxResult.Yes)
            {
                var itemList = new ArrayList(items);
                foreach (var item in itemList)
                {
                    lvEntries.Items.Remove(item);
                }
            }
        }

        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            lvEntries.Items.Clear();
        }
    }
}
