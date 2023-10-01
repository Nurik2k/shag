using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

public class Server
{
    private TcpListener tcpListener;
    private bool isRunning;

    public Server(IPAddress ipAddress, int port)
    {
        tcpListener = new TcpListener(ipAddress, port);
    }

    public void Start()
    {
        isRunning = true;
        tcpListener.Start();

        while (isRunning)
        {
            TcpClient client = tcpListener.AcceptTcpClient();
            ThreadPool.QueueUserWorkItem(HandleClient, client);
        }
    }

    public void Stop()
    {
        isRunning = false;
        tcpListener.Stop();
    }

    private void HandleClient(object clientObj)
    {
        TcpClient client = (TcpClient)clientObj;
        NetworkStream networkStream = client.GetStream();

        // Чтение длины пакета
        byte[] lengthBytes = new byte[4];
        int bytesRead = networkStream.Read(lengthBytes, 0, 4);
        if (bytesRead != 4)
        {
            // Обработка ошибки
            client.Close();
            return;
        }
        int packetLength = BitConverter.ToInt32(lengthBytes, 0);

        // Чтение данных пакета
        byte[] data = new byte[packetLength];
        bytesRead = networkStream.Read(data, 0, packetLength);
        if (bytesRead != packetLength)
        {
            // Обработка ошибки
            client.Close();
            return;
        }

        // Обработка данных (вызов метода, который выполняет "эхо")
        string receivedData = Encoding.UTF8.GetString(data);
        string responseData = Echo(receivedData);

        // Отправка ответа клиенту
        byte[] responseBytes = Encoding.UTF8.GetBytes(responseData);
        networkStream.Write(responseBytes, 0, responseBytes.Length);

        // Завершение соединения
        client.Close();
    }

    private string Echo(string input)
    {
        // Простой "эхо" алгоритм
        return input;
    }
}

public class Start
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