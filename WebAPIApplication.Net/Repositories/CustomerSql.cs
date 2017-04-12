using System.Text;

using WebAPIApplication.Net.Entities;

namespace WebAPIApplication.Net.Repositories
{
    internal class CustomerSql
    {
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

        internal static string SqlSelectCustomers(CustomerCriteria criteria)
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
                .Append(CustomerSql.SqlClauseWhere(criteria))
                .Append("Order By ID")
                .ToString();
        }

        private static string SqlClauseWhere(CustomerCriteria criteria)
        {
            return criteria.CustomerCode == null
                ? string.Empty
                : "Where CODE = :CustomerCode ";
        }

    }
}