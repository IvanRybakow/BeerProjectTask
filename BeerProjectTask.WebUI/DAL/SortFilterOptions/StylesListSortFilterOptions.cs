using BeerProjectTask.WebUI.BreweryDbApi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BeerProjectTask.WebUI.DAL
{
    public class StylesListSortFilterOptions : IApiRequestOptions
    {
        public string EntityName => "styles";

        public string Id { get; set; }

        public bool AdditionalDataRequired => false;

        public IDictionary<string, string> Parameters => new Dictionary<string, string>();
    }
}
