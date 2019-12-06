using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using Xunit;
using Xunit.Categories;

using WebApplication.Net.Customers.Controllers;
using WebApplication.Net.Customers.Models;

namespace WebApplication.Net.Tests
{
    public class CustomerControllerTest
    {
        [Fact, UnitTest]
        public void DisplayCustomer_Success()
        {
            // Arrange
            Customer objCustomer = new Customer();
            objCustomer.Id = 10;
            objCustomer.CustomerCode = "1001";
            objCustomer.CustomerName = "Asterix";
            objCustomer.NAS = "046454286";
            objCustomer.Amount = 90.10m;
            objCustomer.BirthDate = null;
            objCustomer.OtherDate = null;

            CustomerController controller = new CustomerController();

            // Act
            ViewResult result = controller.DisplayCustomer(objCustomer) as ViewResult;

            // Assert
            Assert.Equal("DisplayCustomer", result.ViewName);
        }

        [Fact, UnitTest]
        public void Validate_RequiredFields_Invalid()
        {
            // Arrange
            Customer objCustomer = new Customer();
            objCustomer.Id = null;
            objCustomer.CustomerCode = null;
            objCustomer.CustomerName = null;
            objCustomer.NAS = null;
            objCustomer.Amount = null;
            objCustomer.BirthDate = null;
            objCustomer.OtherDate = null;

            ValidationContext context = new ValidationContext(objCustomer, null, null);
            List<ValidationResult> results = new List<ValidationResult>();

            // Act
            bool isModelStateValide = Validator.TryValidateObject(objCustomer, context, results, true);

            // Assert
            Assert.False(isModelStateValide);
            Assert.Equal(3, results.Count);
            Assert.Contains("is required", results[0].ErrorMessage);
            Assert.Contains("is required", results[1].ErrorMessage);
            Assert.Contains("is required", results[2].ErrorMessage);
        }

        [Fact, UnitTest]
        public void Validate_StringLengths_Invalid()
        {
            // Arrange
            Customer objCustomer = new Customer();
            objCustomer.Id = 10;
            objCustomer.CustomerCode = "12345";
            objCustomer.CustomerName = "12345678901234567890123456789012345678901";
            objCustomer.NAS = null;
            objCustomer.Amount = 90.10m;
            objCustomer.BirthDate = null;
            objCustomer.OtherDate = null;

            ValidationContext context = new ValidationContext(objCustomer, null, null);
            List<ValidationResult> results = new List<ValidationResult>();

            // Act
            bool isModelStateValide = Validator.TryValidateObject(objCustomer, context, results, true);

            // Assert
            Assert.False(isModelStateValide);
            Assert.Equal(2, results.Count);
            Assert.Contains("must be a string with a maximum length of", results[0].ErrorMessage);
            Assert.Contains("must be a string with a maximum length of", results[1].ErrorMessage);
        }

        [Fact, UnitTest]
        public void Validate_NAS_Invalid()
        {
            // Arrange
            Customer objCustomer = new Customer();
            objCustomer.Id = 10;
            objCustomer.CustomerCode = "1001";
            objCustomer.CustomerName = "Asterix";
            objCustomer.NAS = "123456789";
            objCustomer.Amount = 90.10m;
            objCustomer.BirthDate = null;
            objCustomer.OtherDate = null;

            ValidationContext context = new ValidationContext(objCustomer, null, null);
            List<ValidationResult> results = new List<ValidationResult>();

            // Act
            bool isModelStateValide = Validator.TryValidateObject(objCustomer, context, results, true);

            // Assert
            Assert.False(isModelStateValide);
            Assert.Single(results);
            Assert.Contains("is invalid", results[0].ErrorMessage);
        }
    }
}
