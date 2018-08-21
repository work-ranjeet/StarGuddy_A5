
using Models = StarGuddy.Api.Models.Dto;
using StarGuddy.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using StarGuddy.Api.Models.Profile;
using StarGuddy.Api.Models.Account;

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
        }
    }
}
