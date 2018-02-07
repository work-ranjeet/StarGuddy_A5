// -------------------------------------------------------------------------------
// <copyright file="ApiInjection.cs" company="StarGuddy India">
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
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using StarGuddy.Api.Common;
using StarGuddy.Business.Interface.Account;
using StarGuddy.Business.Interface.Common;
using StarGuddy.Business.Interface.Files;
using StarGuddy.Business.Interface.Network;
using StarGuddy.Business.Modules.Account;
using StarGuddy.Business.Modules.Common;
using StarGuddy.Business.Modules.Files;
using StarGuddy.Business.Modules.Network;
using StarGuddy.Data.Entities;
using StarGuddy.Data.Entities.Interface;
using StarGuddy.Repository.Configuration;
using StarGuddy.Repository.Interfaces;
using StarGuddy.Repository.Operations;

namespace StarGuddy.Api
{
    /// <summary>
    /// API Injection
    /// </summary>
    public static class Injection
    {
        /// <summary>
        /// Injections the specified services.
        /// </summary>
        /// <param name="services">The services.</param>
        /// /// <param name="configuration">The Configuration.</param>
        public static void Inject(IServiceCollection services, IConfiguration configuration)
        {
            // Creating an singleton object and configuration file to this class
            services.AddSingleton<IConfigurationSingleton>(x => new ConfigurationSingleton(configuration));

            //// API Injection
            services.AddTransient<IJwtPacketManager, JwtPacketManager>();
            //services.AddTransient<ILoginData, LoginData>();
            //services.AddTransient<IUser, User>();

            //// Repository Injection
            services.AddTransient<IUserRepository, UserRepository>();

            //// Business Injection
            services.AddTransient<IAccountManager, AccountManager>();
            services.AddTransient<ISignupManager, SignupManager>();
            services.AddTransient<IUserManager, UserManager>();
            services.AddTransient<IPasswordManager, PasswordManager>();
            services.AddTransient<IImageManager, ImageManager>();
            services.AddTransient<ISecurityManager, SecurityManager>();
            services.AddTransient<IEmailManager, EmailManager>();
            services.AddTransient<IPhoneManager, PhoneManager>();
        }
    }

}
