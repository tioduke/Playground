using System;

namespace DataAccess.Net.Tests.Entities
{
    public class CustomerWithParameters
    {
        public long Id { get; set; }

        public string CustomerCode { get; set; }

        public string CustomerName { get; set; }

        public string NAS { get; set; }

        public decimal? Amount { get; set; }

        public DateTime? BirthDate { get; set; }

        public DateTime? OtherDate { get; set; }

        public CustomerWithParameters(long CUSTOMER_ID, string CODE, string NAME, string NAS, double AMOUNT, string BIRTH_DATE, string OTHER_DATE)
        {
            Id = CUSTOMER_ID;
            CustomerCode = CODE;
            CustomerName = NAME;
            this.NAS = NAS;
            Amount = (decimal)AMOUNT;
            BirthDate = DateTime.ParseExact(BIRTH_DATE, "yyyy-MM-dd HH:mm:ss", null);
            OtherDate = DateTime.ParseExact(OTHER_DATE, "yyyy-MM-dd HH:mm:ss", null);
        }
    }
}
