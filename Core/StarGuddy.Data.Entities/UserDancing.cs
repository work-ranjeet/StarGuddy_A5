using StarGuddy.Data.Entities.Interface;
using System;

namespace StarGuddy.Data.Entities
{
    public class UserDancing : IUserDancing
    {
        public Guid Id { get; set; }

        public Guid UserId { get; set; }

        public Int64 Style { get; set; }

        public Int32 ExpertLavelId { get; set; }

        public Boolean IsAttendedSchool { get; set; }

        public Guid CreditId { get; set; }

        public Boolean IsAgent { get; set; }

        public Int32? AgentNeedId { get; set; }

        public String Experiance { get; set; }

        public Boolean IsActive { get; set; }

        public Boolean IsDeleted { get; set; }

        public DateTime? DttmCreated { get; set; }

        public DateTime? DttmModified { get; set; }
    }
}
