using StarGuddy.Data.Entities.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace StarGuddy.Data.Entities
{
    public class UserActingDetail 
    {
        public IUserActing UserActing { get; set; }

        public IEnumerable<Language> Languages { get; set; }

        public IEnumerable<Accents> Accents { get; set; }

        public IEnumerable<AuditionsAndJobsGroup> AuditionsAndJobsGroup { get; set; }
    }
}
