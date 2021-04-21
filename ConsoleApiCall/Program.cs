using RestSharp;
using System;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;

namespace ApiTest
{
    class Program
    {
        static void Main()
        {
            Task<string> apiCallTask = ApiHelper.ApiCall("[pQQAGOJRk4a7RAz0dLzVPKjWsAQbOh8y]");
            string result = apiCallTask.Result;
            JObject jsonResponse = JsonConvert.DeserializeObject<JObject>(result);
            List<Article> articleList = JsonConvert.DeserializeObject<List<Article>>(jsonResponse["results"].ToString());

            foreach (Article article in articleList)
            {
                Console.WriteLine($"Section: {article.Section}");
                Console.WriteLine($"Title: {article.Title}");
                Console.WriteLine($"Abstract: {article.Abstract}");
                Console.WriteLine($"Url: {article.Url}");
                Console.WriteLine($"Byline: {article.Byline}");
                Console.WriteLine("====================");
            }
        }
    }

    class ApiHelper
    {
        public static async Task<string> ApiCall(string apiKey)
        {
            RestClient client = new RestClient("https://api.nytimes.com/svc/topstories/v2");
            RestRequest request = new RestRequest($"home.json?api-key={apiKey}", Method.GET);
            IRestResponse response = await client.ExecuteTaskAsync(request);
            return response.Content;
        }
    }
}
