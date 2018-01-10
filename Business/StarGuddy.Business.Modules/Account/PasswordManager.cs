
namespace StarGuddy.Business.Modules.Account
{
    using StarGuddy.Business.Interface.Account;
    using StarGuddy.Repository.Interfaces;
    using System;
    using System.Collections.Generic;
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

    }
}
