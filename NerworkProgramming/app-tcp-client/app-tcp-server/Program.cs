using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Text;

class Main
{
    static List<PortInfo> GetOpenPort()
    {
        IPGlobalProperties properties = IPGlobalProperties.GetIPGlobalProperties();
        IPEndPoint[] topEndPoints = properties.GetActiveTcpListeners();
        TcpConnectionInformation[] tcpConnectionInformation = properties.GetActiveTcpConnections();

        var data = tcpConnectionInformation.Select(s => new PortInfo(
            s.LocalEndPoint.Port,
            String.Format("{0}:{1}", s.LocalEndPoint.Address, s.LocalEndPoint.Port),
            String.Format("{0}:{1}", s.RemoteEndPoint.Address, s.RemoteEndPoint.Port),
            s.State.ToString()
            )).ToList();

        return data;
    }

    public void Server()
    {

        List<PortInfo> ports = GetOpenPort();
        foreach (PortInfo item in ports)
        {
            Console.WriteLine("Post: {0} - {1}", item.PortNumber, item.State);
        }
        return;

        #region TcpListener
        TcpListener server = null;

        try
        {
            //Ping myping = new Ping();
            //PingReply reply = myping.Send("192.168.111.187", 9595);
            //Console.WriteLine("Status: {0}\nTime: {0}\nAddress: {0}", reply.Status, reply.RoundtripTime.ToString(), reply.Address);

            IPAddress localAdr = IPAddress.Parse("127.0.0.1");
            NetworkStream stream = null;

            server = new TcpListener(localAdr, 9595);
            //Connect with EndPoint and waiting transfering income tryes
            server.Start();

            byte[] bytes = new byte[1024];
            string data = "";

            while (true)
            {
                //Get waiting respose
                TcpClient client = server.AcceptTcpClient();
                Console.WriteLine("Connected.");

                stream = client.GetStream();
                int i = 0;
                while ((i = stream.Read(bytes, 0, bytes.Length)) != 0)
                {
                    data = Encoding.UTF8.GetString(bytes, 0, i);
                    Console.WriteLine("-> {0}", data);

                    data = "Messge Received!";
                    byte[] receiveData = Encoding.UTF8.GetBytes(data);
                    stream.Write(receiveData, 0, receiveData.Length);
                }

                stream.Close();
                client.Close();
            }
        }
        catch (Exception)
        {

            throw;
        }
        finally
        {
            server.Stop();
        }
        #endregion

    }
}
public class PortInfo
{
    public int PortNumber { get; set; }
    public string Local { get; set; }
    public string Remote { get; set; }
    public string State { get; set; }

    public PortInfo(int portNumber, string local, string remote, string state)
    {
        PortNumber = portNumber;
        Local = local;
        Remote = remote;
        State = state;
    }
}
