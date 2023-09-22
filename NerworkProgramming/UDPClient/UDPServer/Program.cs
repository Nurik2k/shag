
using System.Net;
using System.Net.Sockets;
using System.Text;

void main()
{
    Console.WriteLine("server Run");
	try
	{
		while (true)
		{
			UdpClient server = new UdpClient(5000);
			IPEndPoint remoteEndPoint = null;

			//получение данных
			byte[] bytes = server.Receive(ref remoteEndPoint);
			string message = Encoding.UTF8.GetString(bytes);

			Console.WriteLine("-> {0}", message);
			server.Close();
		}
	}
	catch (Exception)
	{

		throw;
	}
}