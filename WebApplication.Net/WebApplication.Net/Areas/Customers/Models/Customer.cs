using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using WebApplication.Net.Validations;

namespace WebApplication.Net.Customers.Models
{
    public class Customer
    {
        [Required(ErrorMessage = "The field {0} is required")]
        [Range(10, 99)]
        public int? Id { get; set; }

        [Required(ErrorMessage = "The field {0} is required")]
        [StringLength(4)]
        public string CustomerCode { get; set; }

        [StringLength(40)]
        public string CustomerName { get; set; }

        [NasValidation]
        public string NAS { get; set; }

        [Required(ErrorMessage = "The field {0} is required")]
        [Remote("IsAmountValide", "Customer", AdditionalFields = "NAS", ErrorMessage = "The field {0} must be greater than zero if NAS is informed.")]
        public Decimal? Amount { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? BirthDate { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? OtherDate { get; set; }
        
        public string CustomerUrl { get; set; }
    }
}