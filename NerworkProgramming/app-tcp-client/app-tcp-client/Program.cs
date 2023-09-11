using System.Net;
using System.Net.Sockets;
using System.Text;

try
{
    IPAddress address = IPAddress.Parse("127.0.0.1");
    IPEndPoint endPoint = new IPEndPoint(address, 9595);

    #region Top 3 creating TCP client
    //Creating TCP client
    //1) TcpClient client = new TcpClient("127.0.0.1", 9595);

    //2)
    //TcpClient client = new TcpClient();
    //client.Connect("127.0.0.1", 9595);
    //client.Connect(endPoint);

    //3)
    TcpClient client = new TcpClient(AddressFamily.InterNetwork);
    IPAddress[] iPAddresses = Dns.GetHostAddresses("127.0.0.1");
    client.Connect(iPAddresses, 9595);
    #endregion

    //Will the connection remain open after the socket is closed, and for how long
    client.LingerState = new LingerOption(false, 0);

    //Settings to collect full data package 
    client.NoDelay = true;

    #region Comments
    //Set size an income package
    //client.ReceiveBufferSize = 1024;

    //Set size an outcome package
    //client.SendBufferSize = 1024;

    //Set ms time for refuce connection
    //client.ReceiveTimeout = 10000;

    //Set ms await for send package
    //client.SendTimeout = 10000;
    #endregion

    Console.Write("-> ");

    string? message = Console.ReadLine();

    //translate message to bytes
    byte[] data = Encoding.UTF8.GetBytes(message);

    //Get trhead to read and write
    NetworkStream stream = client.GetStream();

    //Post message to client
    stream.Write(data, 0, data.Length);
    Console.WriteLine();

    //Getting response from server
    data = new byte[256];
    string responseData = "";

    //Reading first package server response
    int bytes = stream.Read(data, 0, data.Length);
    responseData = Encoding.UTF8.GetString(data, 0, bytes);
    Console.WriteLine("-> {0}", responseData);

    //Close all
    stream.Close();
    client.Close();
}
catch (SocketException se)
{
    //Only socket exeptions
    Console.WriteLine(se.Message);
}
catch (Exception ex)
{
    //All exeptions
    Console.WriteLine(ex.Message);
}