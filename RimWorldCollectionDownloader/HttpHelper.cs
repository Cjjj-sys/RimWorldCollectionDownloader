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
        public static Task<HttpResponseMessage> PostAsync(string url, Dictionary<string, string> content)
        {
            using (var httpClient = new HttpClient())
            {
                var httpContent = new FormUrlEncodedContent(content);
                return httpClient.PostAsync(url, httpContent);
            }
        }
    }
}
