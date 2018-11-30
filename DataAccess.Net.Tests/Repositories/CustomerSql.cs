using System.Text;

namespace DataAccess.Net.Tests.Repositories
{
    internal class CustomerSql
    {
        internal static string SqlCountCustomers
        {
            get
            {
                return new StringBuilder()
                    .Append("Select Count(1)")
                    .Append("From CUSTOMER ")
                    .Append("Where CODE = :CustomerCode ")
                    .ToString();
            }
        }

        internal static string SqlSelectCustomer
        {
            get
            {
                return new StringBuilder()
                    .Append("Select ")
                    .Append("CUSTOMER.CUSTOMER_ID, ")
                    .Append("CODE, ")
                    .Append("NAME, ")
                    .Append("NAS, ")
                    .Append("AMOUNT, ")
                    .Append("BIRTH_DATE, ")
                    .Append("OTHER_DATE, ")
                    .Append("ADDRESS_ID, ")
                    .Append("ADDRESS_VALUE ")
                    .Append("From CUSTOMER ")
                    .Append("Inner Join ADDRESS ")
                    .Append("On ADDRESS.CUSTOMER_ID = CUSTOMER.CUSTOMER_ID ")
                    .Append("Where CUSTOMER.CUSTOMER_ID = :Id")
                    .ToString();
            }
        }

        internal static string SqlSelectCustomers
        {
            get
            {
                return new StringBuilder()
                    .Append("Select ")
                    .Append("CUSTOMER.CUSTOMER_ID, ")
                    .Append("CODE, ")
                    .Append("NAME, ")
                    .Append("NAS, ")
                    .Append("AMOUNT, ")
                    .Append("BIRTH_DATE, ")
                    .Append("OTHER_DATE, ")
                    .Append("ADDRESS_ID, ")
                    .Append("ADDRESS_VALUE ")
                    .Append("From CUSTOMER ")
                    .Append("Inner Join ADDRESS ")
                    .Append("On ADDRESS.CUSTOMER_ID = CUSTOMER.CUSTOMER_ID ")
                    .Append("Where CODE = :CustomerCode ")
                    .Append("Order By CUSTOMER.CUSTOMER_ID, ADDRESS_ID")
                    .ToString();
            }
        }

    }
}