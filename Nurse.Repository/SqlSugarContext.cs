using System;
using System.Collections.Generic;

using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using SqlSugar;


namespace Nurse.Repositories
{
    public class SqlSugarContext
    {
        //        public static string DbConnectionString { get; set; }

        //        public static SqlSugarClient DB
        //        {
        //            get => new SqlSugarClient(new ConnectionConfig()
        //                {
        //                    ConnectionString = DbConnectionString,
        //                    DbType = DbType.SqlServer,
        //                    IsAutoCloseConnection = true,
        //                    InitKeyType = InitKeyType.SystemTable,
        //                    IsShardSameThread = false
        //                }
        //            );
        //        }
     
        public SqlSugarContext(IConfiguration cfg)
        {
            Db = new SqlSugarClient(new ConnectionConfig()
            {
                ConnectionString = cfg.GetConnectionString("connectionString"),
                DbType = DbType.Sqlite,
                IsAutoCloseConnection = true,
                InitKeyType = InitKeyType.SystemTable,
                IsShardSameThread = false
            });
        }
        public SqlSugarClient Db;//用来处理事务多表查询和复杂的操作
    }
}
