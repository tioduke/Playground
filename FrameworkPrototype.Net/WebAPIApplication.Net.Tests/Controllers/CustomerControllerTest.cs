using System;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;
using Xunit.Categories;

using WebAPIApplication.Net.Entities;

namespace WebAPIApplication.Net.Tests.Controllers
{
    public class CustomerControllerTest
    {
        private readonly HttpClient _client;

        public CustomerControllerTest()
        {
            _client = new HttpClient();
        }

        [Fact, SystemTest]
        public async Task Post_InvalidCustomer_RetunsBadRequest()
        {
            //Arrange
            var customer = new Customer();

            //Act
            var response = await _client.PostAsJsonAsync("http://0.0.0.0:5000/api/Customer", customer);

            //Assert
            Assert.NotNull(response);
        }
    }
}
