using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

public class Server
{
    private TcpListener tcpListener;
    private List<TcpClient> clients = new List<TcpClient>();
    private bool isRunning;

    public Server(IPAddress ipAddress, int port)
    {
        tcpListener = new TcpListener(ipAddress, port);
    }

    public void Start()
    {
        isRunning = true;
        tcpListener.Start();

        Console.WriteLine("Server started. Waiting for connections...");

        while (isRunning)
        {
            TcpClient client = tcpListener.AcceptTcpClient();
            clients.Add(client);

            Task.Factory.StartNew(() => HandleClient(client));
        }
    }

    public void Stop()
    {
        isRunning = false;
        tcpListener.Stop();

        foreach (TcpClient client in clients)
        {
            client.Close();
        }
    }

    private void HandleClient(TcpClient client)
    {
        NetworkStream networkStream = client.GetStream();

        byte[] buffer = new byte[1024];
        int bytesRead;

        while ((bytesRead = networkStream.Read(buffer, 0, buffer.Length)) > 0)
        {
            string message = Encoding.UTF8.GetString(buffer, 0, bytesRead);
            Console.WriteLine($"Received from client: {message}");

            // Отправка сообщения обратно клиенту
            foreach (TcpClient otherClient in clients)
            {
                if (otherClient != client)
                {
                    NetworkStream otherStream = otherClient.GetStream();
                    byte[] responseBytes = Encoding.UTF8.GetBytes(message);
                    otherStream.Write(responseBytes, 0, responseBytes.Length);
                }
            }
        }

        // Клиент отключился, удаляем его из списка
        clients.Remove(client);
        client.Close();
    }
}

class Program
{
    static void Main(string[] args)
    {
        IPAddress ipAddress = IPAddress.Parse("127.0.0.1"); // Замените на нужный IP-адрес сервера
        int port = 12345; // Замените на нужный порт

        Server server = new Server(ipAddress, port);
        server.Start();

        Console.WriteLine("Server started. Press Enter to stop.");
        Console.ReadLine();

        server.Stop();
    }
}
