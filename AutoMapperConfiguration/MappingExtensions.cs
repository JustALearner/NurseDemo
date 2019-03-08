using Nurse.Entities;
using Nurse.VModel;

namespace Nurse.AutoMapperConfig
{
    public static class MappingExtensions
    {
        public static TDestination MapTo<TSource, TDestination>(this TSource source)
        {
           return AutoMapperConfiguration.Mapper.Map<TSource, TDestination>(source);
        }

        public static TDestination MapTo<TSource, TDestination>(this TSource source, TDestination destination)
        {
            return AutoMapperConfiguration.Mapper.Map<TSource, TDestination>(source,destination);
        }
        #region user

        public static UserViewModel ToModel(this T_Sys_User user)
        {
            return user.MapTo<T_Sys_User, UserViewModel>();
        }
        public static T_Sys_User ToEntity(this UserViewModel userView)
        {
            return userView.MapTo<UserViewModel, T_Sys_User>();
        }

        public static T_Sys_User ToEntity(this UserViewModel userView, T_Sys_User user)
        {
        
            return userView.MapTo<UserViewModel, T_Sys_User>(user);
        }
        #endregion
    }
}
