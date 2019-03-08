using AutoMapper;
using Nurse.Entities;
using Nurse.VModel;

namespace Nurse.AutoMapperConfig
{
    public static class AutoMapperConfiguration
    {
        public static void Init()
        {
            
             MapperConfiguration = new MapperConfiguration(cfg =>
            {

                #region Post
                //将领域实体映射到视图实体
                //                cfg.CreateMap<T_Sys_User, UserViewModel>()
                //                    .ForMember(d => d.IsDeleted, d => d.MapFrom(s => s.IsDeleted ? "是" : "否")) //将布尔类型映射成字符串类型的是/否
                //                    ;
                //将视图实体映射到领域实体
                //  cfg.CreateMap<PostViewModel, Post>();
                #endregion

                #region User

                cfg.CreateMap<T_Sys_User, UserViewModel>();
                cfg.CreateMap<UserViewModel, T_Sys_User>();
                #endregion
            });

            Mapper = MapperConfiguration.CreateMapper();
        }

        public static IMapper Mapper { get; private set; }

        public static MapperConfiguration MapperConfiguration { get; private set; }
    }
}
