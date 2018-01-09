// -------------------------------------------------------------------------------
// <copyright file="PhysicalAppearance.cs" company="StarGuddy India">
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
    using System.Collections.Generic;
    using System.Text;

    /// <summary>
    /// Physical Appearance
    /// </summary>
    public interface IPhysicalAppearance
    {

        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        Guid Id { get; set; }

        /// <summary>
        /// Gets or sets the user identifier.
        /// </summary>
        /// <value>
        /// The user identifier.
        /// </value>
        Guid UserId { get; set; }

        /// <summary>
        /// Gets or sets the type of the body.
        /// </summary>
        /// <value>
        /// The type of the body.
        /// </value>
        Int32 BodyType { get; set; }

        /// <summary>
        /// Gets or sets the chest.
        /// </summary>
        /// <value>
        /// The chest.
        /// </value>
        Int32 Chest { get; set; }

        /// <summary>
        /// Gets or sets the color of the eye.
        /// </summary>
        /// <value>
        /// The color of the eye.
        /// </value>
        Int32 EyeColor { get; set; }

        /// <summary>
        /// Gets or sets the color of the hair.
        /// </summary>
        /// <value>
        /// The color of the hair.
        /// </value>
        Int32 HairColor { get; set; }

        /// <summary>
        /// Gets or sets the length of the hair.
        /// </summary>
        /// <value>
        /// The length of the hair.
        /// </value>
        Int32 HairLength { get; set; }

        /// <summary>
        /// Gets or sets the type of the hair.
        /// </summary>
        /// <value>
        /// The type of the hair.
        /// </value>
        Int32 HairType { get; set; }

        /// <summary>
        /// Gets or sets the color of the skin.
        /// </summary>
        /// <value>
        /// The color of the skin.
        /// </value>
        Int32 SkinColor { get; set; }

        /// <summary>
        /// Gets or sets the height.
        /// </summary>
        /// <value>
        /// The height.
        /// </value>
        Int32 Height { get; set; }

        /// <summary>
        /// Gets or sets the weight.
        /// </summary>
        /// <value>
        /// The weight.
        /// </value>
        Int32 Weight { get; set; }

        /// <summary>
        /// Gets or sets the west.
        /// </summary>
        /// <value>
        /// The west.
        /// </value>
        Int32 West { get; set; }

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
