using System;
using System.Linq;
using System.Text;

namespace Nurse.Entities
{
    ///<summary>
    ///
    ///</summary>
    public partial class T_Sys_Menu
    {
           public T_Sys_Menu(){


           }
           /// <summary>
           /// Desc:菜单ID
           /// Default:
           /// Nullable:False
           /// </summary>           
           public decimal MenuId {get;set;}

           /// <summary>
           /// Desc:菜单名称
           /// Default:
           /// Nullable:False
           /// </summary>           
           public string MenuName {get;set;}

           /// <summary>
           /// Desc:父菜单ID
           /// Default:
           /// Nullable:False
           /// </summary>           
           public decimal PMenuId {get;set;}

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
           /// Desc:模块参数ID
           /// Default:
           /// Nullable:True
           /// </summary>           
           public decimal? ModuleParaId {get;set;}

           /// <summary>
           /// Desc:状态
           /// Default:
           /// Nullable:True
           /// </summary>           
           public byte? MenuStatus {get;set;}

           /// <summary>
           /// Desc:ICO
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string ICO {get;set;}

    }
}
