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
    public partial class DownloadLIB : Window
    {
        public DownloadLIB()
        {
            InitializeComponent();
		}

		private void Download(object sender, EventArgs e)
		{
			string skinDir = FindSteamSkinDir();
			if (skinDir == null)
				return;
			WebClient webClient = new WebClient();
			WebClient webClient2 = new WebClient();
			webClient.DownloadFileAsync(new Uri("https://raw.githubusercontent.com/AikoMidori/steam-library/master/config.css"), skinDir + "\\config.css");
			webClient2.DownloadFileAsync(new Uri("https://raw.githubusercontent.com/AikoMidori/steam-library/master/libraryroot.custom.css"), skinDir + "libraryroot.custom.css");
			webClient2.DownloadFileCompleted += new AsyncCompletedEventHandler(Completed);
		}

			private static string FindSteamSkinDir()
		{
			string filePath = null;
			using (var registryKey = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Valve\\Steam"))
			{
				var regFilePath = registryKey?.GetValue("SteamPath");
				filePath = regFilePath.ToString().Replace(@"/", @"\") + "\\steamui\\";
			}
			return filePath;
		}

		private void Window_MouseMove(object sender, MouseEventArgs e)
		{
			if (e.LeftButton == MouseButtonState.Pressed)
			{
				this.DragMove();
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
