using BeerProjectTask.WebUI.Controllers;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace BeerProjectTask.WebUI.Tests
{
    public class HomeControllerTests
    {
        [Fact]
        public async void IndexActionTests()
        {
            // Arrange
            HomeController controller = new HomeController();
            var options = new DAL.BeersListSortFilterOptions()
            {
                Abv = "5",
                IsOrganic = "N",
                Name = "Beer"
            };
            var requestParams = options.Parameters;

            // Act
            ViewResult result = await controller.Index(options) as ViewResult;

            // Assert
            Assert.NotNull(result);
            Assert.Equal("5", ((DAL.BeersListSortFilterOptions)result?.ViewData["Options"]).Abv);
        }
    }
}
