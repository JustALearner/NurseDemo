using System;
using System.Linq;
using System.Text;

namespace Nurse.Entities
{
    ///<summary>
    ///
    ///</summary>
    public partial class T_Sys_RoleRight
    {
           public T_Sys_RoleRight(){


           }
           /// <summary>
           /// Desc:权限ID
           /// Default:
           /// Nullable:False
           /// </summary>           
           public decimal RoleRightId {get;set;}

           /// <summary>
           /// Desc:角色ID
           /// Default:
           /// Nullable:False
           /// </summary>           
           public decimal RoleId {get;set;}

           /// <summary>
           /// Desc:菜单ID
           /// Default:
           /// Nullable:False
           /// </summary>           
           public decimal MenuId {get;set;}

           /// <summary>
           /// Desc:操作权限
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string ActionRight {get;set;}

    }
}
