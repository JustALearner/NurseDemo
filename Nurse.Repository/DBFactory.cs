using System;
using System.Collections.Generic;
using System.Configuration;
using Microsoft.Extensions.Logging;
using SqlSugar;

namespace Nurse.Repositories
{
    //    [Obsolete]
    public class DbFactory
    {

        //public SqlSugar.SqlSugarClient db { get { return GetInstance(); } }
        public static SqlSugarClient GetInstance(string connectionStringName = "Default")
        {
            var connConfig = ConfigurationManager.ConnectionStrings[connectionStringName];
            if (connConfig == null)
            {
                throw new Exception("找不到数据库connectionString名为【" + connectionStringName + "】的配置");
            }
            DbType dbType;
            switch (connConfig.ProviderName)
            {
                case "System.Data.SqlClient":
                    dbType = DbType.SqlServer;
                    break;
                case "Oracle.ManagedDataAccess.Client":
                    dbType = DbType.Oracle;
                    break;
                default:
                    throw new Exception("ConnectionString名为【" + connectionStringName + "】的配置 ProviderName错误");
            }
            SqlSugarClient db = new SqlSugarClient(
                new ConnectionConfig()
                {
                    ConnectionString = connConfig.ConnectionString,
                    DbType = dbType,
                    IsAutoCloseConnection = true,
                    InitKeyType = InitKeyType.SystemTable
                    //   IsShardSameThread = true /*Shard Same Thread*/
                });

            return db;
        }
        private readonly ILogger _logger;
        private readonly ConnectionConfig _config;

        public DbFactory(ConnectionConfig config, ILogger<DbFactory> logger)
        {
            this._logger = logger;
            this._config = config;
        }

        public SqlSugarClient GetDbContext(Action<Exception> onErrorEvent) => GetDbContext(null, null, onErrorEvent);
        public SqlSugarClient GetDbContext(Action<string, SugarParameter[]> onExecutedEvent) => GetDbContext(onExecutedEvent);
        public SqlSugarClient GetDbContext(Func<string, SugarParameter[], KeyValuePair<string, SugarParameter[]>> onExecutingChangeSqlEvent) => GetDbContext(null, onExecutingChangeSqlEvent);
        public  SqlSugarClient GetDbContext(Action<string, SugarParameter[]> onExecutedEvent = null, Func<string, SugarParameter[], KeyValuePair<string, SugarParameter[]>> onExecutingChangeSqlEvent = null, Action<Exception> onErrorEvent = null)
        {
            SqlSugarClient db = new SqlSugarClient(_config)
            {
                Aop =
                {
                    OnExecutingChangeSql = onExecutingChangeSqlEvent,
                    OnError = onErrorEvent ?? ((Exception ex) => { this._logger.LogError(ex, "ExecuteSql Error"); }),
                    OnLogExecuted =onExecutedEvent?? ((string sql, SugarParameter[] pars) =>
                    {
                        var keyDic = new KeyValuePair<string, SugarParameter[]>(sql, pars);
//                        this._logger.LogInformation($"ExecuteSql：【{keyDic.ToJson()}】");
                    })
                }
            };
            return db;
        }

    }
}
