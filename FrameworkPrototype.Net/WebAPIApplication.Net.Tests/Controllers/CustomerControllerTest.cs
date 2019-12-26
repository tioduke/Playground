using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Xunit;
using Xunit.Categories;

using WebAPIApplication.Net.Entities;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Collections.Generic;
using System.Net;

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
            var response = await _client.PostAsJsonAsync("http://localhost:5000/api/Customer", customer);

            //Assert
            Assert.NotNull(response);
            Assert.True(response.Content.IsContentTypeJson());
            var content = await response.Content.ReadAsAsync<object>();
            Assert.NotNull(content);
            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
       }
    }

    internal static class HttpContextExtensions
    {
        internal static bool IsContentTypeJson(this HttpContent httpContent)
        {
            return httpContent == null
                ? false
                : httpContent.Headers.ContentType.MediaType == "application/json";
        }
    }
}
