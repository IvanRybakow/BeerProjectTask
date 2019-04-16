using BeerProjectTask.WebUI.DAL;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BeerProjectTask.WebUI.Components
{
    public class BeerFilter : ViewComponent
    {
        private readonly IStyleRepository styleRepository;
        public BeerFilter(IStyleRepository repository)
        {
            styleRepository = repository;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var styles = await styleRepository.GetStylesAsync(new StylesListSortFilterOptions());
            return View(styles);
        }
    }
}
