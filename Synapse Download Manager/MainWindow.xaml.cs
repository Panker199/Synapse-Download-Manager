using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using Synapse_Download_Manager.Models;

namespace Synapse_Download_Manager
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private List<DownloadItem> downloadItems = new List<DownloadItem>();
        private List<TorrentItem> torrentItems = new List<TorrentItem>();
        private DownloadManager downloadManager = new DownloadManager();

        public MainWindow()
        {
            InitializeComponent();
            InitializeSampleData();
        }

        private void InitializeSampleData()
        {
            downloadItems = new List<DownloadItem>
            {
                new DownloadItem
                {
                    Id = 1,
                    Name = "llama-3-70b-instruct.safetensors",
                    Category = "Software",
                    Size = "145.2 GB",
                    Progress = 72,
                    Speed = "124.5 MB/s",
                    Status = "Downloading",
                    Threads = 16,
                    Url = "https://huggingface.co/meta-llama/Llama-3-70b",
                    Date = "Today",
                    RemainingTime = new TimeSpan(0, 8, 12)
                },
                new DownloadItem
                {
                    Id = 2,
                    Name = "stable_diffusion_xl_base.zip",
                    Category = "Compressed",
                    Size = "6.5 GB",
                    Progress = 100,
                    Speed = "0 MB/s",
                    Status = "Completed",
                    Threads = 0,
                    Url = "https://civitai.com/api/v1/model/sdxl",
                    Date = "Yesterday",
                    RemainingTime = TimeSpan.Zero
                },
                new DownloadItem
                {
                    Id = 3,
                    Name = "architecture_diagram.pdf",
                    Category = "Documents",
                    Size = "4.2 MB",
                    Progress = 100,
                    Speed = "0 MB/s",
                    Status = "Completed",
                    Threads = 0,
                    Url = "https://docs.synapse.io/arch.pdf",
                    Date = "Yesterday",
                    RemainingTime = TimeSpan.Zero
                },
                new DownloadItem
                {
                    Id = 4,
                    Name = "training_dataset_v4.tar.gz",
                    Category = "Compressed",
                    Size = "12.8 GB",
                    Progress = 15,
                    Speed = "45.2 MB/s",
                    Status = "Downloading",
                    Threads = 8,
                    Url = "https://internal-s3.synapse.net/datasets/v4.tar.gz",
                    Date = "Today",
                    RemainingTime = new TimeSpan(0, 52, 30)
                }
            };

            torrentItems = new List<TorrentItem>
            {
                new TorrentItem
                {
                    Id = 1,
                    Name = "Ubuntu 22.04 LTS [Official]",
                    Category = "Linux",
                    Size = "2.8 GB",
                    Progress = 95,
                    Speed = "5.6 MB/s",
                    Status = "Downloading",
                    Seeds = 1250,
                    Peers = 382,
                    Hash = "a1b2c3d4e5f6g7h8i9j0k1l2m3n4o5p6",
                    Date = "Today",
                    RemainingTime = new TimeSpan(0, 2, 15),
                    Ratio = 0
                },
                new TorrentItem
                {
                    Id = 2,
                    Name = "Debian 12 Bookworm",
                    Category = "Linux",
                    Size = "2.4 GB",
                    Progress = 100,
                    Speed = "0 MB/s",
                    Status = "Seeding",
                    Seeds = 842,
                    Peers = 156,
                    Hash = "z9y8x7w6v5u4t3s2r1q0p9o8n7m6l5k4",
                    Date = "2 days ago",
                    RemainingTime = TimeSpan.Zero,
                    Ratio = 2
                },
                new TorrentItem
                {
                    Id = 3,
                    Name = "Fedora 39 Workstation",
                    Category = "Linux",
                    Size = "1.9 GB",
                    Progress = 42,
                    Speed = "3.2 MB/s",
                    Status = "Downloading",
                    Seeds = 645,
                    Peers = 289,
                    Hash = "f1e2d3c4b5a6z7y8x9w0v1u2t3s4r5q6",
                    Date = "Today",
                    RemainingTime = new TimeSpan(0, 11, 30),
                    Ratio = 0
                },
                new TorrentItem
                {
                    Id = 4,
                    Name = "Blender 3.6 LTS",
                    Category = "Software",
                    Size = "3.1 GB",
                    Progress = 78,
                    Speed = "8.9 MB/s",
                    Status = "Downloading",
                    Seeds = 523,
                    Peers = 421,
                    Hash = "p6o5n4m3l2k1j0i9h8g7f6e5d4c3b2a1",
                    Date = "Today",
                    RemainingTime = new TimeSpan(0, 5, 45),
                    Ratio = 0
                }
            };
        }

        private void Filter_Changed(object sender, SelectionChangedEventArgs e)
        {
            // Handler for category/status selection changes
            // TODO: Implement filtering logic
        }

        private void Search_Changed(object sender, TextChangedEventArgs e)
        {
            // Handler for search box text changes
            // TODO: Implement search logic
        }

        private void NewTask_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Opening New Download dialog...", "Synapse DL Pro", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            if (sender is MenuItem menuItem)
            {
                MessageBox.Show($"'{menuItem.Header}' clicked", "Synapse DL Pro", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else if (sender is Button button)
            {
                MessageBox.Show("Action triggered", "Synapse DL Pro", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private void Border_MouseEnter(object sender, System.Windows.Input.MouseEventArgs e)
        {
            if (sender is Border border)
            {
                border.Effect = new System.Windows.Media.Effects.DropShadowEffect
                {
                    BlurRadius = 4,
                    ShadowDepth = 2,
                    Opacity = 0.2
                };
            }
        }

        private void Border_MouseLeave(object sender, System.Windows.Input.MouseEventArgs e)
        {
            if (sender is Border border)
            {
                border.Effect = null;
            }
        }

        private void MinimizeBtn_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void MaximizeBtn_Click(object sender, RoutedEventArgs e)
        {
            if (WindowState == WindowState.Maximized)
            {
                WindowState = WindowState.Normal;
                var icon = this.FindName("MaximizeIcon") as TextBlock;
                if (icon != null) icon.Text = "\uE922"; // Maximize icon
            }
            else
            {
                WindowState = WindowState.Maximized;
                var icon = this.FindName("MaximizeIcon") as TextBlock;
                if (icon != null) icon.Text = "\uE923"; // Restore icon
            }
        }

        private void CloseBtn_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void TitleBar_MouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (e.ClickCount == 2)
            {
                MaximizeBtn_Click(sender, e);
            }
            else
            {
                DragMove();
            }
        }

        private void AddUrlBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void PauseBtn_Click(object sender, RoutedEventArgs e)
        {
            downloadManager.PauseDownload();
        }

        private void ResumeBtn_Click(object sender, RoutedEventArgs e)
        {
            downloadManager.ResumeDownload();
        }

        private void CancelBtn_Click(object sender, RoutedEventArgs e)
        {
            downloadManager.CancelDownload();
        }

        private void CloseBtn_Click_1(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }
    }

    public class DownloadManager
    {
        private WebClient webClient;
        private CancellationTokenSource cts;
        private string currentUrl;
        private bool isPaused;
        private MemoryStream downloadBuffer;
        private long bytesReceived;
        private long totalBytes;
        private string tempFilePath;
        private string finalFilePath;

        public void AddDownload(string url)
        {
            if (webClient != null)
                return; // Only one at a time for this demo
            currentUrl = url;
            tempFilePath = Path.GetTempFileName();
            finalFilePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), "Downloads", Path.GetFileName(url));
            webClient = new WebClient();
            webClient.DownloadProgressChanged += WebClient_DownloadProgressChanged;
            webClient.DownloadFileCompleted += WebClient_DownloadFileCompleted;
            cts = new CancellationTokenSource();
            webClient.DownloadFileAsync(new Uri(url), tempFilePath);
        }

        public void PauseDownload()
        {
            if (webClient != null && !isPaused)
            {
                webClient.CancelAsync();
                isPaused = true;
            }
        }

        public void ResumeDownload()
        {
            if (isPaused && !string.IsNullOrEmpty(currentUrl))
            {
                isPaused = false;
                AddDownload(currentUrl); // Simple resume (restarts for demo)
            }
        }

        public void CancelDownload()
        {
            if (webClient != null)
            {
                webClient.CancelAsync();
                webClient.Dispose();
                webClient = null;
                isPaused = false;
            }
        }

        private void WebClient_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            // TODO: Update UI with progress
        }

        private void WebClient_DownloadFileCompleted(object sender, AsyncCompletedEventArgs e)
        {
            if (!e.Cancelled && e.Error == null)
            {
                File.Move(tempFilePath, finalFilePath);
                MessageBox.Show("Download completed!", "Info", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            webClient.Dispose();
            webClient = null;
            isPaused = false;
        }
    }
}