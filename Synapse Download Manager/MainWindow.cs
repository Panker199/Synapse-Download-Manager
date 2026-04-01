// Synapse Download Manager\MainWindow.xaml.cs
using System;
using System.Windows;
using System.Windows.Controls;

namespace Synapse_Download_Manager
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Filter_Changed(object sender, SelectionChangedEventArgs e)
        {
            // Handler for category/status selection changes.
        }

        private void Search_Changed(object sender, TextChangedEventArgs e)
        {
            // Handler for search box text changes.
        }

        private void NewTask_Click(object sender, RoutedEventArgs e)
        {
            // Minimal behaviour for the New Task button.
            MessageBox.Show("New Task clicked", "Synapse DL", MessageBoxButton.OK, MessageBoxImage.Information);
        }
    }
}