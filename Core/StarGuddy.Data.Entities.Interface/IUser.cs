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
namespace StarGuddy.Data.Entities.Interface
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    /// <summary>
    /// User class.
    /// </summary>
    /// <seealso cref="Object" />
    public interface IUser
    {
         Guid Id { get; set; }

         Boolean IsActive { get; set; }

         Boolean IsDeleted { get; set; }

         Int32 AccessFailedCount { get; set; }

         String ConcurrencyStamp { get; set; }

         String Email { get; set; }

         Boolean EmailConfirmed { get; set; }

         String FirstName { get; set; }

         String Gender { get; set; }

         Boolean IsCastingProfessional { get; set; }

         String LastName { get; set; }

         Boolean LockoutEnabled { get; set; }

         DateTimeOffset? LockoutEnd { get; set; }

         String NormalizedEmail { get; set; }

         String NormalizedUserName { get; set; }

         String Designation { get; set; }

         String OrgName { get; set; }

         String OrgWebsite { get; set; }

         String PasswordHash { get; set; }

         String PhoneNumber { get; set; }

         Boolean PhoneNumberConfirmed { get; set; }

         String SecurityStamp { get; set; }

         Boolean TwoFactorEnabled { get; set; }

         String UserName { get; set; }

         DateTime DttmCreated { get; set; }

         DateTime DttmModified { get; set; }
    }
}
