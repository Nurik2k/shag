using Microsoft.Win32;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Text.Json.Serialization;
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

namespace TCPCient
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

        private void btnOpenFile_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog();
            if (fileDialog.ShowDialog() == true)
            {
                tbxFile.Text = fileDialog.FileName;
            }
        }

        private void btnSendFile_Click(object sender, RoutedEventArgs e)
        {
            byte[] bytes = new byte[1024];
            TcpClient client = null;
            NetworkStream stream = null;

            try
            {
                client = new TcpClient("localhost", 8088);
                MessageBox.Show("Coonected to the Server");

                stream = client.GetStream();

                FileStream fs = new FileStream(tbxFile.Text, FileMode.Open, FileAccess.Read);
                var file = File.OpenRead(tbxFile.Text);

                FileInfo fInfo = new FileInfo();
                fInfo.FileName = file.Name;
                fs.Read(fInfo.File, 0, (int)fs.Length);

                string jsonFileInfo = JsonConvert.SerializeObject(fInfo);
                byte[] fileInfoBytes = Encoding.UTF8.GetBytes(jsonFileInfo);

                int BufferSize = 1024;

                int NoOfPackets = Convert.ToInt32(Math.Ceiling(Convert.ToDouble(fs.Length) / Convert.ToDouble(BufferSize)));

                int TotalLength = (int)fs.Length, CurrentPacketLength;

                for (int i = 0; i < NoOfPackets; i++)
                {
                    if (TotalLength > BufferSize)
                    {
                        CurrentPacketLength = BufferSize; TotalLength = TotalLength - CurrentPacketLength;
                    }
                    else
                    {
                        CurrentPacketLength = TotalLength; 
                        bytes = new byte[CurrentPacketLength];
                        
                        fs.Read(bytes, 0, CurrentPacketLength);
                        stream.Write(bytes, 0, (int)bytes.Length);
                    }
                }

                fs.Read(bytes, 0, (int)fs.Length);
                stream.Write(bytes, 0, bytes.Length);

                fs.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                stream.Close();
                client.Close();
            }
        }
    }

    public class FileInfo
    {
        public string? FileName { get; set; }
        public string? Exctension { get; set; }
        public byte[]? File { get; set; }
    }

}
