using BeerProjectTask.WebUI.DAL;
using BeerProjectTask.WebUI.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BeerProjectTask.WebUI.Components
{
    public class BeerDetails : ViewComponent
    {
        private readonly IBeerRepository beerRepository;
        public BeerDetails(IBeerRepository beerRepository)
        {
            this.beerRepository = beerRepository;
        }
        public async Task<IViewComponentResult> InvokeAsync(BeerSortFilterOptions options)
        {
            Beer beerDetails = await beerRepository.GetBeerByIdAsync(options);
            return View(beerDetails);
        }
    }
}
