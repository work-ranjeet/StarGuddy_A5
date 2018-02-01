
namespace StarGuddy.Business.Modules.Account
{
    using StarGuddy.Api.Models.Account;
    using StarGuddy.Api.Models.Interface.Account;
    using StarGuddy.Business.Interface.Account;
    using StarGuddy.Repository.Interfaces;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    /// <summary>
    /// Password Manager
    /// </summary>
    public class PasswordManager : IPasswordManager
    {
        /// <summary>
        /// The user repository
        /// </summary>
        private IUserRepository userRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="SignupManager"/> class.
        /// </summary>
        /// <param name="signupManager">The user repository.</param>
        public PasswordManager(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }

        /// <summary>
        /// Changes the password.
        /// </summary>
        /// <param name="pwdModel">The password model.</param>
        /// <returns></returns>
        public bool ChangePassword(IPasswordModel pwdModel)
        {
            if(pwdModel.NewPassword != pwdModel.ConfirmPassword)
            {
                return false;
            }

            var isValidPwd = this.userRepository.GetVerifiedUser(pwdModel.Email, pwdModel.OldPassword).Where(x => x.LockoutEnabled == false).Any();
            if(isValidPwd)
            {
                var result = this.userRepository.UpdatePassword(pwdModel.UserName, pwdModel.NewPassword);
                return result > decimal.Zero;
            }

            return false;
        }
    }
}
