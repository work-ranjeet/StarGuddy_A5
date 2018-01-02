using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace StarGuddy.Repository.Configuration
{
    /// <summary>
    /// Configuration Singleton
    /// </summary>
    /// <seealso cref="StarGuddy.Repository.Configuration.IConfigurationSingleton" />
    public class ConfigurationSingleton : IConfigurationSingleton
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ConfigurationSingleton"/> class.
        /// </summary>
        /// <param name="configuration">The configuration.</param>
        public ConfigurationSingleton(IConfiguration configuration)
        {
            this.Configuration = configuration;
        }       

        /// <summary>
        /// Get Connection string
        /// </summary>
        /// <value>
        /// The SQL connection string.
        /// </value>
        public string SQLConnectionString => this.Configuration.GetConnectionString("MSSQLServer");

        /// <summary>
        /// Gets or sets the configuration.
        /// </summary>
        /// <value>
        /// The configuration.
        /// </value>
        private IConfiguration Configuration { get; set; }

        /// <summary>
        /// Read startup configuration file
        /// </summary>
        /// <value>
        /// The configuration.
        /// </value>
        ////public IConfiguration Configuration => Startup.Configuration;              
    }
}
