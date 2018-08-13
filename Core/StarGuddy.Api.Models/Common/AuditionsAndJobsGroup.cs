// -------------------------------------------------------------------------------
// <copyright file="AuditionsAndJobsGroup.cs" company="StarGuddy India">
// Copyright (c) 2018. All rights reserved.
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
namespace StarGuddy.Api.Models.Common
{
    using System;
    public class AuditionsAndJobsGroup
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public int Code { get; set; }
        public int SelectedCode { get; set; }
        public string Detail { get; set; }
        public int DisplayOrder { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime? DttmCreated { get; set; }
        public DateTime? DttmModified { get; set; }
    }
}
