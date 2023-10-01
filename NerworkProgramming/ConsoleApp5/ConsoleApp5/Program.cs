using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp5
{
    internal class Program
    {
        static void Main(string[] args)
        {

            IPEndPoint endPoint = new IPEndPoint(IPAddress.Any, 9050);
            while (true)
            {
                Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
                socket.Bind(endPoint);
                EndPoint ep = (EndPoint)endPoint;
                Console.WriteLine("Ready to recieve ...");
                byte[] data = new byte[1024];
                int recv = socket.ReceiveFrom(data, ref ep);
                string stringData = Encoding.UTF8.GetString(data, 0, recv);
                Console.WriteLine("{0} -> {1}", ep.ToString(), stringData);
                socket.Close();
            }
        }
    }
}
