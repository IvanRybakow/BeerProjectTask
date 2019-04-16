using BeerProjectTask.WebUI.BreweryDbApi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BeerProjectTask.WebUI.DAL
{
    public class BeerSortFilterOptions : IApiRequestOptions
    {
        public string EntityName => "beer";

        public string Id { get; set; }

        public IDictionary<string, string> Parameters =>
            new Dictionary<string, string>()
            {
                {"withBreweries", "Y" }
            };

        public bool AdditionalDataRequired => false;
    }
}
