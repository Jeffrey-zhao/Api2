using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            HttpClient httpClient1 = new HttpClient();
            HttpClient httpClient2 = new HttpClient();
            HttpClient httpClient3 = new HttpClient();
            HttpClient httpClient4 = new HttpClient();

            httpClient3.DefaultRequestHeaders.Add("X-HTTP-Method-Override", "PUT");
            httpClient4.DefaultRequestHeaders.Add("X-HTTP-Method-Override", "Delete");
            Console.WriteLine($"{"Method",-7}{"X-HTTP-Method-Override",-24}{"Action",-6}");

            InvokeWebApi(httpClient1, HttpMethod.Get);
            InvokeWebApi(httpClient2, HttpMethod.Post);
            InvokeWebApi(httpClient3, HttpMethod.Put);
            InvokeWebApi(httpClient4, HttpMethod.Delete);
            Console.Read();
        }

        private static async void InvokeWebApi(HttpClient httpClient, HttpMethod method)
        {
            string requestUri = "http://localhost:60980/api/demo";
            HttpRequestMessage request = new HttpRequestMessage(method, requestUri);
            HttpResponseMessage response = await httpClient.SendAsync(request);
            IEnumerable<string> methodsOverride;
            httpClient.DefaultRequestHeaders.TryGetValues("X-HTTP-Method-Override", out methodsOverride);
            string actionName = response.Content.ReadAsStringAsync().Result;
            string methodOverride = methodsOverride == null ? "N/A" : methodsOverride.First();

            Console.WriteLine($"{method,-7}{methodOverride,-24}{actionName,-6}");
        }
    }
}
