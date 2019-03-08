using System;
using System.Linq;
using System.Text;

namespace Nurse.Entities
{
    ///<summary>
    ///
    ///</summary>
    public partial class T_Sys_Device
    {
           public T_Sys_Device(){


           }
           /// <summary>
           /// Desc:设备ID
           /// Default:
           /// Nullable:False
           /// </summary>           
           public long DeviceId {get;set;}

           /// <summary>
           /// Desc:用户ID
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string UserId {get;set;}

           /// <summary>
           /// Desc:科室ID
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string DeptId {get;set;}

           /// <summary>
           /// Desc:设备状态
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string DeviceStatus {get;set;}

           /// <summary>
           /// Desc:开始使用时间
           /// Default:
           /// Nullable:True
           /// </summary>           
           public DateTime? UseBeginTime {get;set;}

           /// <summary>
           /// Desc:IEMI
           /// Default:
           /// Nullable:False
           /// </summary>           
           public string IEMI {get;set;}

           /// <summary>
           /// Desc:SIM
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string SIM {get;set;}

           /// <summary>
           /// Desc:MAC
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string MAC {get;set;}

           /// <summary>
           /// Desc:责任人
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string PersonLiable {get;set;}

           /// <summary>
           /// Desc:录入时间
           /// Default:
           /// Nullable:False
           /// </summary>           
           public DateTime InputTime {get;set;}

           /// <summary>
           /// Desc:录入人员
           /// Default:
           /// Nullable:False
           /// </summary>           
           public string Inputer {get;set;}

           /// <summary>
           /// Desc:设备型号
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string DeviceModel {get;set;}

           /// <summary>
           /// Desc:固定资产编号
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string EquipmentNo {get;set;}

           /// <summary>
           /// Desc:出厂编号
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string ProductionNo {get;set;}

    }
}
