// -------------------------------------------------------------------------------
// <copyright file="Accents.cs" company="StarGuddy India">
// Copyright (c) 2018. All rights reserved.
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

    /// <summary>
    /// Accent class
    /// </summary>
    public interface IAccents
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        Int64 Id { get; set; }

        /// <summary>
        /// Gets or sets the accent.
        /// </summary>
        /// <value>
        /// The accent.
        /// </value>
        String Accent { get; set; }

        /// <summary>
        /// Gets or sets the status.
        /// </summary>
        /// <value>
        /// The status.
        /// </value>
        Int32 Status { get; set; }

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
    }
    
}
