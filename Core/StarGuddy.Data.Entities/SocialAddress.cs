﻿using System;namespace StarGuddy.Data.Entities
{
    /// <summary>
    /// 
    /// </summary>
    public class SocialAddress
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        public Int64 Id { get; set; }

        /// <summary>
        /// Gets or sets the help URL.
        /// </summary>
        /// <value>
        /// The help URL.
        /// </value>
        public String HelpUrl { get; set; }

        /// <summary>
        /// Gets or sets the icon class.
        /// </summary>
        /// <value>
        /// The icon class.
        /// </value>
        public String IconClass { get; set; }

        /// <summary>
        /// Gets or sets the post label.
        /// </summary>
        /// <value>
        /// The post label.
        /// </value>
        public String PostLabel { get; set; }

        /// <summary>
        /// Gets or sets the post URL.
        /// </summary>
        /// <value>
        /// The post URL.
        /// </value>
        public String PostUrl { get; set; }

        /// <summary>
        /// Gets or sets the pre URL.
        /// </summary>
        /// <value>
        /// The pre URL.
        /// </value>
        public String PreUrl { get; set; }

        /// <summary>
        /// Gets or sets the name of the social.
        /// </summary>
        /// <value>
        /// The name of the social.
        /// </value>
        public String SocialName { get; set; }

        /// <summary>
        /// Gets or sets the status.
        /// </summary>
        /// <value>
        /// The status.
        /// </value>
        public Int32 Status { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is active.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is active; otherwise, <c>false</c>.
        /// </value>
        public Boolean IsActive { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is deleted.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is deleted; otherwise, <c>false</c>.
        /// </value>
        public Boolean IsDeleted { get; set; }
    }}
