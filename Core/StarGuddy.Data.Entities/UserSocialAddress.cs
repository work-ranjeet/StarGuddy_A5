using System;
namespace StarGuddy.Data.Entities
{
    public class UserSocialAddress
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public Int64 SocialAddressId { get; set; }
        public String SocialUserName { get; set; }
        public Int32 STATUS { get; set; }
        public Boolean IsActive { get; set; }
        public Boolean IsDeleted { get; set; }
        public DateTime DttmCreated { get; set; }
        public DateTime DttmModified { get; set; }
    }
}

