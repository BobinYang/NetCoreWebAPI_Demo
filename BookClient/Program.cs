using System;
using Newtonsoft.Json;
using BookClient.Models;
using System.Net.Http;
using System.Net.Http.Headers;

namespace BookClient
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            string url = "http://localhost:5000/book/values";
            AddRequest req = new AddRequest();
            req.ISBN = "2";
            req.name = ".NET Core从入门到入土";
            req.authors = null;
            req.price = 1.888M;
            string req_str = JsonConvert.SerializeObject(req);
            Console.WriteLine($"[REQ]{req_str}");

            HttpClient httpClient = new HttpClient();
            var content = new StringContent(req_str);
            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            var tokenResponse = httpClient.PostAsync(url, content);
            tokenResponse.Wait();
            tokenResponse.Result.EnsureSuccessStatusCode();
            var res = tokenResponse.Result.Content.ReadAsStringAsync();
            res.Wait();
            Console.WriteLine($"[RESP]{ res.Result}");

            AddResponse resp = JsonConvert.DeserializeObject<AddResponse>(res.Result);
            Console.WriteLine($"[resp.result]{resp.result}");
        }
    }
}
