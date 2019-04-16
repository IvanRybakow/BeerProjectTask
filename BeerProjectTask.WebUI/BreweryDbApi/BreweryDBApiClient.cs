using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BeerProjectTask.WebUI.BreweryDbApi
{
    public class BreweryDBApiClient
    {
        private readonly string baseURL;
        private readonly string secretKey;
        readonly IRestClient client;

        public BreweryDBApiClient()
        {
            baseURL = @"https://sandbox-api.brewerydb.com/v2";
            secretKey = "b9ff23dceaa14402bb614ae8babab061";
            client = new RestClient(baseURL);
            client.AddDefaultParameter("key", secretKey, ParameterType.QueryString);
        }

        public async Task<T> ExecuteAsync<T>(IApiRequestOptions options) where T : new()
        {
            string url = $@"{baseURL}/{options.EntityName}/{options.Id}";
            var request = new RestRequest(url);
            if (!String.IsNullOrEmpty(options.Id)) request.RootElement = "data";
            foreach (var pair in options.Parameters) request.AddParameter(pair.Key, pair.Value, ParameterType.QueryString);
            var response = await client.ExecuteTaskAsync<T>(request);
            if (response.ErrorException != null) throw new Exception("Error retrieving response. Check inner details for more info.");

            return response.Data;
        }
    }
}
