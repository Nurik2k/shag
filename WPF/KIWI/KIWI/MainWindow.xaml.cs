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
using KIWI.dll;
namespace KIWI
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

        private void btnAuth_Click(object sender, RoutedEventArgs e)
        {
            string login = tbxLogin.Text;
            string password = tbxPassword.Password;
            if(string.IsNullOrWhiteSpace(login))
            {
                lblLoginMessage.Content = "Поле обязательно к заполнению";
            }
            else
            {
                lblLoginMessage.Content = "";
            }
            if(string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("Необходимо указать пароль");
            }
            MainAuthWindow mainAuthWindow = new MainAuthWindow();
            mainAuthWindow.Show();
            this.Close();
        }

    }
}
