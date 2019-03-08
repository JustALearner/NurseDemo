using System;
using System.Configuration;
using SqlSugar;

namespace Nurse.Repositories
{
    [Obsolete]
    public class DbContext<T> where T : class, new()
    {
        public DbContext(string connectionStringName = "Default")
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
                    IsShardSameThread = true /*Shard Same Thread*/
                });
            //            //调式代码 用来打印SQL 
            //            Db.Aop.OnLogExecuting = (sql, pars) =>
            //            {
            //                Console.WriteLine(sql + "\r\n" +
            //                                  Db.Utilities.SerializeObject(pars.ToDictionary(it => it.ParameterName, it => it.Value)));
            //                Console.WriteLine();
            //            };

        }
        //注意：不能写成静态的
        public SqlSugarClient Db;//用来处理事务多表查询和复杂的操作
        public SimpleClient<T> CurrentDb //用来处理T表的常用操作
            => new SimpleClient<T>(Db);
    
        //        /// <summary>
        //        /// 获取所有
        //        /// </summary>
        //        /// <returns></returns>
        //        public virtual List<T> GetList()
        //        {
        //            return CurrentDb.GetList();
        //        }
        //
        //        /// <summary>
        //        /// 根据主键删除
        //        /// </summary>
        //        /// <param name="id"></param>
        //        /// <returns></returns>
        //        public virtual bool Delete(dynamic id)
        //        {
        //            return CurrentDb.Delete(id);
        //        }
        //
        //
        //        /// <summary>
        //        /// 更新
        //        /// </summary>
        //        /// <param name="id"></param>
        //        /// <returns></returns>
        //        public virtual bool Update(T obj)
        //        {
        //            return CurrentDb.Update(obj);
        //        }
       
    }
}
