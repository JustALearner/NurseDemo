using System;
using System.Linq;
using System.Text;

namespace Nurse.Entities
{
    ///<summary>
    ///
    ///</summary>
    public partial class T_Sys_UserRight
    {
           public T_Sys_UserRight(){


           }
           /// <summary>
           /// Desc:用户权限ID
           /// Default:
           /// Nullable:False
           /// </summary>           
           public decimal UserRightId {get;set;}

           /// <summary>
           /// Desc:用户ID
           /// Default:
           /// Nullable:False
           /// </summary>           
           public string UserId {get;set;}

           /// <summary>
           /// Desc:菜单ID
           /// Default:
           /// Nullable:False
           /// </summary>           
           public decimal MenuId {get;set;}

           /// <summary>
           /// Desc:是否启用：0 不启用、1 启用
           /// Default:
           /// Nullable:False
           /// </summary>           
           public byte RightStatus {get;set;}

           /// <summary>
           /// Desc:操作权限
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string ActionRight {get;set;}

    }
}
