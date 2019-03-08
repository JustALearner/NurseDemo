using System;
using System.Linq;
using System.Text;

namespace Nurse.Entities
{
    ///<summary>
    ///
    ///</summary>
    public partial class T_Sys_File
    {
           public T_Sys_File(){


           }
           /// <summary>
           /// Desc:文件ID
           /// Default:
           /// Nullable:False
           /// </summary>           
           public decimal FileId {get;set;}

           /// <summary>
           /// Desc:文件组ID
           /// Default:
           /// Nullable:False
           /// </summary>           
           public string FileGroupId {get;set;}

           /// <summary>
           /// Desc:清单编码
           /// Default:
           /// Nullable:False
           /// </summary>           
           public string ListCode {get;set;}

           /// <summary>
           /// Desc:文件名
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string FileName {get;set;}

           /// <summary>
           /// Desc:文件实体
           /// Default:
           /// Nullable:False
           /// </summary>           
           public byte[] FileEntity {get;set;}

           /// <summary>
           /// Desc:表名
           /// Default:
           /// Nullable:False
           /// </summary>           
           public string TableName {get;set;}

           /// <summary>
           /// Desc:创建时间
           /// Default:
           /// Nullable:False
           /// </summary>           
           public DateTime CrtDate {get;set;}

           /// <summary>
           /// Desc:修改时间
           /// Default:
           /// Nullable:False
           /// </summary>           
           public DateTime UpdDate {get;set;}

    }
}
