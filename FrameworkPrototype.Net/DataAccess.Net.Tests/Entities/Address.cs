using System;
using DataAccess.Net.Attributes;

namespace DataAccess.Net.Tests.Entities
{
    public class Address
    {
        [Column(Name = "ADDRESS_ID")]
        public long Id { get; set; }

        [Column(Name = "ADDRESS_VALUE")]
        public string AdressValue { get; set; }
    }
}