using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net;
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

namespace WPFUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 
    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            InitializeComponent();
        }

        private void buttonDM(object sender, RoutedEventArgs e)
        {
            DownloadDM win2 = new DownloadDM();
            win2.ShowDialog();
        }

        private void buttonLIB(object sender, RoutedEventArgs e)
        {
            DownloadLIB win2 = new DownloadLIB();
            win2.ShowDialog();
        }

        private void buttonFR(object sender, RoutedEventArgs e)
        {
            DownloadFR win2 = new DownloadFR();
            win2.ShowDialog();
        }

        private void buttonABT(object sender, RoutedEventArgs e)
        {
            Developers win2 = new Developers();
            win2.ShowDialog();
        }

        private void buttonINS(object sender, RoutedEventArgs e)
        {
            Developers win2 = new Developers();
            win2.ShowDialog();
        }

        private void Shutdown(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void Window_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                this.DragMove();
            }
        }

    }
}
