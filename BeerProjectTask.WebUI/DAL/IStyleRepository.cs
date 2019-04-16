using BeerProjectTask.WebUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BeerProjectTask.WebUI.DAL
{
    public interface IStyleRepository
    {
        Task<IEnumerable<Style>> GetStylesAsync(StylesListSortFilterOptions options);
    }
}
