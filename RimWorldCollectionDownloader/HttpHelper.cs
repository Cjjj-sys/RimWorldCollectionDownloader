using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace RimWorldCollectionDownloader
{
    internal class HttpHelper
    {
        public static async Task<HttpResponseMessage> PostAsync(string url, Dictionary<string, string> content)
        {
            using (var httpClient = new HttpClient())
            {
                var httpContent = new FormUrlEncodedContent(content);
                return await httpClient.PostAsync(url, httpContent);
            }
        }

        public static async Task DownloadFileAsync(string url, string filePath)
        {
            using (var httpClient = new HttpClient())
            {
                var bytes = await httpClient.GetByteArrayAsync(url);
                await File.WriteAllBytesAsync(filePath, bytes);
            }
        }
    }
}
