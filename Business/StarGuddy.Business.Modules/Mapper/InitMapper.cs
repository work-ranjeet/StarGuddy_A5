
using Models = StarGuddy.Api.Models.Common;
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
            CreateMap<Accents, Models.Accents>().ReverseMap();
            CreateMap<Language, Models.Language>().ReverseMap();
            CreateMap<AuditionsAndJobsGroup, Models.AuditionsAndJobsGroup>().ReverseMap();
        }
    }
}
