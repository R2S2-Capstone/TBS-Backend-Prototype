using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TBS_Backend_Prototype.Controllers.api;
using TBS_Backend_Prototype.Models;
using TBS_Backend_Prototype.Repository.Vehicles;
using Xunit;

namespace TBS.Tests.Controllers.API
{
    public class VehiclesControllerTest
    {
        public IVehicleRepository Repository { get; set; }
        public VehiclesController Controller { get; set; }

        public VehiclesControllerTest()
        {
            Repository = new VehicleFakeRepository();
            Controller = new VehiclesController(Repository);
        }

        [Fact]
        public async Task TransportersController_GetTransportersReturnsExpectedCount()
        {
            // Arrange

            // Act
            var result = await Controller.GetVehicles();
            // Assert
            Assert.Equal(4, result.Count());
        }

        //        These id's are not found in TransporterFakeRepository so they should return null
        [Theory]
        [InlineData(100)]
        [InlineData(101)]
        [InlineData(102)]
        public async Task TransportersController_GetTransporterReturnsNotFound(int id)
        {
            // Arrange

            // Act
            var result = await Controller.GetVehicle(id);
            // Assert
            Assert.IsType<NotFoundResult>(result.Result);
        }


        //        These id's are found in TransporterFakeRepository so they should not return null
        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(3)]
        [InlineData(4)]
        public async Task TransportersController_GetTransporterReturnsTransporter(int id)
        {
            // Arrange

            // Act
            var result = await Controller.GetVehicle(id);
            // Assert
            Assert.NotNull(result.Value);
        }

        [Theory]
        [InlineData(1, 2)]
        [InlineData(2, 1)]
        [InlineData(3, 1)]
        public async Task TransportersController_PutTransportersReturnsBadRequestResultWhenIdIsNotEqual(int idOne, int idTwo)
        {
            // Arrange

            // Act
            var result = await Controller.PutVehicle(idOne, new Vehicle() { Id = idTwo });
            // Assert
            Assert.IsType<BadRequestResult>(result);
        }

        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(3)]
        [InlineData(4)]
        public async Task TransportersController_PutTransportersReturnsNoContent(int id)
        {
            // Arrange

            // Act
            var result = await Controller.PutVehicle(id, new Vehicle() { Id = id });
            // Assert
            Assert.IsType<NoContentResult>(result);
        }

        //        These id's are not found in TransporterFakeRepository so they should return null
        [Theory]
        [InlineData(100)]
        [InlineData(101)]
        [InlineData(102)]
        public async Task TransportersController_DeleteTransporterReturnsNotFound(int id)
        {
            // Arrange

            // Act
            var result = await Controller.DeleteVehicle(id);
            // Assert
            Assert.IsType<NotFoundResult>(result.Result);
        }

        //        These id's are found in TransporterFakeRepository so they should not return null
        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(3)]
        [InlineData(4)]
        public async Task TransportersController_DeleteTransporterDeletesTransporter(int id)
        {
            // Arrange

            // Act
            var result = await Controller.DeleteVehicle(id);
            // Assert
            Assert.NotNull(result.Value);
        }

        //        These id's are found in TransporterFakeRepository so they should not return null
        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(3)]
        [InlineData(4)]
        public async Task TransportersController_TransporterExistsReturnsTrue(int id)
        {
            // Arrange

            // Act
            var result = await Controller.VehicleExists(id);
            // Assert
            Assert.True(result);
        }

        //        These id's are not found in TransporterFakeRepository so they should return null
        [Theory]
        [InlineData(100)]
        [InlineData(101)]
        [InlineData(102)]
        public async Task TransportersController_TransporterExistsReturnsFalse(int id)
        {
            // Arrange

            // Act
            var result = await Controller.VehicleExists(id);
            // Assert
            Assert.False(result);
        }
    }
}
