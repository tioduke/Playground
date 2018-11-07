using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Dapper;
using DataAccess.Net.Attributes;
using DataAccess.Net.Interfaces;

namespace DataAccess.Net.Implementation
{
    public abstract class BaseRepositoryMulti<TEntity, TNested>
        where TEntity: class
    {
        private readonly ICtrlAccesDB _accesDB;
        private readonly IDbExecutor _dbExecutor;

        protected BaseRepositoryMulti(ICtrlAccesDB accesDB, IDbExecutor dbExecutor)
        {
            this._accesDB = accesDB;
            this._dbExecutor = dbExecutor;

            //Initialize Column Mapper
            SqlMapper.SetTypeMap(typeof(TEntity), new ColumnAttributeTypeMapper<TEntity>());
            SqlMapper.SetTypeMap(typeof(TNested), new ColumnAttributeTypeMapper<TNested>());
        }

        private IDbConnection Connection
        {
            get { return this._accesDB.GetConnection(); }
        }

        protected IEnumerable<TEntity> ExecuteReaderRequest(string sql, Func<TEntity, TNested, TEntity> map, object param, string splitOn)
        {
            return this._dbExecutor.ExecuteReader<TEntity, TNested>(this.Connection, sql, map, param, splitOn).Distinct();
        }
    }
}
