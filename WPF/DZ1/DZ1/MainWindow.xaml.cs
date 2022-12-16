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
using System.Xml;
using System.Xml.Linq;

namespace DZ1
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

        private void CreateXML_Click(object sender, RoutedEventArgs e)
        {
            using var reader = XmlReader.Create("https://habrahabr.ru/rss/interesting/%22");

        }

        private void btnInfo_Click(object sender, RoutedEventArgs e)
        {
            using var reader = XmlReader.Create("https://habrahabr.ru/rss/interesting/%22");

            reader.ReadToFollowing("title");
            labelTitle.Content += ": " + reader.ReadElementContentAsString();
            reader.ReadToFollowing("description");
            labelDescription.Content += ": " + reader.ReadElementContentAsString();
            reader.ReadToFollowing("managingEditor");
            labelManagingEditor.Content += ": " + reader.ReadElementContentAsString();
            reader.ReadToFollowing("generator");
            labelGenerator.Content += ": " + reader.ReadElementContentAsString();
            reader.ReadToFollowing("pubDate");
            labelPubdate.Content += " " + reader.ReadElementContentAsString();
        }
    }
}
