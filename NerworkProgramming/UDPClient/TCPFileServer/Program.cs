using Newtonsoft.Json;
using System.Data;
using System.Net;
using System.Net.Sockets;
using System.Text;

void main()
{
    TcpListener listener = null;
    try
    {
        listener = new TcpListener(IPAddress.Any, 8088);
        listener.Start();
    }
    catch (Exception ex)
    {

        Console.WriteLine(ex.Message);
    }

    byte[] bytes = new byte[1024];
    int recBytes = 0;

    TcpClient client = null;
    NetworkStream stream = null;

    try
    {
        client = listener.AcceptTcpClient();
        stream = client.GetStream();
        Console.WriteLine("Connect to client");

        stream.Read(bytes, 0, bytes.Length);
        string message = Encoding.UTF8.GetString(bytes);

        FileInfo fileInfo = JsonConvert.DeserializeObject<FileInfo>(message);

        string path = @"D:\shag\NerworkProgramming" + fileInfo.FileName;


        using (FileStream fs = new FileStream("", FileMode.OpenOrCreate, FileAccess.Write))
        {
            fs.Write(fileInfo.File, 0, fileInfo.File.Length);
        }
    }
    catch (Exception)
    {

        throw;
    }
    finally
    {
        stream.Close();
        client.Close();
    }
}
main();

public class FileInfo
{
    public string? FileName { get; set; }
    public string? Exctension { get; set; }
    public byte[]? File { get; set; }
}
