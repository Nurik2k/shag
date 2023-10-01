using System;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;

public class FileDownloader
{
    public async Task DownloadFileAsync(string url, string outputPath)
    {
        using (var httpClient = new HttpClient())
        {
            var response = await httpClient.GetAsync(url);
            if (response.IsSuccessStatusCode)
            {
                using (var stream = await response.Content.ReadAsStreamAsync())
                using (var fileStream = File.Create(outputPath))
                {
                    await stream.CopyToAsync(fileStream);
                }
            }
            else
            {
                throw new Exception($"Failed to download file. Status code: {response.StatusCode}");
            }
        }
    }
}
