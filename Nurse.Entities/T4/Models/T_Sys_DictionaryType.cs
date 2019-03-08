using System;
using System.Linq;
using System.Text;

namespace Models
{
    ///<summary>
    ///
    ///</summary>
    public partial class T_Sys_DictionaryType
    {
           public T_Sys_DictionaryType(){


           }
           /// <summary>
           /// Desc:字典类型ID
           /// Default:
           /// Nullable:False
           /// </summary>           
           public long DicTypeId {get;set;}

           /// <summary>
           /// Desc:字典类型编码
           /// Default:
           /// Nullable:False
           /// </summary>           
           public string DicTypeCode {get;set;}

           /// <summary>
           /// Desc:字典类型名称
           /// Default:
           /// Nullable:False
           /// </summary>           
           public string DicTypeName {get;set;}

           /// <summary>
           /// Desc:字典类型状态
           /// Default:
           /// Nullable:False
           /// </summary>           
           public byte DicTypeStatus {get;set;}

           /// <summary>
           /// Desc:
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string PdaUse {get;set;}

    }
}
