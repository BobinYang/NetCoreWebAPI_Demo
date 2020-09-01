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
            req.price = 1.00M;
            string req_str = JsonConvert.SerializeObject(req);//序列化成JSON
            Console.WriteLine($"[REQ]{req_str}");

            string result = Post(url, req_str);
            
            Console.WriteLine($"[RESP]{result}");
            AddResponse resp = JsonConvert.DeserializeObject<AddResponse>(result);//反序列化
            Console.WriteLine($"[resp.result]{resp.result}");
        }
        static string Post(string url, string req_str)
        {
            HttpClient client = new HttpClient();
            var content = new StringContent(req_str);
            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            var response = client.PostAsync(url, content);
            response.Wait();
            response.Result.EnsureSuccessStatusCode();
            var res = response.Result.Content.ReadAsStringAsync();
            res.Wait();
            return res.Result;
        }
    }
}
