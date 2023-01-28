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
using System.Windows.Shapes;

namespace FinalExam
{
    /// <summary>
    /// Interaction logic for DeleteUrlWindow.xaml
    /// </summary>
    public partial class DeleteUrlWindow : Window
    {
        SiteService siteService = new SiteService();
        public DeleteUrlWindow()
        {
            InitializeComponent();
        }

        private void btnDeleteUrlOk_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                site site = new site();
                site.url = tbxDeleteUrl.Text;
                site.url_status = false;
                siteService.DeleteSite(site);

                Close();
                _pageUrlList._lvSitesList.ItemsSource = siteService.GetSites();
            }
            catch (Exception) { }
            
        }

        private void btnDeleteUrlCancel_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
