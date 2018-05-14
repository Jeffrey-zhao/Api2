using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;

namespace WebMvc.Models
{
    public class HttpClientHelper
    {
        static HttpClient client = new HttpClient();
        public static string Get(string url)
        {
            var respone=client.GetAsync(url).Result;
            var message = respone.Content.ReadAsStringAsync().Result;
            return message;
        }
    }
}