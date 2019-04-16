using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BeerProjectTask.WebUI.BreweryDbApi
{
    public interface IApiClient
    {
        Task<T> ExecuteAsync<T>(IApiRequestOptions options) where T : new();
    }
}
