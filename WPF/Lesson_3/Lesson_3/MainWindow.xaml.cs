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

namespace Lesson_3
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

        private void Expander_Expanded(object sender, RoutedEventArgs e)
        {
            spExpanded.Children.OfType<Expander>().ToList();
            foreach(var item in spExpanded.Children)
            {
                Expander data = (Expander)item;
                if((Expander)sender != data)
                {
                    data.IsExpanded= false;
                }
                else
                {
                    data.IsExpanded = true;
                }
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            tbItem_1.IsEnabled= true;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            tbItem_1.IsEnabled= false;
        }

        private void tbControlList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(pswPassword.Password + "/" + tbxName.Text);
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            lbCities.Items.Add(tbxAddCity.Text);
        }

        private void lbCities2_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
        }

        private void Slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            lbSlider.Content = ((Slider)sender).Value;
        }
    }
}
