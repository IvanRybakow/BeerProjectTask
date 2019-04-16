using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BeerProjectTask.WebUI.Models
{
    public class Beer
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Abv { get; set; }
        public string IsOrganic { get; set; }
        public Labels Labels { get; set; }
        public string Description { get; set; }
    }
}
