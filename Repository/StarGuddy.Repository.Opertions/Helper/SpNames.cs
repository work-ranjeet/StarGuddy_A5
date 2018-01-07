// -------------------------------------------------------------------------------
// <copyright file="SpNames.cs" company="StarGuddy India">
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
namespace StarGuddy.Repository.Opertions.Helper
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    /// <summary>
    /// Store Procedure Name
    /// </summary>
    public class SpNames
    {
        /// <summary>
        /// User Structure
        /// </summary>
        public struct User
        {
            public const string AddNewUser = "AddNewUser";
            public const string UpdateUser = "UpdateUser";

            public const string GetVarifiedUser = "GetVarifiedUser";
        }
    }
}
