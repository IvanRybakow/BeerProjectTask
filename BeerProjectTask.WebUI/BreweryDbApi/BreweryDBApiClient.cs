using Microsoft.Extensions.Options;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BeerProjectTask.WebUI.BreweryDbApi
{
    public class BreweryDBApiClient : IApiClient
    {
        private readonly ApiSettings settings;
        readonly IRestClient client;

        public BreweryDBApiClient(IOptions<ApiSettings> settings)
        {
            this.settings = settings.Value;
            client = new RestClient(this.settings.Url);
            client.AddDefaultParameter("key", this.settings.SecretKey, ParameterType.QueryString);
        }

        public async Task<T> ExecuteAsync<T>(IApiRequestOptions options) where T : new()
        {
            string url = $@"{settings.Url}/{options.EntityName}/{options.Id}";
            var request = new RestRequest(url);
            if (!options.AdditionalDataRequired) request.RootElement = "data";
            foreach (var pair in options.Parameters) request.AddParameter(pair.Key, pair.Value, ParameterType.QueryString);
            var response = await client.ExecuteTaskAsync<T>(request);
            if (response.ErrorException != null) throw new Exception("Error retrieving response. Check inner details for more info.");

            return response.Data;
        }
    }
}
