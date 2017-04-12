using System;
using DataAccess.Net.Attributes;

namespace DataAccess.Net.Tests.Entities
{
    public class Customer
    {
        [Column(Name = "ID")]
        public long Id { get; set; }

        [Column(Name = "CODE")]
        public string CustomerCode { get; set; }

        [Column(Name = "NAME")]
        public string CustomerName { get; set; }
        
        [Column(Name = "NAS")]
        public string NAS { get; set; }

        [Column(Name = "AMOUNT")]
        public Decimal? Amount { get; set; }

        [Column(Name = "BIRTH_DATE")]
        public DateTime? BirthDate { get; set; }

        [Column(Name = "OTHER_DATE")]
        public DateTime? OtherDate { get; set; }
    }
}