using RestSharp;
using System;
using System.Threading.Tasks;

namespace ApiTest
{
    class Program
    {
        static void Main()
        {
            Task<string> apiCallTask = ApiHelper.ApiCall("[pQQAGOJRk4a7RAz0dLzVPKjWsAQbOh8y]");
            string result = apiCallTask.Result;
            Console.WriteLine(result);
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
