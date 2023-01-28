using FinalExam.lib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
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

namespace FinalExam.Pages
{
    /// <summary>
    /// Interaction logic for _pageUrlList.xaml
    /// </summary>
    public partial class _pageUrlList : Page
    {
        
        SiteService siteService = new SiteService();
        public static ListView _lvSitesList = null;
        public _pageUrlList()
        {
            InitializeComponent();
            lvSitesList.ItemsSource = siteService.GetSites();
            _lvSitesList = lvSitesList;
        }
    }
}
