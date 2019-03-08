using System;
using System.Linq;
using System.Text;

namespace Nurse.Entities
{

    public partial class T_Sys_RoleUser
    {
           public T_Sys_RoleUser(){


           }
           /// <summary>
           /// Desc:角色用户ID
           /// Default:
           /// Nullable:False
           /// </summary>           
           public decimal RoleUserID {get;set;}

           /// <summary>
           /// Desc:角色ID
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string RoleId {get;set;}

           /// <summary>
           /// Desc:用户ID
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string UserId {get;set;}

    }
}
