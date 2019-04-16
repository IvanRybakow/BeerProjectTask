using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BeerProjectTask.WebUI.BreweryDbApi
{
    public interface IApiRequestOptions
    {
        string EntityName { get; }
        string Id { get; set; }
        bool AdditionalDataRequired { get; }
        IDictionary<string, string> Parameters { get; }
    }
}
