
using StarGuddy.Api.Models.Account;
using StarGuddy.Api.Models.Profile;
using StarGuddy.Api.Models.UserJobs;
using StarGuddy.Data.Entities;
using Models = StarGuddy.Api.Models.Dto;

namespace StarGuddy.Business.Modules.Mapper
{
    public class InitMapper : AutoMapper.Profile
    {
        public InitMapper()
        {
            this.InitAutoMapper();
        }

        private void InitAutoMapper()
        {
            CreateMap<Accents, Models.AccentsDto>().ReverseMap();
            CreateMap<Language, Models.LanguageDto>().ReverseMap();
            CreateMap<ActingRoles, Models.AuditionsAndJobsGroupDto>().ReverseMap();
            CreateMap<ModelingRoles, Models.AuditionsAndJobsGroupDto>().ReverseMap();
            CreateMap<UserModeling, UserModelingModel>().ReverseMap();
            CreateMap<UserSettings, UserSettingDto>().ReverseMap();
            CreateMap<JobGroup, JobGroupModel>().ReverseMap();

            
        }
    }
}
