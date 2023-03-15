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

namespace RSA
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        RSA rsa = new RSA();
        
        public MainWindow()
        {
            InitializeComponent();
        }

        private void EncryptRsa_Click(object sender, RoutedEventArgs e)
        {
            string a = tbxERsa.Text;
            tbxERsaResult.Text = rsa.ERSA(a).ToString();

        }

        private void DecryptRsa_Click(object sender, RoutedEventArgs e)
        {
            
        }
    }
}
