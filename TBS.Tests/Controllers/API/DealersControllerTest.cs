using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TBS_Backend_Prototype.Controllers.api;
using TBS_Backend_Prototype.Models;
using TBS_Backend_Prototype.Repository.Dealers;
using Xunit;

namespace TBS.Tests.Controllers.API
{
    public class DealersControllerTest
    {
        public IDealerRepository Repository { get; set; }
        public DealersController Controller { get; set; }

        public DealersControllerTest()
        {
            Repository = new DealerFakeRepository();
            Controller = new DealersController(Repository);
        }

        [Fact]
        public async Task DealersController_GetDealersReturnsExpectedCount()
        {
            // Arrange

            // Act
            var result = await Controller.GetDealers();
            // Assert
            Assert.Equal(4, result.Count());
        }

        //        These id's are not found in DealerFakeRepository so they should return null
        [Theory]
        [InlineData(100)]
        [InlineData(101)]
        [InlineData(102)]
        public async Task DealersController_GetDealerReturnsNotFound(int id)
        {
            // Arrange

            // Act
            var result = await Controller.GetDealer(id);
            // Assert
            Assert.IsType<NotFoundResult>(result.Result);
        }


        //        These id's are found in DealerFakeRepository so they should not return null
        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(3)]
        [InlineData(4)]
        public async Task DealersController_GetDealerReturnsDealer(int id)
        {
            // Arrange

            // Act
            var result = await Controller.GetDealer(id);
            // Assert
            Assert.NotNull(result.Value);
        }

        [Theory]
        [InlineData(1, 2)]
        [InlineData(2, 1)]
        [InlineData(3, 1)]
        public async Task DealersController_PutDealersReturnsBadRequestResultWhenIdIsNotEqual(int idOne, int idTwo)
        {
            // Arrange

            // Act
            var result = await Controller.PutDealer(idOne, new Dealer() { Id = idTwo });
            // Assert
            Assert.IsType<BadRequestResult>(result);
        }

        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(3)]
        [InlineData(4)]
        public async Task DealersController_PutDealersReturnsNoContent(int id)
        {
            // Arrange

            // Act
            var result = await Controller.PutDealer(id, new Dealer() { Id = id });
            // Assert
            Assert.IsType<NoContentResult>(result);
        }

        //        These id's are not found in DealerFakeRepository so they should return null
        [Theory]
        [InlineData(100)]
        [InlineData(101)]
        [InlineData(102)]
        public async Task DealersController_DeleteDealerReturnsNotFound(int id)
        {
            // Arrange

            // Act
            var result = await Controller.DeleteDealer(id);
            // Assert
            Assert.IsType<NotFoundResult>(result.Result);
        }

        //        These id's are found in DealerFakeRepository so they should not return null
        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(3)]
        [InlineData(4)]
        public async Task DealersController_DeleteDealerDeletesDealer(int id)
        {
            // Arrange

            // Act
            var result = await Controller.DeleteDealer(id);
            // Assert
            Assert.NotNull(result.Value);
        }

        //        These id's are found in DealerFakeRepository so they should not return null
        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(3)]
        [InlineData(4)]
        public async Task DealersController_DealerExistsReturnsTrue(int id)
        {
            // Arrange

            // Act
            var result = await Controller.DealerExistsAsync(id);
            // Assert
            Assert.True(result);
        }

        //        These id's are not found in DealerFakeRepository so they should return null
        [Theory]
        [InlineData(100)]
        [InlineData(101)]
        [InlineData(102)]
        public async Task DealersController_DealerExistsReturnsFalse(int id)
        {
            // Arrange

            // Act
            var result = await Controller.DealerExistsAsync(id);
            // Assert
            Assert.False(result);
        }
    }
}
