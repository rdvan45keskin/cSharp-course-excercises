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

namespace WPF_Tutorial_2__Code_Behind_
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        bool running = false;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnToggleRun_Click(object sender, RoutedEventArgs e)
        {
            if (!running)
            {
                //run
                tbStatus.Text = "Running";
                btnToggleRun.Content = "Stop";
            }
            else 
            {
                //stop
                tbStatus.Text = "Stopped";
                btnToggleRun.Content = "Run";
            }
            running = !running;
        }
    }
}
