using System.Net;
using System.Net.Http.Headers;
using System.Text;

void Get1()
{
    string uri = "https://jsonplaceholder.typicode.com/todos";

    HttpWebRequest request = WebRequest.Create(uri) as HttpWebRequest;

    request.Method = "GET";

    HttpWebResponse response = request.GetResponse() as HttpWebResponse;

    StreamReader reader = new StreamReader(response.GetResponseStream());

    Console.WriteLine(reader.ReadToEnd());
    reader.Close();
}

async void Get2()
{
    string uri = "https://news.un.org/feed/subscribe/ru/tags/un/feed/rss.xml";

    var client = new HttpClient();
    var response = client.GetAsync(uri);

    if (response.IsCompleted) { }
    else { }

    var responseContent = response.Result.Content.ReadAsStringAsync();
    Console.WriteLine(responseContent.Result);

    client.Dispose();
}

void GetWithHeaders()
{
    string uri = "https://news.un.org/feed/subscribe/ru/tags/un/feed/rss.xml";

    var client = new HttpClient();
    client.DefaultRequestHeaders.Accept.Clear();
    client.DefaultRequestHeaders.Add("MyCustomerHeader", "Custom");

    var response = client.GetAsync(uri);

    response.Wait();

    if (response.IsCompleted) { }
    else { }

    var responseContent = response.Result.Content.ReadAsStringAsync();
    Console.WriteLine(responseContent.Result);

    client.Dispose();
}

void Auth()
{
    using (var client = new HttpClient())
    {
        client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", "Bearer jshbiu");

        var result = client.GetAsync("https://httpbin.org/bearer");
        var content = result.Result.Content.ReadAsStringAsync();
        Console.WriteLine(content.Result);
    }
}

void Auth2(string username, string password)
{
    using (var client = new HttpClient())
    {

        var authToken = Encoding.UTF8.GetBytes($"{username}:{password}");
        client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(authToken));

        var result = client.GetAsync("https://httpbin.org/basic-auth/" + $"{username}/{password}");
        var content = result.Result.Content.ReadAsStringAsync();
        Console.WriteLine(content.Result);
    }
}

void GetWithTime()
{
    using (var client = new HttpClient())
    {
        //1
        //client.Timeout = TimeSpan.FromSeconds(10);

        //2
        var cts = new CancellationTokenSource();
        cts.CancelAfter(TimeSpan.FromSeconds(10));



        var result = client.GetAsync("https://jsonplaceholder.typicode.com/todos", cts.Token);

        var content = result.Result.Content.ReadAsStringAsync();
        Console.WriteLine(content.Result);
    }
}

void post()
{
    using (var client = new HttpClient())
    {
        var content = new StringContent("(\"{\\\"args\\\":\\\"John Doe\\\",\\\"data\\\":30}\", Encoding.UTF8, \"application/json\"");

        var response = client.PostAsync("https://httpbin.org/post", content);
        var responseContent = response.Result.Content.ReadAsStringAsync();

        Console.WriteLine(responseContent);

    }
}

void FtpGetDirectoryDetails()
{
    FtpWebRequest request = (FtpWebRequest)WebRequest.Create("ftp://127.0.0.1/");
    request.Method = WebRequestMethods.Ftp.ListDirectoryDetails;

    request.Credentials = new NetworkCredential("admin", "admin");

    FtpWebResponse response = (FtpWebResponse)request.GetResponse();

    Stream responseStream = response.GetResponseStream();
    StreamReader reader = new StreamReader(responseStream);
    Console.WriteLine(reader.ReadToEnd());

    Console.WriteLine($"Directory List Complete, status " + $"{response.StatusDescription}");

    reader.Close();
    response.Close();
}

void FtpDownload()
{
    FtpWebRequest request = (FtpWebRequest)WebRequest.Create("ftp://127.0.0.1/1.txt");
    request.Method = WebRequestMethods.Ftp.DownloadFile;

    request.Credentials = new NetworkCredential("admin", "admin");

    FtpWebResponse response = (FtpWebResponse)request.GetResponse();

    Stream responseStream = response.GetResponseStream();
    FileStream fs = new FileStream("myFile.txt", FileMode.Create);

    byte[] data = new byte[64];
    int size = 0;

    while ((size = responseStream.Read(data, 0, data.Length)) > 0)
    {
        fs.Write(data, 0, size);
    }
    fs.Close();
    response.Close();

    Console.WriteLine("Downloaded");
}

void FtpUpload()
{
    FtpWebRequest request = (FtpWebRequest)WebRequest.Create("ftp://127.0.0.1/1.txt");
    request.Method = WebRequestMethods.Ftp.UploadFile;

    request.Credentials = new NetworkCredential("admin", "admin");

    byte[] fileContent;

    using (StreamReader sr = new StreamReader("file.txt"))
    {
        fileContent = Encoding.UTF8.GetBytes(sr.ReadToEnd());
    }


    using (Stream sw = request.GetRequestStream())
    {
        sw.Write(fileContent, 0, fileContent.Length);
    }

    request.GetResponse();

    Console.WriteLine("Uploaded");
}

void FtpDelete()
{
    FtpWebRequest request = (FtpWebRequest)WebRequest.Create("ftp://127.0.0.1/1.txt");
    request.Method = WebRequestMethods.Ftp.DeleteFile;

    request.Credentials = new NetworkCredential("admin", "admin");

    byte[] fileContent;

    using (StreamReader sr = new StreamReader("file.txt"))
    {
        fileContent = Encoding.UTF8.GetBytes(sr.ReadToEnd());
    }


    using (Stream sw = request.GetRequestStream())
    {
        sw.Write(fileContent, 0, fileContent.Length);
    }

    request.GetResponse();

    Console.WriteLine("Deleted");
}