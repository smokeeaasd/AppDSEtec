using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using RestSharp;

namespace AppDSEtec.Model
{
    public class Weather
    {
        private string token;

        public Weather(string token)
        {
            this.token = token;
        }

        public async Task<object> GetWeather(string lat, string lon)
        {
            RestClient restClient = new RestClient("https://api.openweathermap.org/data/2.5");

            RestRequest request = new RestRequest("weather", Method.Get);
            request.AddParameter("lat", lat);
            request.AddParameter("lon", lon);
            request.AddParameter("appid", token);

            RestResponse response = restClient.Get(request);

            string content = response.Content;

            JObject jOBJ = JObject.Parse(content);

            return await Task.FromResult(jOBJ);
        }
    }
}