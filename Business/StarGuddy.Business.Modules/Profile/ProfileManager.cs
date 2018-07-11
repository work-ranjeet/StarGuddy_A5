// -------------------------------------------------------------------------------
// <copyright file="ImageManager.cs" company="StarGuddy India">
// Copyright (c) 2017. All rights reserved.
// </copyright>
// -------------------------------------------------------------------------------
namespace StarGuddy.Business.Modules.Profile
{
    using StarGuddy.Api.Models.Interface.Profile;
    using StarGuddy.Api.Models.Profile;
    using StarGuddy.Business.Interface.Profile;
    using StarGuddy.Data.Entities;
    using StarGuddy.Repository.Interface;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Collections.Concurrent;
    using System.Threading.Tasks;
    using StarGuddy.Core.Constants;
    using StarGuddy.Data.Entities.Interface;

    public class ProfileManager : IProfileManager
    {
        private IUserCreditsRepository _userCreditsRepository;
        private IPhysicalAppearanceRepository _physicalAppearanceRepository;

        public ProfileManager(IPhysicalAppearanceRepository physicalAppearanceRepository, IUserCreditsRepository userCreditsRepository)
        {
            this._userCreditsRepository = userCreditsRepository;
            this._physicalAppearanceRepository = physicalAppearanceRepository;
        }

        public async Task<IPhysicalAppearanceModal> GetPhysicalAppreance(Guid userId)
        {
            var result = await this._physicalAppearanceRepository.GetPhysicalAppreanceById(userId);
            return new PhysicalAppearanceModal
            {
                BodyType = result.BodyType,
                Chest = result.Chest,
                Ethnicity = result.Ethnicity,
                EyeColor = result.EyeColor,
                HairColor = result.HairColor,
                HairLength = result.HairLength,
                HairType = result.HairType,
                Height = result.Height,
                SkinColor = result.SkinColor,
                UserId = result.UserId,
                Weight = result.Weight,
                West = result.West
            };
        }

        public async Task<bool> PerformSave(IPhysicalAppearanceModal phyAppModal)
        {
            var physicalAppreance = new PhysicalAppearance
            {
                BodyType = phyAppModal.BodyType,
                Chest = phyAppModal.Chest,
                Ethnicity = phyAppModal.Ethnicity,
                EyeColor = phyAppModal.EyeColor,
                HairColor = phyAppModal.HairColor,
                HairLength = phyAppModal.HairLength,
                HairType = phyAppModal.HairType,
                Height = phyAppModal.Height,
                IsActive = true,
                IsDeleted = false,
                SkinColor = phyAppModal.SkinColor,
                UserId = phyAppModal.UserId,
                Weight = phyAppModal.Weight,
                West = phyAppModal.West
            };

            return await this._physicalAppearanceRepository.PerformSaveOperation(physicalAppreance);
        }

        public async Task<IEnumerable<IUserCreditModel>> GetUserCredits(Guid userId)
        {
            var result = await this._userCreditsRepository.GetUserCreditsById(userId);
            if (result != null && result.Any())
            {
                var creditBag = new ConcurrentBag<IUserCreditModel>();
                result.ToList().ForEach(credit =>
                {
                    creditBag.Add(new UserCreditModel
                    {
                        Id = credit.Id,
                        Action = DbOperation.NoAction,
                        WorkYear = credit.Year,
                        WorkPlace = credit.WorkPlace,
                        WorkDetail = credit.WorkDetail
                    });
                });

                return creditBag.AsEnumerable();
            }

            return null;
        }

        public async Task<bool> SaveUserCredits(Guid UserId, List<UserCreditModel> userCreditModelList)
        {
            if (userCreditModelList != null && userCreditModelList.Any())
            {
                var saveUpdateBag = new ConcurrentBag<IUserCredits>();
                userCreditModelList.AsParallel().ForAll(credit =>
                {
                    if (credit.Action == DbOperation.Insert || credit.Action == DbOperation.Update)
                    {
                        saveUpdateBag.Add(new UserCredits
                        {
                            UserId = UserId,
                            Year = credit.WorkYear,
                            WorkPlace = credit.WorkPlace,
                            WorkDetail = credit.WorkDetail
                        });
                    }
                });

                if (saveUpdateBag.Any())
                {
                    return await this._userCreditsRepository.PerformMaultipleSaveOperation(saveUpdateBag);
                }
            }

            return false;
        }

        public async Task<bool> DeleteUserCredits(Guid Id)
        {
            if (Id == Guid.Empty)
            {
                throw new Exception("Request Parameter is empty : " + Id.ToString());
            }

            return await this._userCreditsRepository.PerformDeleteOperation(Id);
        }
    }
}
