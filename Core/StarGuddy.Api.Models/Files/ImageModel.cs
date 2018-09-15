// -------------------------------------------------------------------------------
// <copyright file="ImageModel.cs" company="StarGuddy India">
// Copyright (c) 2017. All rights reserved.
// </copyright>
// -------------------------------------------------------------------------------
namespace StarGuddy.Api.Models.Files
{
    
    #region name-space
    using System;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Http.Internal;
    #endregion

    /// <summary>
    /// Image Model
    /// </summary>
    public class ImageModel
    {
        public Guid Id { get; set; }

        public Guid UserId { get; set; }

        public string Name { get; set; }

        public string Caption { get; set; }

        public string ImageUrl { get; set; }

        public long Size { get; set; }

        //public FormFile FileToUpload { get; set; }
    }
}
