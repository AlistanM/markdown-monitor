using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ETL
{
    internal class HttpHelper
    {
        public static string Get(string url)
        {
            HttpClient client = new HttpClient();
            using HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, url);
            using HttpResponseMessage response =  client.Send(request);
            return response.Content.ReadAsStringAsync().GetAwaiter().GetResult();
        }
    }
}
