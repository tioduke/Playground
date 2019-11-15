using System.Text;

namespace UnderstandingDependencyInjection.Net.Repositories
{
    internal class VoidCustomerSql
    {
        internal static string SqlCountCustomers
        {
            get
            {
                return new StringBuilder()
                    .Append("Select ")
                    .Append("Count(1) ")
                    .Append("From CUSTOMER ")
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
                    .Append("Order By ID")
                    .ToString();
            }
        }
    }
}