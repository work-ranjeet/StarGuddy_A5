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
namespace StarGuddy.Data.Entities
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using StarGuddy.Data.Entities.Interface;

    /// <summary>
    /// User Address
    /// </summary>
    public class UserAddress : IUserAddress
    {
        /// <summary>
        /// Gets or sets the user address identifier.
        /// </summary>
        /// <value>
        /// The user address identifier.
        /// </value>
        public Guid Id { get; set; }

        /// <summary>
        /// Gets or sets the flat.
        /// </summary>
        /// <value>
        /// The flat.
        /// </value>
        public string Flat { get; set; }

        /// <summary>
        /// Gets or sets the name of the application or house.
        /// </summary>
        /// <value>
        /// The name of the application or house.
        /// </value>
        public string AppOrHouseName { get; set; }

        /// <summary>
        /// Gets or sets the line one.
        /// </summary>
        /// <value>
        /// The line one.
        /// </value>
        public string LineOne { get; set; }

        /// <summary>
        /// Gets or sets the line two.
        /// </summary>
        /// <value>
        /// The line two.
        /// </value>
        public string LineTwo { get; set; }

        /// <summary>
        /// Gets or sets the city or town.
        /// </summary>
        /// <value>
        /// The city or town.
        /// </value>
        public string CityOrTown { get; set; }

        /// <summary>
        /// Gets or sets the state or province.
        /// </summary>
        /// <value>
        /// The state or province.
        /// </value>
        public string StateOrProvince { get; set; }

        /// <summary>
        /// Gets or sets the zip or postal code.
        /// </summary>
        /// <value>
        /// The zip or postal code.
        /// </value>
        public string ZipOrPostalCode { get; set; }

        /// <summary>
        /// Gets or sets the country.
        /// </summary>
        /// <value>
        /// The country.
        /// </value>
        public string Country { get; set; }

        /// <summary>
        /// Gets or sets the land mark.
        /// </summary>
        /// <value>
        /// The land mark.
        /// </value>
        public string LandMark { get; set; }

        /// <summary>
        /// Gets or sets the DTTM created.
        /// </summary>
        /// <value>
        /// The DTTM created.
        /// </value>
        public DateTime DttmCreated { get; set; } = DateTime.UtcNow;

        /// <summary>
        /// Gets or sets the DTTM modified.
        /// </summary>
        /// <value>
        /// The DTTM modified.
        /// </value>
        public DateTime DttmModified { get; set; } = DateTime.UtcNow;

        /// <summary>
        /// Gets or sets the user identifier.
        /// </summary>
        /// <value>
        /// The user identifier.
        /// </value>
        public string UserId { get; set; }
    }
}
