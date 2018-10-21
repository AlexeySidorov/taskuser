using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Task3.Domain.Models;

namespace Task3.RestApi
{
    public static class RestRequest
    {
        public static async Task<IList<User>> GetUsers()
        {
            var uriBuilder = new UriBuilder("https://www.dropbox.com/s/s8g63b149tnbg8x/users.json?raw=1");

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(uriBuilder.ToString());
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var response = await client.GetAsync(uriBuilder.ToString());

                if (response.IsSuccessStatusCode && response.Content != null)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    if (!string.IsNullOrEmpty(content) && !string.IsNullOrWhiteSpace(content))
                        return JsonConvert.DeserializeObject<IList<User>>(content);

                    else
                        return new List<User>();
                }
                else
                    return new List<User>();
            }
        }
    }
}
