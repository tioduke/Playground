using Xunit;
using Xunit.Categories;

using WebApplication.Net.Customers.Models;

namespace WebApplication.Net.Tests
{
    public class CustomerVmControllerTest
    {
        [Fact, UnitTest]
        public void Validate_CustomerLevelColor_Success()
        {
            CustomerViewModel obj = new CustomerViewModel();
            obj.TxtName = "Shiv";
            obj.TxtAmount = "1000";
            Assert.Equal("yellow", obj.CustomerLevelColor);
        }
    }
}
