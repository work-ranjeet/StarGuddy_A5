// -------------------------------------------------------------------------------
// <copyright file="ImageManager.cs" company="StarGuddy India">
// Copyright (c) 2017. All rights reserved.
// </copyright>
// -------------------------------------------------------------------------------
namespace StarGuddy.Business.Interface.Common
{
    using StarGuddy.Api.Models.Interface.Account;

    /// <summary>
    /// Password Manager Interface
    /// </summary>
    public interface IPasswordManager
    {

        /// <summary>
        /// Changes the password.
        /// </summary>
        /// <param name="pwdModel">The password model.</param>
        /// <returns></returns>
        bool ChangePassword(IPasswordModel pwdModel);
    }
}
