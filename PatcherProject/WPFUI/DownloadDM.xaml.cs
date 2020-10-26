using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
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
    public partial class DownloadDM : Window
    {
        public DownloadDM()
        {
            InitializeComponent();
		}

		private void Window_MouseMove(object sender, MouseEventArgs e)
		{
			if (e.LeftButton == MouseButtonState.Pressed)
			{
				this.DragMove();
			}
		}

		private void Download(object sender, RoutedEventArgs e)
		{
			Microsoft.Win32.SaveFileDialog dlg = new Microsoft.Win32.SaveFileDialog();
			dlg.FileName = "webkit"; // Default file name
			dlg.DefaultExt = ".css"; // Default file extension
			dlg.Filter = "Cascade Style Sheets (*.css) | *.css"; // Filter files by extension

			// Show save file dialog box
			Nullable<bool> result = dlg.ShowDialog();

			// Process save file dialog box results
			if (result == true)
			{

				dlg.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
				WebClient webClient = new WebClient();
				webClient.DownloadFileCompleted += new AsyncCompletedEventHandler(Completed);
				//webClient.DownloadProgressChanged += new DownloadProgressChangedEventHandler(ProgressChanged);
				webClient.DownloadFileAsync(new Uri("https://raw.githubusercontent.com/AikoMidori/steam-dark-mode/master/webkit.css"),
					dlg.FileName);
				// Save document
				string filename = dlg.FileName;
			}
		}
	
		private void Completed(object sender, AsyncCompletedEventArgs e)
		{
			MessageBox.Show("Download completed!");
		}

		private void Close(object sender, RoutedEventArgs e)
		{
					Close();
		}
	}
}
