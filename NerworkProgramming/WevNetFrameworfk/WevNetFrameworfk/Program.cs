using System.Net;
using System.Text;

static void Exmpl01()
{
    WebClient client = new WebClient();
    Stream data = client.OpenRead("http://www.google.com");

    StreamReader reader = new StreamReader(data);
    string str = reader.ReadToEnd();

    Console.WriteLine(str);
    data.Close();
    reader.Close();
}

static void Exmpl02()
{
    string url = "";
    string postData = "Hello";

    byte[] postArray = Encoding.UTF8.GetBytes(postData);

    WebClient client = new WebClient();
    using (Stream postStream = client.OpenWrite(url))
    {
        postStream.Write(postArray, 0, postArray.Length);
    }
}

static void Exmpl03()
{
    string url = "";
    string postData = "Hello";

    byte[] postArray = Encoding.UTF8.GetBytes(postData);

    WebClient client = new WebClient();
    client.Headers.Add("Content-Type", "application/x-www-form-urlencoded");
    client.UploadData(url, postArray);
}

static void Exmpl04()
{
    string url = "";
    string fileName = "Hello";

    WebClient client = new WebClient();
    client.DownloadFile(url, fileName);
}

static void Exmpl05()
{
    string url = "";
    WebClient client = new WebClient();

    byte[] myData = client.DownloadData(url);

    string download = Encoding.UTF8.GetString(myData);

    using (MemoryStream memstr = new MemoryStream(myData))
    {

    }

}

static void Exmpl06()
{
    WebRequest request = WebRequest.Create("URL");
    request.Credentials = CredentialCache.DefaultCredentials;

    try
    {
        request.Timeout = 1000;
        request.Method = "POST";
        request.Headers.Add("");
        WebResponse response = request.GetResponse();
    }
    catch (Exception)
    {

        throw;
    }
}

static void Exmpl07()
{
    WebRequest request = WebRequest.Create("URL");
    request.Credentials = CredentialCache.DefaultCredentials;

    string data = "Test";
    byte[] myArray = Encoding.UTF8.GetBytes(data);
    request.ContentType = "application/x-www-form-";
    request.ContentLength = myArray.Length;

    try
    {
        WebResponse response = request.GetResponse();
        using (Stream stream = response.GetResponseStream())
        {
            using (StreamReader reader = new StreamReader(stream))
            {
                Console.WriteLine(reader.ReadToEnd());
            }
        }
        response.Close();
    }
    catch (WebException)
    {

    }
    catch (Exception ex)
    {

    }
    finally
    {

    }
}


