using System.Net;
using System.Net.Sockets;
using System.Text;

void task1()
{
	Console.WriteLine("Client RUN");
	try
	{
		while (true)
		{
			UdpClient client = new UdpClient();

			IPAddress address = IPAddress.Parse("127.0.0.1");
			client.Connect(address, 50000);

			Console.WriteLine("-> ");
			byte[] bytes = Encoding.UTF8.GetBytes(Console.ReadLine());
			client.Send(bytes, bytes.Length);
			
			client.Close();
		}
	}
	catch (Exception)
	{

		throw;
	}
    

}

task1();