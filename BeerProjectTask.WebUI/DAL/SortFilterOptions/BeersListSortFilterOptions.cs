using BeerProjectTask.WebUI.BreweryDbApi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BeerProjectTask.WebUI.DAL
{
    public class BeersListSortFilterOptions : IApiRequestOptions
    {
        public string Name { get; set; } = "";
        public string P { get; set; } = "1";
        public string Abv { get; set; } = "";
        public string IsOrganic { get; set; } = "";
        public string Order { get; set; } = "";

        public string EntityName => "beers";

        public string Id { get; set; } = "";

        public IDictionary<string, string> Parameters =>
            new Dictionary<string, string> {
                {"name", Name },
                {"p", P },
                {"abv", Abv },
                {"isOrganic", IsOrganic },
                {"order", Order },
                {"hasLabels", "Y" }
            };

        public bool AdditionalDataRequired => true;
    }
}
