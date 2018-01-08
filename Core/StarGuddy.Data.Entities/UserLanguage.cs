using System;
namespace StarGuddy.Data.Entities
{
    public class UserLanguage
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public Int64 LanguagesId { get; set; }
        public Boolean IsActive { get; set; }
        public Boolean IsDeleted { get; set; }
        public DateTime DttmCreated { get; set; }
        public DateTime DttmModified { get; set; }
    }
}

