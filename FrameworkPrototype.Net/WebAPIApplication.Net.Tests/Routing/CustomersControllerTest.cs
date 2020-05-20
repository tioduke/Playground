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
                .ShouldMap(req => req
                    .WithPath("/api/Customers")
                    .WithMethod(HttpMethod.Post)
                    .WithJsonBody("{}"))
                .To<CustomersController>(c => c.Post(new Entities.Customer()));
        }

        [Fact, IntegrationTest]
        public void Put_UrlCustomersWithId_CallsCorrespondingControllerAction()
        {
            //Arrange

            //Act

            //Assert
            MyRouting
                .Configuration()
                .ShouldMap(req => req
                    .WithPath("/api/Customers/5")
                    .WithMethod(HttpMethod.Put)
                    .WithJsonBody("{}"))
                .To<CustomersController>(c => c.Put(5, new Entities.Customer()));
        }

        [Fact, IntegrationTest]
        public void Delete_UrlCustomersWithId_CallsCorrespondingControllerAction()
        {
            //Arrange

            //Act

            //Assert
            MyRouting
                .Configuration()
                .ShouldMap(req => req
                    .WithPath("/api/Customers/5")
                    .WithMethod(HttpMethod.Delete))
                .To<CustomersController>(c => c.Delete(5));
        }
    }
}
