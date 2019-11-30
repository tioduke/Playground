using System;
using System.IO;
using System.Data;
using System.Linq;
using System.Reflection;
using Microsoft.Data.Sqlite;
using Dapper;
using Xunit;
using Xunit.Categories;

using DataAccess.Net.Attributes;
using DataAccess.Net.Tests.Entities;

namespace DataAccess.Net.Tests.Attributes
{
    public class ColumnAttributeTest : DbTester, IDisposable
    {
        private IDbConnection _dbConnexion;

        public ColumnAttributeTest()
        {
            _dbConnexion = new SqliteConnection
            {
                ConnectionString = "DataSource=:memory:"
            };

            _dbConnexion.Open();
            base.CreateInMemoryDB(_dbConnexion);
        }

        public void Dispose()
        {
            _dbConnexion.Close();
        }

        [Fact, UnitTest]
        public void Query_TypeMapped_RetournsEntityWithProperties()
        {
            //Arrange
            var sql = "select * from CUSTOMER where CUSTOMER_ID = :Id";
            SqlMapper.SetTypeMap(typeof(Customer), new ColumnAttributeTypeMapper<Customer>());

            //Act
            var resultat = _dbConnexion.Query<Customer>(sql, new { Id = 1 }).ToList();

            //Assert
            Assert.NotEmpty(resultat);
            Assert.Equal(1L, resultat[0].Id);
            Assert.Equal("Asterix", resultat[0].CustomerName);
            Assert.Equal("111111111", resultat[0].NAS);
            Assert.Equal(10.2m, resultat[0].Amount);
            Assert.Equal(new DateTime(1933, 1, 1), resultat[0].BirthDate);
            Assert.Equal(new DateTime(2017, 4, 1), resultat[0].OtherDate);
        }

        [Fact, UnitTest]
        public void Query_TypeNotMapped_RetournsEntityWithProperties()
        {
            //Arrange
            var sql = "select CUSTOMER_ID as Id, NAME as CustomerName, NAS, AMOUNT as Amount, BIRTH_DATE as BirthDate, OTHER_DATE as OtherDate from CUSTOMER where CUSTOMER_ID = :Id";
            SqlMapper.SetTypeMap(typeof(Customer), null);

            //Act
            var resultat = _dbConnexion.Query<Customer>(sql, new { Id = 1 }).ToList();

            //Assert
            Assert.NotEmpty(resultat);
            Assert.Equal(1L, resultat[0].Id);
            Assert.Equal("Asterix", resultat[0].CustomerName);
            Assert.Equal("111111111", resultat[0].NAS);
            Assert.Equal(10.2m, resultat[0].Amount);
            Assert.Equal(new DateTime(1933, 1, 1), resultat[0].BirthDate);
            Assert.Equal(new DateTime(2017, 4, 1), resultat[0].OtherDate);
        }

        [Fact, UnitTest]
        public void Query_TypeMappedByConstructorParameters_RetournsEntityWithProperties()
        {
            //Arrange
            var sql = "select * from CUSTOMER where CUSTOMER_ID = :Id";
            SqlMapper.SetTypeMap(typeof(CustomerWithParameters), new ColumnAttributeTypeMapper<CustomerWithParameters>());

            //Act
            var resultat = _dbConnexion.Query<CustomerWithParameters>(sql, new { Id = 1 }).ToList();

            //Assert
            Assert.NotEmpty(resultat);
            Assert.Equal(1L, resultat[0].Id);
            Assert.Equal("Asterix", resultat[0].CustomerName);
            Assert.Equal("111111111", resultat[0].NAS);
            Assert.Equal(10.2m, resultat[0].Amount);
            Assert.Equal(new DateTime(1933, 1, 1), resultat[0].BirthDate);
            Assert.Equal(new DateTime(2017, 4, 1), resultat[0].OtherDate);
        }
    }
}
