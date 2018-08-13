using StarGuddy.Api.Models.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace StarGuddy.Api.Models.Profile
{
    public class UserActingModel
    {
        public Guid Id { get; set; }

        public Guid UserId { get; set; }

        public int ActingExperianceCode { get; set; }

        public string ActingExperiance { get; set; }

        public int AgentNeedCode { get; set; }

        public string Experiance { get; set; }

        public List<Language> Languages { get; set; }

        public List<Accents> Accents { get; set; }

        public List<AuditionsAndJobsGroup> AuditionsAndJobsGroup { get; set; }
    }
}
