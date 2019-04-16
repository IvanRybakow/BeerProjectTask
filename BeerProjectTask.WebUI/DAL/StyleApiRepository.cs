using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BeerProjectTask.WebUI.BreweryDbApi;
using BeerProjectTask.WebUI.Models;

namespace BeerProjectTask.WebUI.DAL
{
    public class StyleApiRepository : IStyleRepository
    {
        private readonly IApiClient breweryDBApiClient;
        public StyleApiRepository(IApiClient apiClient)
        {
            breweryDBApiClient = apiClient;
        }
        public async Task<IEnumerable<Style>> GetStylesAsync(StylesListSortFilterOptions options)
        {
            return await breweryDBApiClient.ExecuteAsync<List<Style>>(options);
        }
    }
}
