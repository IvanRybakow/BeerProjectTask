using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BeerProjectTask.WebUI.Models
{
    public class Brewery
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Established { get; set; }
        public string Website { get; set; }
        public Labels Images { get; set; }
        public string Description { get; set; }
    }
}
