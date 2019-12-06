using Microsoft.AspNetCore.Mvc;
using Xunit;
using Xunit.Categories;

using WebApplication.Net.FirstMVC.Controllers;

namespace WebApplication.Net.Tests
{
    public class HomeControllerTest
    {
        [Fact, UnitTest]
        public void Index_Success()
        {
            // Arrange
            HomeController controller = new HomeController();

            // Act
            ViewResult result = controller.Index() as ViewResult;

            // Assert
            Assert.Equal("HelloView", result.ViewName);
        }
    }
}
