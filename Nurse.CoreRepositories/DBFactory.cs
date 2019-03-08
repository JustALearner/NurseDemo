using System;
using System.Configuration;
using SqlSugar;

namespace Nurse.Repositories
{
//    [Obsolete]
    public class DbFactory
    {
        public static string ConnConfig { get; set; }
        //public SqlSugar.SqlSugarClient db { get { return GetInstance(); } }
        public static SqlSugarClient GetInstance(string connectionStringName = "Default")
        {
//            var connConfig = ConfigurationManager.ConnectionStrings[connectionStringName];
            if (ConnConfig==null)
            {
                throw new Exception("找不到数据库connectionString名为【" + connectionStringName + "】的配置");
            }
            DbType dbType;
            switch (ConnConfig.ProviderName)
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
                    ConnectionString = ConnConfig.ConnectionString,
                    DbType = dbType,
                    IsAutoCloseConnection = true,
                    InitKeyType=InitKeyType.SystemTable
                 //   IsShardSameThread = true /*Shard Same Thread*/
                });

            return db;
        }

     
    }
}
