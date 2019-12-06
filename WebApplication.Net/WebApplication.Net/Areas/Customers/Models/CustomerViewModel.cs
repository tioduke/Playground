using System;

namespace WebApplication.Net.Customers.Models
{
    public class CustomerViewModel
    {
        private Customer _Customer = new Customer();

        public string TxtName
        {
            get { return _Customer.CustomerName; }
            set { _Customer.CustomerName = value; }
        }

        public string TxtAmount
        {
            get { return _Customer.Amount.ToString(); }
            set { _Customer.Amount = Convert.ToDecimal(value); }
        }

        public string CustomerLevelColor
        {
            get
            {
                if (_Customer.Amount > 2000.00M)
                {
                    return "red";
                }
                else if (_Customer.Amount > 1500.00M)
                {
                    return "orange";
                }
                else
                {
                    return "yellow";
                }
            }

        }

    }
}