using System;
using System.IO;
using System.Data;
using System.Linq;
using System.Reflection;
using Microsoft.Data.Sqlite;
using Xunit;

using DataAccess.Net.Interfaces;
using DataAccess.Net.Implementation;
using DataAccess.Net.Implementation.Sqlite;
using DataAccess.Net.Tests.Entities;
using DataAccess.Net.Tests.Repositories;

namespace DataAccess.Net.Tests
{
    public class SqliteRepositoryTest : IDisposable
    {
        private ICtrlAccesDB _accesBd;
        private readonly IReadableRepository<Customer, CustomerCriteria> _sqliteRepository;

        public SqliteRepositoryTest()
        {
            _accesBd = new SqliteCtrlAccesDB("DataSource=:memory:");
            _sqliteRepository = new CustomerRepository(_accesBd, new DapperExecutor());
        }

        public void Dispose()
        {
            _accesBd.ReleaseConnection();
        }

        [Fact]
        public void CustomerRepository_FindById_EntityFound()
        {
            //Arrange
            CreateInMemoryDB(_accesBd.GetConnection());

            //Act
            var resultat = _sqliteRepository.FindById(new CustomerCriteria { Id = 1L });

            //Assert
            Assert.Equal(1L, resultat.Id);
            Assert.Equal("A", resultat.CustomerCode);
            Assert.Equal("Asterix", resultat.CustomerName);
            Assert.Equal("111111111", resultat.NAS);
            Assert.Equal(2, resultat.Addresses.Count);
            Assert.Equal(10.2m, resultat.Amount);
            Assert.Equal(new DateTime(1933, 1, 1), resultat.BirthDate);
            Assert.Equal(new DateTime(2017, 4, 1), resultat.OtherDate);
        }

        [Fact]
        public void CustomerRepository_Find_EntitiesFound()
        {
            //Arrange
            CreateInMemoryDB(_accesBd.GetConnection());

            //Act
            var resultat = _sqliteRepository.Find(new CustomerCriteria { CustomerCode = "A" });

            //Assert
            Assert.Equal(2, resultat.Count());
            var entity1 = resultat.SingleOrDefault(x => x.Id == 1L);
            var entity2 = resultat.SingleOrDefault(x => x.Id == 3L);
            Assert.Equal(1L, entity1.Id);
            Assert.Equal("A", entity1.CustomerCode);
            Assert.Equal("Asterix", entity1.CustomerName);
            Assert.Equal(2, entity1.Addresses.Count);
            Assert.Equal("111111111", entity1.NAS);
            Assert.Equal(10.2m, entity1.Amount);
            Assert.Equal(new DateTime(1933, 1, 1), entity1.BirthDate);
            Assert.Equal(new DateTime(2017, 4, 1), entity1.OtherDate);
            Assert.Equal(3L, entity2.Id);
            Assert.Equal("A", entity2.CustomerCode);
            Assert.Equal("Obelix", entity2.CustomerName);
            Assert.Equal("333333333", entity2.NAS);
            Assert.Equal(1, entity1.Addresses.Count);
            Assert.Equal(11.14m, entity2.Amount);
            Assert.Equal(new DateTime(1934, 2, 3), entity2.BirthDate);
            Assert.Equal(new DateTime(2017, 4, 1), entity2.OtherDate);
        }

        private void CreateInMemoryDB(IDbConnection connection)
        {
            var command = new SqliteCommand(GetSqlCommands("SqliteRepository.sql"), (SqliteConnection)connection);
            command.ExecuteNonQuery();
        }

        private static string GetSqlCommands(string fileName)
        {
            var resourceName = "DataAccess.Net.Tests.Resources." + fileName;
            var assembly = Assembly.Load(new AssemblyName("DataAccess.Net.Tests"));

            using (var stream = assembly.GetManifestResourceStream(resourceName))
            {
                if (stream == null) throw new FileNotFoundException();

                using (var reader = new StreamReader(stream))
                {
                    return reader.ReadToEnd();
                }
            }
        }

    }
}
