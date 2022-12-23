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

namespace KIWI
{
    /// <summary>
    /// Interaction logic for MainAuthWindow.xaml
    /// </summary>
    public partial class MainAuthWindow : Window
    {
        public MainAuthWindow()
        {
            InitializeComponent();
           

            //WrapPanel wp = new WrapPanel();
            //wp.Children.Add(new Label() { Content = "+7 777" });
            //wp.Children.Add(new Label() { Content = "logo" });
            //wp.Children.Add(new Label() { Content = "Beeline" });
            //wp.Children.Add(new Label() { Content = "0.5%" });
            //lbxOperatorList.Items.Add(wp);
        }
        private void miOperatorList_Click(object sender, RoutedEventArgs e)
        {
            frameMain.Source = new Uri("pageOperatorList.xaml", UriKind.RelativeOrAbsolute);
        }
        private void miClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void miAddOperator_Click(object sender, RoutedEventArgs e)
        {

        }
    }
    public class Operator
    {
        public string Prefix { get; set; }
        public string Logo { get; set; }
        public string Name { get; set; }
        public double Percent { get; set; }
        public Operator() { }
    }
}
