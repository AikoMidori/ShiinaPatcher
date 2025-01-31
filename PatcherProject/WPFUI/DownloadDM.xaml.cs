﻿using Microsoft.Win32;
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

		private void Download(object sender, EventArgs e)
		{
			string skinDir = FindSteamSkinDir();
			if (skinDir == null)
				return;
			WebClient webClient = new WebClient();
			webClient.DownloadFileAsync(new Uri("https://raw.githubusercontent.com/AikoMidori/steam-dark-mode/master/webkit.css"), skinDir + "\\webkit.css");
			webClient.DownloadFileCompleted += new AsyncCompletedEventHandler(Completed);
		}

		private static string FindSteamSkinDir()
		{
			string filePath = null;
			string skinName = null;
			using (var registryKey = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Valve\\Steam"))
			{
				var regFilePath = registryKey?.GetValue("SteamPath");
				var activeSkin = registryKey?.GetValue("SkinV5");
				filePath = regFilePath.ToString().Replace(@"/", @"\") + "\\skins\\" + activeSkin.ToString().Replace(@"/", @"\") + "\\test";
				skinName = (string)activeSkin;
			}
			if (filePath != null)
			{
				MessageBox.Show("Steam Skin: " + skinName);
			}
			else
			{
				MessageBox.Show("Steam installation not found");
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
