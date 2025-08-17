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

namespace WPF_Tutorial_8__Open_File_Dialog_
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

        private void btnFire_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Music Files | *.mp4";
            //openFileDialog.InitialDirectory = "D\\animeler";
            openFileDialog.Title = "Please pick a mp4 file...";
            openFileDialog.Multiselect = true;

            bool? success = openFileDialog.ShowDialog();        //dosya seçme ekranı açmak için
            if (success == true)
            {
                string[] paths = openFileDialog.FileNames;
                string[] fileNames = openFileDialog.SafeFileNames;
                //tbInfo.Text = fileName;

                
            }
        }
    }
}
