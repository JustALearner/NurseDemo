using System;
using System.Linq;
using System.Text;

namespace Models
{
    ///<summary>
    ///如果有角色权限则有记录，否则没有记录
   决定使用权限表还是角色权限表
   不允许一个用户有多个角色
    ///</summary>
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
