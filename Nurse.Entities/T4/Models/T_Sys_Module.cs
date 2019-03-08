using System;
using System.Linq;
using System.Text;

namespace Models
{
    ///<summary>
    ///
    ///</summary>
    public partial class T_Sys_Module
    {
           public T_Sys_Module(){


           }
           /// <summary>
           /// Desc:模块ID
           /// Default:
           /// Nullable:False
           /// </summary>           
           public decimal ModuleId {get;set;}

           /// <summary>
           /// Desc:模块名
           /// Default:
           /// Nullable:False
           /// </summary>           
           public string ModuleName {get;set;}

           /// <summary>
           /// Desc:Url
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string Url {get;set;}

           /// <summary>
           /// Desc:状态: 0 不可用、1 可用
           /// Default:1
           /// Nullable:False
           /// </summary>           
           public byte ModuleStatus {get;set;}

           /// <summary>
           /// Desc:备注
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string Remark {get;set;}

           /// <summary>
           /// Desc:操作权限：用竖杠（|）隔开
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string ActionRight {get;set;}

    }
}
