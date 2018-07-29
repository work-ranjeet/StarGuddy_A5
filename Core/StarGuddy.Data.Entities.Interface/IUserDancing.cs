﻿using System;

namespace StarGuddy.Data.Entities.Interface
{
    public interface IUserDancing
    {
         Guid Id { get; set; }
         Guid UserId { get; set; }
         Int32 DanceAbilitiesId { get; set; }
         Int32? ChoreographyAbilitiesId { get; set; }
         Int32? AgentNeed { get; set; }
         Boolean IsAttendedSchool { get; set; }
         Boolean IsAgent { get; set; }
         String Experiance { get; set; }
         Boolean IsActive { get; set; }
         Boolean IsDeleted { get; set; }
         DateTime? DttmCreated { get; set; }
         DateTime? DttmModified { get; set; }
    }
}
