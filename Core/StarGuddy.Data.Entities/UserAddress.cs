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
        public Guid Id { get; set; }

        public Guid UserId { get; set; }

        public Boolean IsActive { get; set; }

        public Boolean IsDeleted { get; set; }

        public Int32 AccessFailedCount { get; set; }

        public String AppOrHouseName { get; set; }

        public String CityOrTown { get; set; }

        public String Country { get; set; }

        public String Flat { get; set; }

        public String LandMark { get; set; }

        public String LineOne { get; set; }

        public String LineTwo { get; set; }

        public String StateOrProvince { get; set; }

        public String ZipOrPostalCode { get; set; }

        public DateTime DttmCreated { get; set; }

        public DateTime DttmModified { get; set; }
    }
}
