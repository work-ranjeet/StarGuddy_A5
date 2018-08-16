﻿
using Models = StarGuddy.Api.Models.Dto;
using StarGuddy.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

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
            CreateMap<AuditionsAndJobsGroup, Models.AuditionsAndJobsGroupDto>().ReverseMap();
        }
    }
}
