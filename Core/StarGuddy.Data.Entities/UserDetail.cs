namespace StarGuddy.Data.Entities
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class UserDetail
    {
        public Guid Id { get; set; }

        public Guid UserId { get; set; }

        public String About { get; set; }

        public Int32 Age { get; set; }

        public Int32 BloodGroup { get; set; }

        public DateTime DateOfBirth { get; set; }

        public String Disability { get; set; }

        public String HealthInfo { get; set; }

        public Int32 MaritalStatus { get; set; }

        public String MotherTongue { get; set; }

        public String Nickname { get; set; }

        public String ProfileAddress { get; set; }

        public String Religion { get; set; }

        public Boolean IsActive { get; set; }

        public Boolean IsDeleted { get; set; }

        public DateTime DttmCreated { get; set; }

        public DateTime DttmModified { get; set; }
    }

}
