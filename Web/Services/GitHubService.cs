using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;
using Web.Models;
using Web.ViewModels;

namespace Web.Services
{
    public static class GitHubService
    {
        private static string rootUrl = "http://api.github.com/";

        public static async Task<List<RepositoryViewModel>> GetTopRepositories(string language, int maxItems = 5)
        {
            string requestUrl = string.Format("{0}search/repositories?q=language:{1}&sort=stars&order=desc", rootUrl, language);
            HttpClient httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Add("User-Agent", "dioguima");
            var response = await httpClient.GetAsync(requestUrl);
            JObject JSONData = JObject.Parse(await response.Content.ReadAsStringAsync());
            List<RepositoryViewModel> repositories = new List<RepositoryViewModel>();

            foreach (JObject repository in JSONData.GetValue("items").ToArray())
            {
                if (repositories.Count == maxItems)
                    break;

                repositories.Add(new RepositoryViewModel()
                {
                    OriginalID = int.Parse(repository.GetValue("id").ToString()),
                    Name = repository.GetValue("name").ToString(),
                    Created = DateTime.Parse(repository.GetValue("created_at").ToString()),
                    Description = repository.GetValue("description").ToString(),
                    URL = repository.GetValue("url").ToString(),
                    Private = bool.Parse(repository.GetValue("private").ToString()),
                    Language = repository.GetValue("language").ToString(),
                    ForksCount = int.Parse(repository.GetValue("forks_count").ToString()),
                    IssuesCount = int.Parse(repository.GetValue("open_issues_count").ToString()),
                    OwnerLogin = ((JObject)repository.GetValue("owner")).GetValue("login").ToString(),
                    Stars = int.Parse(repository.GetValue("stargazers_count").ToString())
                });
            }
            return repositories;
        }

    }
}