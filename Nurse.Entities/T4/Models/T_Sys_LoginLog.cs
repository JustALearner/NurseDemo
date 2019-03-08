using System;
using System.Linq;
using System.Text;

namespace Models
{
    ///<summary>
    ///
    ///</summary>
    public partial class T_Sys_LoginLog
    {
           public T_Sys_LoginLog(){


           }
           /// <summary>
           /// Desc:登录日志ID
           /// Default:
           /// Nullable:False
           /// </summary>           
           public decimal LoginLogId {get;set;}

           /// <summary>
           /// Desc:用户编码
           /// Default:
           /// Nullable:False
           /// </summary>           
           public string UserCode {get;set;}

           /// <summary>
           /// Desc:登录时间
           /// Default:
           /// Nullable:False
           /// </summary>           
           public DateTime LoginTime {get;set;}

           /// <summary>
           /// Desc:登陆设备ID
           /// Default:
           /// Nullable:False
           /// </summary>           
           public decimal LoginDeviceId {get;set;}

    }
}
