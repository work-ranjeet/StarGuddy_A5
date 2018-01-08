// -------------------------------------------------------------------------------
// <copyright file="User.cs" company="StarGuddy India">
// Copyright (c) 2017. All rights reserved.
// </copyright>
// -------------------------------------------------------------------------------
// File Description:
// =================  
// This class file contains properties of customer details.
// -------------------------------------------------------------------------------
// Author: Ranjeet Kumar
// Date Created: 01/01/2018
// -------------------------------------------------------------------------------
// Change History:
// ===============
// Date Changed: 
// Change Description:
// -------------------------------------------------------------------------------
namespace StarGuddy.Data.Entities
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using StarGuddy.Data.Entities.Interface;

    /// <summary>
    /// User class.
    /// </summary>
    /// <seealso cref="Object" />
    public class User : IUser
    {
        public Guid Id { get; set; }

        public Boolean IsActive { get; set; }

        public Boolean IsDeleted { get; set; }

        public Int32 AccessFailedCount { get; set; }

        public String ConcurrencyStamp { get; set; }

        public String Email { get; set; }

        public Boolean EmailConfirmed { get; set; }

        public String FirstName { get; set; }

        public String Gender { get; set; }

        public Boolean IsCastingProfessional { get; set; }

        public String LastName { get; set; }

        public Boolean LockoutEnabled { get; set; }

        public DateTimeOffset? LockoutEnd { get; set; }

        public String NormalizedEmail { get; set; }

        public String NormalizedUserName { get; set; }

        public String Designation { get; set; }

        public String OrgName { get; set; }

        public String OrgWebsite { get; set; }

        public String PasswordHash { get; set; }

        public String PhoneNumber { get; set; }

        public Boolean PhoneNumberConfirmed { get; set; }

        public String SecurityStamp { get; set; }

        public Boolean TwoFactorEnabled { get; set; }

        public String UserName { get; set; }

        public DateTime DttmCreated { get; set; }

        public DateTime DttmModified { get; set; }
    }
}
