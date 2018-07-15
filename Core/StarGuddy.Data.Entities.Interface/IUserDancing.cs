using System;

namespace StarGuddy.Data.Entities.Interface
{
    public interface IUserDancing
    {
        Guid Id { get; set; }
        Guid UserId { get; set; }
        Int64 Style { get; set; }
        Int32 ExpertLavelId { get; set; }
        Boolean IsAttendedSchool { get; set; }
        Guid CreditId { get; set; }
        Boolean IsAgent { get; set; }
        Int32? AgentNeedId { get; set; }
        String Experiance { get; set; }
        Boolean IsActive { get; set; }
        Boolean IsDeleted { get; set; }
        DateTime? DttmCreated { get; set; }
        DateTime? DttmModified { get; set; }
    }
}
