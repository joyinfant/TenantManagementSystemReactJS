﻿using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;
using static Dapper.SqlMapper;

namespace TMSReactJS_API_DBEngine
{
    public interface ISQL_Service_Handeler
    {
        IDbConnection Connection { get; }

        Task<T> QueryFirstOrDefaultAsync<T>(IDbConnection connection, string sql, CommandType commandType, object parameters = null);  // return the Single row Data table values

        Task<T> QuerySingleAsync<T>(IDbConnection connection, string sql, CommandType commandType, object parameters = null); // return the Data table values

        Task<T> ExecuteScalarAsync<T>(IDbConnection connection, string sql, CommandType commandType, object parameters = null);  // return the object values

        Task ExecuteAsync(IDbConnection connection, string sql, CommandType commandType, object parameters = null); // Insert, Update and Delete


        Task<IEnumerable<T>> QueryAsync<T>(IDbConnection connection, string sql, CommandType commandType, object parameters = null);   // return the Single data table

        Task<GridReader> QueryMultipleAsync(IDbConnection connection, string sql, CommandType commandType, object parameters = null);  // return the Data Set  values


    }
    public class SQL_Service_Handeler:ISQL_Service_Handeler
    {

        private readonly IConfiguration _configuration;
        public SQL_Service_Handeler(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public IDbConnection Connection
        {
            get
            {
                var sqlconnection = new SqlConnection(_configuration.GetConnectionString("PFAConnString"));



                return sqlconnection;
            }
        }

        public async Task<T> QueryFirstOrDefaultAsync<T>(IDbConnection connection, string sql, CommandType commandType, object parameters = null)
        {
            using (connection)
            {
                return await connection.QueryFirstOrDefaultAsync<T>(sql, parameters, commandType: commandType);
            }
        }

        public async Task<IEnumerable<T>> QueryAsync<T>(IDbConnection connection, string sql, CommandType commandType, object parameters = null)
        {
            using (connection)
            {
                return await connection.QueryAsync<T>(sql, parameters, commandType: commandType, commandTimeout: 600);
            }
        }

        public async Task<T> QuerySingleAsync<T>(IDbConnection connection, string sql, CommandType commandType, object parameters = null)
        {
            using (connection)
            {
                return await connection.QuerySingleAsync<T>(sql, parameters, commandType: commandType);
            }
        }

        public async Task<T> ExecuteScalarAsync<T>(IDbConnection connection, string sql, CommandType commandType, object parameters = null)
        {
            using (connection)
            {
                return await connection.ExecuteScalarAsync<T>(sql, parameters, commandType: commandType);
            }
        }

        public async Task ExecuteAsync(IDbConnection connection, string sql, CommandType commandType, object parameters = null)
        {
            using (connection)
            {
                await connection.ExecuteAsync(sql, parameters, commandType: commandType);
            }
        }

        public async Task<GridReader> QueryMultipleAsync(IDbConnection connection, string sql, CommandType commandType, object parameters = null)
        {
            return await connection.QueryMultipleAsync(sql, parameters, commandType: commandType, commandTimeout: 180);
        }
    }
}
}
