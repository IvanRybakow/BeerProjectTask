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
        private readonly BreweryDBApiClient breweryDBApiClient;
        public BeerApiRepository()
        {
            breweryDBApiClient = new BreweryDBApiClient();
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
