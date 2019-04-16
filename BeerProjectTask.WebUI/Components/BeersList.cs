using BeerProjectTask.WebUI.DAL;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BeerProjectTask.WebUI.Components
{
    public class BeersList : ViewComponent
    {
        private readonly IBeerRepository beerRepository;
        public BeersList(IBeerRepository beerRepository)
        {
            this.beerRepository = beerRepository;
        }
        public async Task<IViewComponentResult> InvokeAsync(BeersListSortFilterOptions options)
        {
            var data = await beerRepository.GetBeersAsync(options);
            ViewBag.Options = options;
            if (data.Data == null) return View("NoResults");
            return View(data);
        }
    }
}
