using System.Text;

using WebAPIApplication.Net.Entities;

namespace WebAPIApplication.Net.Repositories
{
    internal class CustomerSql
    {
        internal static string SqlCountCustomers(CustomerCriteria criteria)
        {
            return new StringBuilder()
                .Append("Select ")
                .Append("Count(1) ")
                .Append(CustomerSql.SqlClauseWhere(criteria))
                .ToString();
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

        internal static string SqlInsert
        {
            get
            {
                return new StringBuilder()
                    .Append("Insert Into ")
                    .Append("CUSTOMER (")
                    .Append("CODE, ")
                    .Append("NAME, ")
                    .Append("NAS, ")
                    .Append("AMOUNT, ")
                    .Append("BIRTH_DATE, ")
                    .Append("OTHER_DATE ")
                    .Append(") Values(")
                    .Append(":CustomerCode, ")
                    .Append(":CustomerName, ")
                    .Append(":NAS, ")
                    .Append(":Amount, ")
                    .Append(":BirthDate, ")
                    .Append(":OtherDate)")
                    .ToString();
            }
        }

        internal static string SqlUpdate
        {
            get
            {
                return new StringBuilder()
                    .Append("Update ")
                    .Append("CUSTOMER ")
                    .Append("Set ")
                    .Append("CODE = :CustomerCode, ")
                    .Append("NAME = :CustomerName, ")
                    .Append("NAS = :NAS, ")
                    .Append("AMOUNT = :Amount, ")
                    .Append("BIRTH_DATE = :BirthDate, ")
                    .Append("OTHER_DATE = :OtherDate ")
                    .Append("Where ID = :Id")
                    .ToString();
            }
        }

        internal static string SqlDelete
        {
            get
            {
                return new StringBuilder()
                    .Append("Delete From ")
                    .Append("CUSTOMER ")
                    .Append("Where ID = :Id")
                    .ToString();
            }
        }
    }
}