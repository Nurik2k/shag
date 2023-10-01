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

namespace WebDowlander
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

        private async Task DownloadButton_ClickAsync(object sender, RoutedEventArgs e)
        {
            string url = UrlTextBox.Text;
            string outputPath = "downloaded_file.txt"; // Замените на путь к файлу и его имя по вашему выбору

            try
            {
                var fileDownloader = new FileDownloader();
                await fileDownloader.DownloadFileAsync(url, outputPath);
                DownloadedFilesListBox.Items.Add($"Downloaded: {outputPath}");
            }
            catch (Exception ex)
            {
                DownloadedFilesListBox.Items.Add($"Error: {ex.Message}");
            }

        }
    }
}
