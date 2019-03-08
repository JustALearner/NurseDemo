using System;
using System.Linq;
using System.Text;

namespace Models
{
    ///<summary>
    ///
    ///</summary>
    public partial class T_Sys_ModulePara
    {
           public T_Sys_ModulePara(){


           }
           /// <summary>
           /// Desc:模块参数ID
           /// Default:
           /// Nullable:False
           /// </summary>           
           public decimal ModuleParaId {get;set;}

           /// <summary>
           /// Desc:模块参数名称
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string ModuleParaName {get;set;}

           /// <summary>
           /// Desc:模块参数父ID
           /// Default:
           /// Nullable:True
           /// </summary>           
           public decimal? PModuleParaId {get;set;}

           /// <summary>
           /// Desc:模块ID
           /// Default:
           /// Nullable:True
           /// </summary>           
           public decimal? ModuleId {get;set;}

           /// <summary>
           /// Desc:排序号
           /// Default:
           /// Nullable:True
           /// </summary>           
           public decimal? SeqNo {get;set;}

           /// <summary>
           /// Desc:参数值
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string ParaValue {get;set;}

           /// <summary>
           /// Desc:状态
           /// Default:
           /// Nullable:True
           /// </summary>           
           public byte? ParaStatus {get;set;}

           /// <summary>
           /// Desc:图标
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string ICO {get;set;}

    }
}
