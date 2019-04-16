using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BeerProjectTask.WebUI.Models
{
    public class BeersListViewModel
    {
        public int CurrentPage { get; set; }
        public int NumberOfPages { get; set; }
        public IEnumerable<Beer> Data { get; set; }
    }
}
