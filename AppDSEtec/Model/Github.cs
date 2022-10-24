using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using RestSharp;

namespace AppDSEtec.Model
{
    public class Github
    {
        
        public static async Task<object> GetUser(string user)
        {
            RestClient restClient = new RestClient("https://api.github.com/users");

            RestRequest request = new RestRequest(user, Method.Get);

            RestResponse response = restClient.Get(request);

            string content = response.Content;

            JObject jOBJ = JObject.Parse(content);

            return await Task.FromResult(jOBJ);
        }
    }

    public class GithubUser
    {
        public string User { get; set; }
        public string Followers { get; set; }
        public string Following { get; set; }
        public string PublicRepos { get; set; }
        public string AvatarUrl { get; set; }
    }
}