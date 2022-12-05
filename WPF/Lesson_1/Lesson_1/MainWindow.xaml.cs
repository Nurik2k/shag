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

namespace Lesson_1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            TestWin.Title = "TestWindows";
            /*
            btnShowAlert.Click += btnShowAlert_Click;           
            Button btn = new Button();
            btn.Content = "BTN";
            btn.Width = 50;
            btn.Height = 50;
            TestWin.Content = btn;
            */
        }

        private void btnShowAlert_Click(object sender, RoutedEventArgs e)
        {
            Button btn = (Button)sender;
            MessageBox.Show("Work - "+DateTime.Now);
        }

        private void btnSendMsg_Click(object sender, RoutedEventArgs e)
        {
            bool result = false;
            lblMessage.Content = Helper.SendMsg(tbxTo.Text, tbxSubject.Text, tbxBody.Text, out result);
            if (!result)
            {
                lblMessage.Foreground = new SolidColorBrush(Colors.Red);
            }
            else
            {
                lblMessage.Foreground = new SolidColorBrush(Colors.Green);
            }
        }
    }
}
