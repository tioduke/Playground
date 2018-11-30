using System.Text;

namespace UnderstandingDependencyInjection.Net.Repositories
{
    internal class CustomerSql
    {
        internal static string SqlCountCustomers
        {
            get
            {
                return new StringBuilder()
                    .Append("Select ")
                    .Append("Count(1) ")
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
                    .Append("ID, ")
                    .Append("CODE, ")
                    .Append("NAME, ")
                    .Append("NAS, ")
                    .Append("AMOUNT, ")
                    .Append("BIRTH_DATE, ")
                    .Append("OTHER_DATE ")
                    .Append("From CUSTOMER ")
                    .Append("Where ID = :Id")
                    .ToString();
            }
        }

        internal static string SqlSelectCustomers
        {
            get
            {
                return new StringBuilder()
                    .Append("Select ")
                    .Append("ID, ")
                    .Append("CODE, ")
                    .Append("NAME, ")
                    .Append("NAS, ")
                    .Append("AMOUNT, ")
                    .Append("BIRTH_DATE, ")
                    .Append("OTHER_DATE ")
                    .Append("From CUSTOMER ")
                    .Append("Where CODE = :CustomerCode ")
                    .Append("Order By ID")
                    .ToString();
            }
        }
    }
}