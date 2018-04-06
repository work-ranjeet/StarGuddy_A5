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
namespace StarGuddy.Repository.Opertions.Constants
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    /// <summary>
    /// Store Procedure Name
    /// </summary>
    public partial class SpNames
    {
        /// <summary>
        /// User Structure
        /// </summary>
        public struct User
        {
            /// <summary>
            /// The add new user
            /// </summary>
            public const string AddNewUser = "AddNewUser";

            /// <summary>
            /// The update user
            /// </summary>
            public const string UpdateUser = "UpdateUser";

            /// <summary>
            /// The get verified user
            /// </summary>
            public const string GetVarifiedUser = "GetVarifiedUser";
        }

        public struct UserEmails
        {
            public const string UpdateEmail = "UpdateEmail";
        }
    }
}
