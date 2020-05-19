using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Xunit;
using Xunit.Categories;

using WebAPIApplication.Net.Entities;

namespace WebAPIApplication.Net.Tests.Controllers
{
    public class CustomersControllerTest
    {
        private readonly HttpClient _client;

        public CustomersControllerTest()
        {
            _client = new HttpClient();
        }

        [Fact, SystemTest]
        public async Task Get_TooManyResults_ReturnsRequestedRangeNotSatisfiable()
        {
            //Arrange

            //Act
            var response = await _client.GetAsync("http://localhost:5000/api/Customers");

            //Assert
            Assert.NotNull(response);
            Assert.True(response.Content.IsContentTypeProblemJson());
            var content = await response.Content.ReadAsProblemDetails();
            Assert.IsType<ProblemDetails>(content);
            Assert.Equal(HttpStatusCode.RequestedRangeNotSatisfiable, response.StatusCode);
       }

        [Fact, SystemTest]
        public async Task Post_InvalidCustomer_ReturnsBadRequest()
        {
            //Arrange
            var customer = new Customer();

            //Act
            var response = await _client.PostAsJsonAsync("http://localhost:5000/api/Customers", customer);

            //Assert
            Assert.NotNull(response);
            Assert.True(response.Content.IsContentTypeProblemJson());
            var content = await response.Content.ReadAsProblemDetails();
            Assert.IsType<ValidationProblemDetails>(content);
            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
       }
    }

    internal static class HttpContextExtensions
    {
        internal static bool IsContentTypeProblemJson(this HttpContent httpContent)
        {
            return httpContent == null
                ? false
                : httpContent.Headers.ContentType.MediaType == "application/problem+json";
        }

        internal static async Task<ProblemDetails> ReadAsProblemDetails(this HttpContent httpContent)
        {
            var content = await httpContent.ReadAsStringAsync();
            var details = JsonConvert.DeserializeObject<ProblemDetails>(content);

            return details.Detail != null
                ? details
                : JsonConvert.DeserializeObject<ValidationProblemDetails>(content);
        }
    }
}
