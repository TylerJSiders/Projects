using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json;

namespace Joke
{
    class JokeWeb
    {
        private string url = "https://official-joke-api.appspot.com/";
        
        public async Task<Joke> GetRandomJoke()
        {
            Joke RandomJoke = new Joke();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(url);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage res = await client.GetAsync("random_joke");

                if (res.IsSuccessStatusCode)
                {
                    var response = res.Content.ReadAsStringAsync().Result;

                    RandomJoke = JsonConvert.DeserializeObject<Joke>(response);
                }
            }
            return RandomJoke;
        }
    }
}
