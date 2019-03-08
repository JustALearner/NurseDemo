using System;
using System.Linq;
using System.Text;

namespace Models
{
    ///<summary>
    ///
    ///</summary>
    public partial class T_Sys_ProgramUpdate
    {
           public T_Sys_ProgramUpdate(){


           }
           /// <summary>
           /// Desc:程序更新ID
           /// Default:
           /// Nullable:False
           /// </summary>           
           public decimal ProgramUpdateId {get;set;}

           /// <summary>
           /// Desc:版本ID
           /// Default:
           /// Nullable:False
           /// </summary>           
           public decimal VersionId {get;set;}

           /// <summary>
           /// Desc:更新名称
           /// Default:
           /// Nullable:False
           /// </summary>           
           public string FileName {get;set;}

           /// <summary>
           /// Desc:更新内容
           /// Default:
           /// Nullable:True
           /// </summary>           
           public byte[] UpdateContent {get;set;}

           /// <summary>
           /// Desc:上传时间
           /// Default:
           /// Nullable:False
           /// </summary>           
           public DateTime UploadDate {get;set;}

           /// <summary>
           /// Desc:上传人
           /// Default:
           /// Nullable:False
           /// </summary>           
           public string UploadUser {get;set;}

           /// <summary>
           /// Desc:备注
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string Remark {get;set;}

    }
}
