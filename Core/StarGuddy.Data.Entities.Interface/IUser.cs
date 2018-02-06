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
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        Guid Id { get; set; }

        /// <summary>
        /// Gets or sets the name of the user.
        /// </summary>
        /// <value>
        /// The name of the user.
        /// </value>
        String UserName { get; set; }

        /// <summary>
        /// Gets or sets the access failed count.
        /// </summary>
        /// <value>
        /// The access failed count.
        /// </value>
        Int32 AccessFailedCount { get; set; }

        /// <summary>
        /// Gets or sets the concurrency stamp.
        /// </summary>
        /// <value>
        /// The concurrency stamp.
        /// </value>
        String ConcurrencyStamp { get; set; }

        /// <summary>
        /// Gets or sets the first name.
        /// </summary>
        /// <value>
        /// The first name.
        /// </value>
        String FirstName { get; set; }

        /// <summary>
        /// Gets or sets the gender.
        /// </summary>
        /// <value>
        /// The gender.
        /// </value>
        String Gender { get; set; }

        /// <summary>
        /// Gets or sets the last name.
        /// </summary>
        /// <value>
        /// The last name.
        /// </value>
        String LastName { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether [lockout enabled].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [lockout enabled]; otherwise, <c>false</c>.
        /// </value>
        Boolean LockoutEnabled { get; set; }

        /// <summary>
        /// Gets or sets the lockout end.
        /// </summary>
        /// <value>
        /// The lockout end.
        /// </value>
        DateTimeOffset? LockoutEnd { get; set; }

        /// <summary>
        /// Gets or sets the designation.
        /// </summary>
        /// <value>
        /// The designation.
        /// </value>
        String Designation { get; set; }

        /// <summary>
        /// Gets or sets the name of the ORG.
        /// </summary>
        /// <value>
        /// The name of the ORG.
        /// </value>
        String OrgName { get; set; }

        /// <summary>
        /// Gets or sets the ORG website.
        /// </summary>
        /// <value>
        /// The ORG website.
        /// </value>
        String OrgWebsite { get; set; }

        /// <summary>
        /// Gets or sets the password hash.
        /// </summary>
        /// <value>
        /// The password hash.
        /// </value>
        String PasswordHash { get; set; }

        /// <summary>
        /// Gets or sets the security stamp.
        /// </summary>
        /// <value>
        /// The security stamp.
        /// </value>
        String SecurityStamp { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is casting professional.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is casting professional; otherwise, <c>false</c>.
        /// </value>
        Boolean IsCastingProfessional { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is two factor enabled.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is two factor enabled; otherwise, <c>false</c>.
        /// </value>
        Boolean IsTwoFactorEnabled { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is active.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is active; otherwise, <c>false</c>.
        /// </value>
        Boolean IsActive { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is deleted.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is deleted; otherwise, <c>false</c>.
        /// </value>
        Boolean IsDeleted { get; set; }

        /// <summary>
        /// Gets or sets the address detail.
        /// </summary>
        /// <value>
        /// The address detail.
        /// </value>
        IUserAddress AddressDetail { get; set; }

        /// <summary>
        /// Gets or sets the email detail.
        /// </summary>
        /// <value>
        /// The email detail.
        /// </value>
        IUserEmails EmailDetail { get; set; }

        /// <summary>
        /// Gets or sets the phone details.
        /// </summary>
        /// <value>
        /// The phone details.
        /// </value>
        IUserPhones PhoneDetails { get; set; }

        /// <summary>
        /// Gets or sets the DTTM created.
        /// </summary>
        /// <value>
        /// The DTTM created.
        /// </value>
        DateTime DttmCreated { get; set; }

        /// <summary>
        /// Gets or sets the DTTM modified.
        /// </summary>
        /// <value>
        /// The DTTM modified.
        /// </value>
        DateTime DttmModified { get; set; }
    }
}
