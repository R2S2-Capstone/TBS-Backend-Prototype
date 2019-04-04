using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TBS_Backend_Prototype.Controllers;
using TBS_Backend_Prototype.Models;
using TBS_Backend_Prototype.Repository.Vehicles;
using Xunit;

namespace TBS.Tests.Controllers
{
    public class VehiclesControllerTest
    {
        public IVehicleRepository Repository { get; set; }
        public VehiclesController Controller { get; set; }
        public VehiclesControllerTest()
        {
            // Arrange
            Repository = new VehicleFakeRepository();
            Controller = new VehiclesController(Repository);
        }

        [Fact]
        public async Task VehiclesController_IndexReturnsViewResult()
        {
            // Arrange

            // Act
            var result = await Controller.Index();
            // Assert
            Assert.IsType<ViewResult>(result);
        }

        [Fact]
        public async Task VehiclesController_DetailsReturnsNotFound()
        {
            // Arrange

            // Act
            var result = await Controller.Details(null);
            // Assert
            Assert.IsType<NotFoundResult>(result);
        }

        //        These id's are not found in VehicleFakeRepository so they should return null
        [Theory]
        [InlineData(100)]
        [InlineData(101)]
        [InlineData(102)]
        public async Task VehiclesController_DetailsReturnsNotFoundWhenVehicleNull(int id)
        {
            // Arrange

            // Act
            var result = await Controller.Details(id);
            // Assert
            Assert.IsType<NotFoundResult>(result);
        }

        //        These id's are found in VehicleFakeRepository so they should not return null
        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(3)]
        [InlineData(4)]
        public async Task VehiclesController_DetailsReturnsViewObject(int id)
        {
            // Arrange

            // Act
            var result = await Controller.Details(id);
            // Assert
            Assert.IsType<ViewResult>(result);
        }

        [Fact]
        public void VehiclesController_CreateReturnsViewObject()
        {
            // Arrange

            // Act
            var result = Controller.Create();
            // Assert
            Assert.IsType<ViewResult>(result);
        }

        [Fact]
        public async Task VehiclesController_EditReturnsNotFoundResultWhenIdIsNull()
        {
            // Arrange

            // Act
            var result = await Controller.Edit(null);
            // Assert
            Assert.IsType<NotFoundResult>(result);
        }

        //        These id's are not found in VehicleFakeRepository so they should return null
        [Theory]
        [InlineData(100)]
        [InlineData(101)]
        [InlineData(102)]
        public async Task VehiclesController_EditReturnsNotFoundResultWhenVehicleIsNull(int id)
        {
            // Arrange

            // Act
            var result = await Controller.Edit(id);
            // Assert
            Assert.IsType<NotFoundResult>(result);
        }

        //        These id's are found in VehicleFakeRepository so they should not return null
        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(3)]
        [InlineData(4)]
        public async Task VehiclesController_EditReturnsViewResult(int id)
        {
            // Arrange

            // Act
            var result = await Controller.Edit(id);
            // Assert
            Assert.IsType<ViewResult>(result);
        }

        [Theory]
        [InlineData(1, 2)]
        [InlineData(2, 1)]
        [InlineData(3, 1)]
        public async Task VehiclesController_EditReturnsNotFoundResultWhenIdIsNotEqual(int idOne, int idTwo)
        {
            // Arrange

            // Act
            var result = await Controller.Edit(idOne, new Vehicle() { Id = idTwo });
            // Assert
            Assert.IsType<NotFoundResult>(result);
        }

        [Fact]
        public async Task VehiclesController_EditReturnsRedirectToActionResult()
        {
            // Arrange

            // Act
            var result = await Controller.Edit(1, new Vehicle() { Id = 1 });
            // Assert
            Assert.IsType<RedirectToActionResult>(result);
        }

        [Fact]
        public async Task VehiclesController_DeleteReturnsNotFoundWhenIdIsNull()
        {
            // Arrange

            // Act
            var result = await Controller.Delete(null);
            // Assert
            Assert.IsType<NotFoundResult>(result);
        }

        //        These id's are not found in VehicleFakeRepository so they should return null
        [Theory]
        [InlineData(100)]
        [InlineData(101)]
        [InlineData(102)]
        public async Task VehiclesController_DeleteReturnsNotFoundResultWhenVehicleIsNull(int id)
        {
            // Arrange

            // Act
            var result = await Controller.Delete(id);
            // Assert
            Assert.IsType<NotFoundResult>(result);
        }

        //        These id's are found in VehicleFakeRepository so they should not return null
        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(3)]
        [InlineData(4)]
        public async Task VehiclesController_DeleteReturnsViewResult(int id)
        {
            // Arrange

            // Act
            var result = await Controller.Delete(id);
            // Assert
            Assert.IsType<ViewResult>(result);
        }


        //        These id's are found in VehicleFakeRepository so they should not return null
        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(3)]
        [InlineData(4)]
        public async Task VehiclesController_DeleteConfirmedReturnsRedirectedToAction(int id)
        {
            // Arrange

            // Act
            var result = await Controller.DeleteConfirmed(id);
            // Assert
            Assert.IsType<RedirectToActionResult>(result);
        }

        //        These id's are found in VehicleFakeRepository so they should not return null
        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(3)]
        [InlineData(4)]
        public void VehiclesController_VehicleExistsReturnsTrue(int id)
        {
            // Arrange

            // Act
            var result = Controller.VehicleExists(id);
            // Assert
            Assert.True(result);
        }

        //        These id's are not found in VehicleFakeRepository so they should return null
        [Theory]
        [InlineData(100)]
        [InlineData(101)]
        [InlineData(102)]
        public void VehiclesController_VehicleExistsReturnsFalse(int id)
        {
            // Arrange

            // Act
            var result = Controller.VehicleExists(id);
            // Assert
            Assert.False(result);
        }
    }
}
