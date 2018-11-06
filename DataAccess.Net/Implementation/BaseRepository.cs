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

        protected IEnumerable<TEntity> ExecuteReaderRequest(string sql, object param)
        {
            return this._dbExecutor.ExecuteReader<TEntity>(this.Connection, sql, param);
        }

        protected IEnumerable<TEntity> ExecuteReaderRequest<TNested>(string sql, Func<TEntity, TNested, TEntity> map, object param, string splitOn)
        {
            //Initialize Column Mapper for nested entity
            SqlMapper.SetTypeMap(typeof(TNested), new ColumnAttributeTypeMapper<TNested>());

            return this._dbExecutor.ExecuteReader<TEntity, TNested>(this.Connection, sql, map, param, splitOn).Distinct();
        }
    }
}
