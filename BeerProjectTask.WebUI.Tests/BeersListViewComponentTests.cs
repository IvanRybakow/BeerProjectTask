using BeerProjectTask.WebUI.Components;
using BeerProjectTask.WebUI.DAL;
using BeerProjectTask.WebUI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewComponents;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace BeerProjectTask.WebUI.Tests
{
    public class BeersListViewComponentTests
    {
        [Fact]
        public async void InvokeAsyncReturnsAllProductsWithDefaultOptions()
        {
            //Arrange
            var options = new BeersListSortFilterOptions();
            var mock = new Mock<IBeerRepository>();
            mock.Setup(repo => repo.GetBeersAsync(options)).Returns(Task.Factory.StartNew(() => GetTestBeersListViewModel()));
            var beerListVC = new BeersList(mock.Object);

            //Act
            var result = await beerListVC.InvokeAsync(options);

            //Assert
            var viewResult = Assert.IsType<ViewViewComponentResult>(result);
            var model = Assert.IsAssignableFrom<BeersListViewModel>(viewResult.ViewData.Model);
            var toCompare = GetTestBeersListViewModel().Data.Count();
            Assert.Equal(toCompare, model.Data.Count());

        }

        [Fact]
        public async void InvokeAsyncReturnsAllProductsWithNonDefaultOptions()
        {
            //Arrange
            var options = new BeersListSortFilterOptions() { Abv = "1", IsOrganic = "Y" };
            var mock = new Mock<IBeerRepository>();
            var data = GetTestBeersListViewModel();
            data.Data = data.Data.Where(x => x.Abv == options.Abv && x.IsOrganic == "Y").ToList();
            mock.Setup(repo => repo.GetBeersAsync(options)).Returns(Task.Factory.StartNew(() => data));
            var beerListVC = new BeersList(mock.Object);

            //Act
            var result = await beerListVC.InvokeAsync(options);

            //Assert
            var viewResult = Assert.IsType<ViewViewComponentResult>(result);
            var model = Assert.IsAssignableFrom<BeersListViewModel>(viewResult.ViewData.Model);
            Assert.Equal(data.Data.Count(), model.Data.Count());

        }

        private BeersListViewModel GetTestBeersListViewModel()
        {
            return new BeersListViewModel()
            {
                CurrentPage = 1,
                NumberOfPages = 2,
                Data = new List<Beer>()
                {
                    new Beer(){ Abv = "1", IsOrganic = "N", Name = "name1", Ibu = "2" },
                    new Beer(){ Abv = "1", IsOrganic = "Y", Name = "name2", Ibu = "2" },
                    new Beer(){ Abv = "1", IsOrganic = "Y", Name = "name3", Ibu = "2" },
                    new Beer(){ Abv = "1", IsOrganic = "Y", Name = "name4", Ibu = "2" },
                    new Beer(){ Abv = "1", IsOrganic = "Y", Name = "name5", Ibu = "2" },
                    new Beer(){ Abv = "2", IsOrganic = "Y", Name = "name6", Ibu = "2" },
                    new Beer(){ Abv = "3", IsOrganic = "Y", Name = "name7", Ibu = "3" },
                    new Beer(){ Abv = "3", IsOrganic = "N", Name = "name8", Ibu = "4" }
                }
            };
        }
    }
}
