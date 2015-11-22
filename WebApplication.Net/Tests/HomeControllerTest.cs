using Microsoft.AspNet.Mvc;
using Xunit;

using WebApplication.Net.FirstMVC.Controllers;

namespace WebApplication.Net.Tests
{
    public class HomeControllerTest
    {
        [Fact]
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
