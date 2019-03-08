using System;
using System.Linq;
using System.Text;

namespace Nurse.Entities
{
    ///<summary>
    ///
    ///</summary>
    public partial class V_Bar_Code
    {
           public V_Bar_Code(){


           }
           /// <summary>
           /// Desc:
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string BarCode {get;set;}

           /// <summary>
           /// Desc:
           /// Default:
           /// Nullable:False
           /// </summary>           
           public string DeptCode {get;set;}

           /// <summary>
           /// Desc:
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string BarType {get;set;}

    }
}
