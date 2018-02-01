
namespace StarGuddy.Business.Interface.Account
{
    using StarGuddy.Api.Models.Interface.Account;
    using System;
    using System.Collections.Generic;
    using System.Text;

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
