using System;
using System.Linq;
using System.Text;

namespace Models
{
    ///<summary>
    ///
    ///</summary>
    public partial class T_Sys_Dictionary
    {
           public T_Sys_Dictionary(){


           }
           /// <summary>
           /// Desc:字典ID
           /// Default:
           /// Nullable:False
           /// </summary>           
           public long DicId {get;set;}

           /// <summary>
           /// Desc:字典类型ID
           /// Default:
           /// Nullable:True
           /// </summary>           
           public int? DicTypeId {get;set;}

           /// <summary>
           /// Desc:字典名称
           /// Default:
           /// Nullable:False
           /// </summary>           
           public string DicName {get;set;}

           /// <summary>
           /// Desc:字典编码
           /// Default:
           /// Nullable:False
           /// </summary>           
           public string DicCode {get;set;}

           /// <summary>
           /// Desc:排序号
           /// Default:
           /// Nullable:True
           /// </summary>           
           public decimal? SeqNo {get;set;}

    }
}
