using MyTested.AspNetCore.Mvc;
using Xunit;
using Xunit.Categories;

using WebAPIApplication.Net.Controllers;

namespace WebAPIApplication.Net.Tests.Routing
{
    public class CustomersControllerTest
    {
        [Fact, IntegrationTest]
        public void Get_UrlCustomers_CallsCorrespondingControllerAction()
        {
            //Arrange

            //Act

            //Assert
            MyRouting
                .Configuration()
                .ShouldMap("/api/Customers")
                .To<CustomersController>(c => c.Get());
        }

        [Fact, IntegrationTest]
        public void Get_UrlCustomersWithId_CallsCorrespondingControllerAction()
        {
            //Arrange

            //Act

            //Assert
            MyRouting
                .Configuration()
                .ShouldMap("/api/Customers/5")
                .To<CustomersController>(c => c.Get(5));
        }

        [Fact, IntegrationTest]
        public void Get_UrlCustomersWithCode_CallsCorrespondingControllerAction()
        {
            //Arrange

            //Act

            //Assert
            MyRouting
                .Configuration()
                .ShouldMap("/api/Customers/code/A")
                .To<CustomersController>(c => c.Get("A"));
        }

        [Fact, IntegrationTest]
        public void Post_UrlCustomers_CallsCorrespondingControllerAction()
        {
            //Arrange

            //Act

            //Assert
            MyRouting
                .Configuration()
                .ShouldMap("/api/Customers")
                .To<CustomersController>(c => c.Post(new Entities.Customer()));
        }
    }
}
