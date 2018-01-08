using System;
namespace StarGuddy.Data.Entities
{
    public class UserAsent
    {
        public Guid Id { get; set; }

        public Guid UserId { get; set; }

        public Int64 AccentsId { get; set; }

        public Boolean IsActive { get; set; }

        public Boolean IsDeleted { get; set; }

        public DateTime DttmCreated { get; set; }

        public DateTime DttmModified { get; set; }
    }
}

