// -------------------------------------------------------------------------------
// <copyright file="UserAddress.cs" company="StarGuddy India">
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
    /// User Address
    /// </summary>
    public interface IUserAddress
    {
        /// <summary>
        /// Gets or sets the user address identifier.
        /// </summary>
        /// <value>
        /// The user address identifier.
        /// </value>
        Guid Id { get; set; }

        /// <summary>
        /// Gets or sets the flat.
        /// </summary>
        /// <value>
        /// The flat.
        /// </value>
        string Flat { get; set; }

        /// <summary>
        /// Gets or sets the name of the application or house.
        /// </summary>
        /// <value>
        /// The name of the application or house.
        /// </value>
        string AppOrHouseName { get; set; }

        /// <summary>
        /// Gets or sets the line one.
        /// </summary>
        /// <value>
        /// The line one.
        /// </value>
        string LineOne { get; set; }

        /// <summary>
        /// Gets or sets the line two.
        /// </summary>
        /// <value>
        /// The line two.
        /// </value>
        string LineTwo { get; set; }

        /// <summary>
        /// Gets or sets the city or town.
        /// </summary>
        /// <value>
        /// The city or town.
        /// </value>
        string CityOrTown { get; set; }

        /// <summary>
        /// Gets or sets the state or province.
        /// </summary>
        /// <value>
        /// The state or province.
        /// </value>
        string StateOrProvince { get; set; }

        /// <summary>
        /// Gets or sets the zip or postal code.
        /// </summary>
        /// <value>
        /// The zip or postal code.
        /// </value>
        string ZipOrPostalCode { get; set; }

        /// <summary>
        /// Gets or sets the country.
        /// </summary>
        /// <value>
        /// The country.
        /// </value>
        string Country { get; set; }

        /// <summary>
        /// Gets or sets the land mark.
        /// </summary>
        /// <value>
        /// The land mark.
        /// </value>
        string LandMark { get; set; }

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

        /// <summary>
        /// Gets or sets the user identifier.
        /// </summary>
        /// <value>
        /// The user identifier.
        /// </value>
        string UserId { get; set; }
    }
}
