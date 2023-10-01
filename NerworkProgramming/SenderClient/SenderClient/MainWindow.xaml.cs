using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Runtime.Remoting.Channels;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SenderClient
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly NotifyIcon icon;
        public MainWindow()
        {
            InitializeComponent();

            icon = new NotifyIcon()
            {
                Visible = false
            };
        }

        private void StartListeninButton_Click(object sender, RoutedEventArgs e)
        {
            string path = Directory.GetCurrentDirectory();
            icon.Icon = new System.Drawing.Icon($@"{path}\\ear.icon");
            icon.ShowBalloonTip(5000, "SenderClient", "Listening", ToolTipIcon.Info);

            if (WindowState == WindowState.Normal)
            {
                Hide();
                icon.Visible = true;
            }
            Listen();
        }

        private void Listen()
        {
            Socket server = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
            IPEndPoint endPoint = new IPEndPoint(IPAddress.Any, 5001);
            server.Bind(endPoint);

            while (true)
            {
                byte[] data = new byte[1024];
                EndPoint ep = endPoint;
                int received = server.ReceiveFrom(data, ref ep);

                string message = Encoding.UTF8.GetString(data);
                icon.ShowBalloonTip(0, "Incoming message", message, ToolTipIcon.Info);
            }
        }
    }
}
