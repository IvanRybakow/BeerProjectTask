using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BeerProjectTask.WebUI.BreweryDbApi;
using BeerProjectTask.WebUI.Models;

namespace BeerProjectTask.WebUI.DAL
{
    public class BeerApiRepository : IBeerRepository
    {
        private readonly IApiClient breweryDBApiClient;
        public BeerApiRepository(IApiClient apiClient)
        {
            breweryDBApiClient = apiClient;
        }

        public async Task<Beer> GetBeerByIdAsync(BeerSortFilterOptions options)
        {
            return await breweryDBApiClient.ExecuteAsync<Beer>(options);
        }

        public async Task<BeersListViewModel> GetBeersAsync(BeersListSortFilterOptions options)
        {
            return await breweryDBApiClient.ExecuteAsync<BeersListViewModel>(options);
        }
    }
}
