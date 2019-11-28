using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Dapper;
using DataAccess.Net.Attributes;
using DataAccess.Net.Interfaces;

namespace DataAccess.Net.Implementation
{
    public abstract class BaseRepository<TEntity>
        where TEntity: class
    {
        private readonly ICtrlAccesDB _accesDB;
        private readonly IDbExecutor _dbExecutor;

        protected BaseRepository(ICtrlAccesDB accesDB, IDbExecutor dbExecutor)
        {
            _accesDB = accesDB;
            _dbExecutor = dbExecutor;
        }

        private IDbConnection Connection
        {
            get { return this._accesDB.GetConnection(); }
        }

        protected long GetSequence(string sequence)
        {
            var sql = string.Format("select {0}.nextval from dual", sequence);
            return _dbExecutor.ExecuteReader<long>(Connection, sql).SingleOrDefault();
        }

        protected int ExecuteNonQueryRequest(string sql, object param)
        {
            return _dbExecutor.ExecuteNonQuery(Connection, sql, param);
        }

        protected int ExecuteCountRequest(string sql, object param)
        {
            return _dbExecutor.ExecuteReader<int>(Connection, sql, param).Single();
        }

        protected IEnumerable<TEntity> ExecuteReaderRequest(string sql, object param)
        {
            //Initialize Column Mapper
            SqlMapper.SetTypeMap(typeof(TEntity), new ColumnAttributeTypeMapper<TEntity>());

            return _dbExecutor.ExecuteReader<TEntity>(Connection, sql, param);
        }

        protected IEnumerable<TEntity> ExecuteReaderRequest<TFirst, TSecond>(string sql, object param, Func<TFirst, TSecond, TEntity> map, string splitOn)
        {
            //Initialize Column Mappers
            SqlMapper.SetTypeMap(typeof(TFirst), new ColumnAttributeTypeMapper<TFirst>());
            SqlMapper.SetTypeMap(typeof(TSecond), new ColumnAttributeTypeMapper<TSecond>());

            return _dbExecutor.ExecuteReader<TFirst, TSecond, TEntity>(Connection, sql, map, param, splitOn).Distinct();
        }
    }
}
