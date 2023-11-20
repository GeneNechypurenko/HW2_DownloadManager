using System;
using System.Net;
using System.Threading.Tasks;
using System.Windows;

namespace HW2_DownloadManager
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private async void downloadButton_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(urlTextBox.Text))
            {
                try
                {
                    await DownloadFileAsync(urlTextBox.Text);
                    MessageBox.Show("Downlad completed!");
                }
                catch (Exception ex) { MessageBox.Show($"Error: {ex.Message}"); }
            }
            else { MessageBox.Show("Please enter a valid URL."); }
        }
        private async Task DownloadFileAsync(string url)
        {
            using (WebClient client = new WebClient())
            {
                Uri uri = new Uri(url);
                string fileName = System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), System.IO.Path.GetFileName(uri.LocalPath));

                client.DownloadProgressChanged += (s, e) => downloadProgressBar.Value = e.ProgressPercentage;

                await client.DownloadFileTaskAsync(uri, fileName);
            }
        }
    }
}
