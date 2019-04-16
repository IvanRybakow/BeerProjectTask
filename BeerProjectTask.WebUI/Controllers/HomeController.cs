using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BeerProjectTask.WebUI.Models;
using BeerProjectTask.WebUI.DAL;

namespace BeerProjectTask.WebUI.Controllers
{
    public class HomeController : Controller
    {
        public async Task<IActionResult> Index(BeersListSortFilterOptions options)
        {
            ViewBag.Options = options;
            return await Task.Factory.StartNew(() => View());
        }

        public async Task<IActionResult> Details(BeerSortFilterOptions options)
        {
            ViewBag.Options = options;
            return await Task.Factory.StartNew(() => View());
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
