using Microsoft.AspNetCore.Mvc;
using TBS_Backend_Prototype.Controllers;
using Xunit;

namespace TBS.Tests.Controllers
{
    public class HomeControllerTest
    {
        public HomeController Controller { get; set; }
        public HomeControllerTest()
        {
            Controller = new HomeController();
        }

        [Fact]
        public void HomeControllerTest_ReturnsViewObject()
        {
            // Arrange

            // Act
            var result = Controller.Index();
            // Assert
            Assert.IsType<ViewResult>(result);
        }
    }
}
