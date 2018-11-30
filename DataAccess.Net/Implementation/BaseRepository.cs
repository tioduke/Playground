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
            this._accesDB = accesDB;
            this._dbExecutor = dbExecutor;

            //Initialize Column Mapper
            SqlMapper.SetTypeMap(typeof(TEntity), new ColumnAttributeTypeMapper<TEntity>());
        }

        private IDbConnection Connection
        {
            get { return this._accesDB.GetConnection(); }
        }

        protected long GetSequence(string sequence)
        {
            var sql = string.Format("select {0}.nextval from dual", sequence);
            return this._dbExecutor.ExecuteReader<long>(this.Connection, sql).SingleOrDefault();
        }

        protected int ExecuteNonQueryRequest(string sql, object param)
        {
            return this._dbExecutor.ExecuteNonQuery(this.Connection, sql, param);
        }

        protected int ExecuteCountRequest(string sql, object param)
        {
            return this._dbExecutor.ExecuteReader<int>(this.Connection, sql, param).Single();
        }

        protected IEnumerable<TEntity> ExecuteReaderRequest(string sql, object param)
        {
            return this._dbExecutor.ExecuteReader<TEntity>(this.Connection, sql, param);
        }

        protected IEnumerable<TEntity> ExecuteReaderRequest<TFirst, TSecond>(string sql, object param, Func<TFirst, TSecond, TEntity> map, string splitOn)
        {
            //Initialize Column Mappers
            SqlMapper.SetTypeMap(typeof(TFirst), new ColumnAttributeTypeMapper<TFirst>());
            SqlMapper.SetTypeMap(typeof(TSecond), new ColumnAttributeTypeMapper<TSecond>());

            return this._dbExecutor.ExecuteReader<TFirst, TSecond, TEntity>(this.Connection, sql, map, param, splitOn).Distinct();
        }
    }
}
