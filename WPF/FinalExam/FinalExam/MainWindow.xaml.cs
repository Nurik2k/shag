using FinalExam.lib;
using FinalExam.Pages;
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

namespace FinalExam
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        SiteService siteService = new SiteService();
        public MainWindow()
        {
            InitializeComponent();
            UrlFrame.Source = new Uri("Pages/_pageUrlList.xaml", UriKind.RelativeOrAbsolute);
        }

        private void BtnAddUrl_Click(object sender, RoutedEventArgs e)
        {
            AddUrlWindow addUrl = new AddUrlWindow();
            addUrl.Show();
        }

        private void BtnDeleteUrl_Click(object sender, RoutedEventArgs e)
        {
            DeleteUrlWindow deleteUrl = new DeleteUrlWindow();
            deleteUrl.Show();
        }

        private void btnUpdateUrl_Click(object sender, RoutedEventArgs e)
        {
            _pageUrlList._lvSitesList.ItemsSource = siteService.GetSites();
        }
    }
}
