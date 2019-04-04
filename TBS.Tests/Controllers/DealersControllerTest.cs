using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TBS_Backend_Prototype.Controllers;
using TBS_Backend_Prototype.Models;
using TBS_Backend_Prototype.Repository.Dealers;
using Xunit;

namespace TBS.Tests.Controllers
{
    public class DealersControllerTest
    {
        public IDealerRepository Repository { get; set; }
        public DealersController Controller { get; set; }
        public DealersControllerTest()
        {
            // Arrange
            Repository = new DealerFakeRepository();
            Controller = new DealersController(Repository);
        }

        [Fact]
        public async Task DealersController_IndexReturnsViewResult()
        {
            // Arrange

            // Act
            var result = await Controller.Index();
            // Assert
            Assert.IsType<ViewResult>(result);
        }

        [Fact]
        public async Task DealersController_DetailsReturnsNotFound()
        {
            // Arrange

            // Act
            var result = await Controller.Details(null);
            // Assert
            Assert.IsType<NotFoundResult>(result);
        }

//        These id's are not found in DealerFakeRepository so they should return null
        [Theory]
        [InlineData(100)]
        [InlineData(101)]
        [InlineData(102)]
        public async Task DealersController_DetailsReturnsNotFoundWhenDealerNull(int id)
        {
            // Arrange

            // Act
            var result = await Controller.Details(id);
            // Assert
            Assert.IsType<NotFoundResult>(result);
        }

//        These id's are found in DealerFakeRepository so they should not return null
        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(3)]
        [InlineData(4)]
        public async Task DealersController_DetailsReturnsViewObject(int id)
        {
            // Arrange

            // Act
            var result = await Controller.Details(id);
            // Assert
            Assert.IsType<ViewResult>(result);
        }

        [Fact]
        public void DealersController_CreateReturnsViewObject()
        {
            // Arrange

            // Act
            var result = Controller.Create();
            // Assert
            Assert.IsType<ViewResult>(result);
        }

        [Fact]
        public async Task DealersController_EditReturnsNotFoundResultWhenIdIsNull()
        {
            // Arrange

            // Act
            var result = await Controller.Edit(null);
            // Assert
            Assert.IsType<NotFoundResult>(result);
        }

        //        These id's are not found in DealerFakeRepository so they should return null
        [Theory]
        [InlineData(100)]
        [InlineData(101)]
        [InlineData(102)]
        public async Task DealersController_EditReturnsNotFoundResultWhenDealerIsNull(int id)
        {
            // Arrange

            // Act
            var result = await Controller.Edit(id);
            // Assert
            Assert.IsType<NotFoundResult>(result);
        }

        //        These id's are found in DealerFakeRepository so they should not return null
        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(3)]
        [InlineData(4)]
        public async Task DealersController_EditReturnsViewResult(int id)
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
        public async Task DealersController_EditReturnsNotFoundResultWhenIdIsNotEqual(int idOne, int idTwo)
        {
            // Arrange

            // Act
            var result = await Controller.Edit(idOne, new Dealer() { Id = idTwo });
            // Assert
            Assert.IsType<NotFoundResult>(result);
        }

        [Fact]
        public async Task DealersController_EditReturnsRedirectToActionResult()
        {
            // Arrange

            // Act
            var result = await Controller.Edit(1, new Dealer() { Id = 1 });
            // Assert
            Assert.IsType<RedirectToActionResult>(result);
        }

        [Fact]
        public async Task DealersController_DeleteReturnsNotFoundWhenIdIsNull()
        {
            // Arrange

            // Act
            var result = await Controller.Delete(null);
            // Assert
            Assert.IsType<NotFoundResult>(result);
        }

        //        These id's are not found in DealerFakeRepository so they should return null
        [Theory]
        [InlineData(100)]
        [InlineData(101)]
        [InlineData(102)]
        public async Task DealersController_DeleteReturnsNotFoundResultWhenDealerIsNull(int id)
        {
            // Arrange

            // Act
            var result = await Controller.Delete(id);
            // Assert
            Assert.IsType<NotFoundResult>(result);
        }

        //        These id's are found in DealerFakeRepository so they should not return null
        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(3)]
        [InlineData(4)]
        public async Task DealersController_DeleteReturnsViewResult(int id)
        {
            // Arrange

            // Act
            var result = await Controller.Delete(id);
            // Assert
            Assert.IsType<ViewResult>(result);
        }


        //        These id's are found in DealerFakeRepository so they should not return null
        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(3)]
        [InlineData(4)]
        public async Task DealersController_DeleteConfirmedReturnsRedirectedToAction(int id)
        {
            // Arrange

            // Act
            var result = await Controller.DeleteConfirmed(id);
            // Assert
            Assert.IsType<RedirectToActionResult>(result);
        }

        //        These id's are found in DealerFakeRepository so they should not return null
        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(3)]
        [InlineData(4)]
        public void DealersController_DealerExistsReturnsTrue(int id)
        {
            // Arrange

            // Act
            var result = Controller.DealerExists(id);
            // Assert
            Assert.True(result);
        }

        //        These id's are not found in DealerFakeRepository so they should return null
        [Theory]
        [InlineData(100)]
        [InlineData(101)]
        [InlineData(102)]
        public void DealersController_DealerExistsReturnsFalse(int id)
        {
            // Arrange

            // Act
            var result = Controller.DealerExists(id);
            // Assert
            Assert.False(result);
        }
    }
}