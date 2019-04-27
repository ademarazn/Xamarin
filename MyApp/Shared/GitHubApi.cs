using System;
using System.Collections.Generic;
using System.Net.Http;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Schema;
using System.Threading.Tasks;

namespace Shared
{
    public class GitHubApi
    {
        public async Task<List<string>> GetAsync(string user)
        {
            string url = string.Format("https://api.github.com/users/{0}/repos", user);

            var client = new HttpClient();
            client.DefaultRequestHeaders.Add("User-Agent", "Other");

            string content = null;
            try {
                var response = await client.GetAsync(url);
                content = await response.Content.ReadAsStringAsync();
            } catch (TimeoutException e) {
                System.Diagnostics.Debug.WriteLine(e.Message);
            }

            if (!content.StartsWith("[") || content == null) {
                content = "[]";
            }
            var json = JArray.Parse(content);

            var repositories = new List<string>();
            foreach (var item in json)
            {
                var repository = item.Value<string>("full_name");
                repositories.Add(repository);
            }

            return repositories;
        }
    }
}
