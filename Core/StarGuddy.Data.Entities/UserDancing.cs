﻿using StarGuddy.Data.Entities.Interface;
using System;

namespace StarGuddy.Data.Entities
{
    public class UserDancing : IUserDancing
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public Int32 DanceAbilitiesId { get; set; }
        public Int32? ChoreographyAbilitiesId { get; set; }
        public Int32? AgentNeed { get; set; }
        public Boolean IsAttendedSchool { get; set; }
        public Boolean IsAgent { get; set; }
        public String Experiance { get; set; }
        public Boolean IsActive { get; set; }
        public Boolean IsDeleted { get; set; }
        public DateTime? DttmCreated { get; set; }
        public DateTime? DttmModified { get; set; }
    }
}
