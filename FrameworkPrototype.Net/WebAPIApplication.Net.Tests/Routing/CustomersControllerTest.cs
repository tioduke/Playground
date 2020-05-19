using MyTested.AspNetCore.Mvc;
using Xunit;
using Xunit.Categories;

using WebAPIApplication.Net.Controllers;

namespace WebAPIApplication.Net.Tests.Routing
{
    public class CustomersControllerTest
    {
        [Fact, SystemTest]
        public void Get_ValidRoute_CallsCorrespondingControllerAction()
        {
            //Arrange

            //Act

            //Assert
            MyRouting
                .Configuration()
                .ShouldMap("/api/Customers/5")
                .To<CustomersController>(c => c.Get(5));
        }
    }
}
