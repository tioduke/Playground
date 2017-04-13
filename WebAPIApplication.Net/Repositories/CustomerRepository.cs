using System;
using System.Collections.Generic;
using System.Linq;
using DataAccess.Net.Interfaces;
using DataAccess.Net.Implementation;
using WebAPIApplication.Net.Entities;

namespace WebAPIApplication.Net.Repositories
{
    public class CustomerRepository :
        BaseRepository<Customer>,
        IReadableRepository<Customer, CustomerCriteria>,
        IWritableRepository<Customer, CustomerCriteria>
    {
        public CustomerRepository(ICtrlAccesDB accesDB, IDbExecutor dbExec)
            : base(accesDB, dbExec) { }

        public Customer FindById(CustomerCriteria criteria)
        {
            if (criteria == null || criteria.Id == null)
                throw new ArgumentException("criteria");

            return base.ExecuteReaderRequest(CustomerSql.SqlSelectCustomer, criteria).SingleOrDefault();
        }

        public IEnumerable<Customer> Find(CustomerCriteria criteria)
        {
            if (criteria == null)
                throw new ArgumentException("criteria");

            return base.ExecuteReaderRequest(CustomerSql.SqlSelectCustomers(criteria), criteria);
        }
        
        public long GetSequence()
        {
            throw new NotImplementedException();
        }

        public int Insert(Customer entity)
        {
            if (entity == null)
                throw new ArgumentException("entity");

            return base.ExecuteNonQueryRequest(CustomerSql.SqlInsert, entity);
        }

        public int Update(Customer entity, CustomerCriteria criteria=null)
        {
            if (entity == null)
                throw new ArgumentException("entity");

            return base.ExecuteNonQueryRequest(CustomerSql.SqlUpdate, entity);
        }

        public int Delete(CustomerCriteria criteria)
        {
            if (criteria == null || criteria.Id == null)
                throw new ArgumentException("criteria");

            return base.ExecuteNonQueryRequest(CustomerSql.SqlDelete, criteria);
        }

    }
}