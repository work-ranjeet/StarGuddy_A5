// -------------------------------------------------------------------------------
// <copyright file="ImageManager.cs" company="StarGuddy India">
// Copyright (c) 2017. All rights reserved.
// </copyright>
// -------------------------------------------------------------------------------
namespace StarGuddy.Business.Modules.Profile
{
    using StarGuddy.Business.Interface.Profile;
    using StarGuddy.Data.Entities.Interface;
    using StarGuddy.Repository.Interface;
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Threading.Tasks;

    public class ProfileManager : IProfileManager
    {
        private IPhysicalAppearanceRepository _physicalAppearanceRepository;

        public ProfileManager(IPhysicalAppearanceRepository physicalAppearanceRepository)
        {
            this._physicalAppearanceRepository = physicalAppearanceRepository;
        }

        public async Task<bool> PerformSave(IPhysicalAppearance physicalAppearance)
        {
            return await this._physicalAppearanceRepository.PerformSaveOperation(physicalAppearance);
        }
    }
}
