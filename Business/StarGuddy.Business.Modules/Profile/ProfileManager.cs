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
    using StarGuddy.Core.Constants;
    using StarGuddy.Core.Enums;
    using StarGuddy.Data.Entities;
    using StarGuddy.Data.Entities.Interface;
    using StarGuddy.Repository.Interface;
    using System;
    using System.Collections.Concurrent;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class ProfileManager : IProfileManager
    {
        private readonly IUserCreditsRepository userCreditsRepository;
        private readonly IPhysicalAppearanceRepository physicalAppearanceRepository;
        private readonly IUserDancingRepository userDancingRepository;

        public ProfileManager(
            IPhysicalAppearanceRepository physicalAppearanceRepository,
            IUserCreditsRepository userCreditsRepository,
            IUserDancingRepository userDancingRepository)
        {
            this.userDancingRepository = userDancingRepository;
            this.userCreditsRepository = userCreditsRepository;
            this.physicalAppearanceRepository = physicalAppearanceRepository;
        }

        #region /// Physical Appearance
        public async Task<IPhysicalAppearanceModal> GetPhysicalAppreance(Guid userId)
        {
            var result = await this.physicalAppearanceRepository.GetPhysicalAppreanceById(userId);
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

            return await this.physicalAppearanceRepository.PerformSaveOperation(physicalAppreance);
        }
        #endregion

        #region /// User credits
        public async Task<IEnumerable<IUserCreditModel>> GetUserCredits(Guid userId)
        {
            var result = await this.userCreditsRepository.GetUserCreditsById(userId);
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
                    return await this.userCreditsRepository.PerformMaultipleSaveOperation(saveUpdateBag);
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

            return await this.userCreditsRepository.PerformDeleteOperation(Id);
        }
        #endregion

        #region /// User dancing
        public async Task<DancingModel> GetUserDancingAsync(Guid userId)
        {
            var dancingModel = new DancingModel()
            {
                AgentNeed = 0,
                DanceAbilities = 0,
                ChoreographyAbilities = 0,
                DanceAbilitiesText = ExpertLavel.Beginner.ToString(),
                ChoreographyAbilitiesText = ExpertLavel.Beginner.ToString(),
                HasDanceStyle = false,
                DnacingStyles = new ConcurrentBag<Api.Models.Common.DancingStyle>()
            };

            var userDancing = await userDancingRepository.GetUserDancingAsync(userId);

            var dancingStyle = await userDancingRepository.GetDancingStyleSelectedAsync(userId);

            //await Task.WhenAll(userDancing, dancingStyle);

            if (userDancing != null)//&& userDancing.IsCompletedSuccessfully)
            {
                dancingModel = new DancingModel
                {
                    Id = userDancing.Id,
                    AgentNeed = userDancing.AgentNeed ?? 0,
                    DanceAbilities = userDancing.DanceAbilitiesId,
                    ChoreographyAbilities = userDancing.ChoreographyAbilitiesId ?? 0,
                    DanceAbilitiesText = ((ExpertLavel)userDancing.DanceAbilitiesId).ToString(),
                    ChoreographyAbilitiesText = ((ExpertLavel)userDancing.ChoreographyAbilitiesId).ToString(),
                    IsAgent = userDancing.IsAgent,
                    IsAttendedSchool = userDancing.IsAttendedSchool,
                    Experience = userDancing.Experiance,
                    UserId = userDancing.UserId,
                    DnacingStyles = new ConcurrentBag<Api.Models.Common.DancingStyle>()
                };
            }

            if (dancingStyle != null)// && dancingStyle.IsCompletedSuccessfully)
            {

                var danceStyle = dancingStyle.Select(x =>
                {
                    return new Api.Models.Common.DancingStyle
                    {
                        Id = x.Id,
                        Name = x.Style,
                        SelectedValue = x.SelectedValue,
                        Value = x.Value
                    };
                });

                danceStyle.ToList().ForEach(x => dancingModel.DnacingStyles.Add(x));

                dancingModel.HasDanceStyle = dancingModel.DnacingStyles.Any(x => (x.SelectedValue ?? 0) > 0);
            }

            return dancingModel;
        }
        public async Task<bool> SaveUserDancingAsync(DancingModel dancingModel)
        {
            if (dancingModel != null)
            {
                var userDancing = new UserDancing
                {
                    Id = dancingModel.Id,
                    UserId = dancingModel.UserId,
                    ChoreographyAbilitiesId = dancingModel.ChoreographyAbilities,
                    AgentNeed = dancingModel.AgentNeed,
                    Experiance = dancingModel.Experience,
                    DanceAbilitiesId = dancingModel.DanceAbilities,
                    IsAttendedSchool = dancingModel.IsAttendedSchool,
                    IsAgent = dancingModel.IsAgent,
                    IsActive = true,
                    IsDeleted = false
                };

                var danceStyleIds = new ConcurrentBag<long>();
                if (dancingModel.DnacingStyles != null && dancingModel.DnacingStyles.Any())
                {
                    dancingModel.DnacingStyles.AsParallel().ForAll(x => danceStyleIds.Add(x.SelectedValue ?? 0));
                }

                return await userDancingRepository.PerformSaveAndUpdateOperationAsync(userDancing, danceStyleIds);
            }

            return false;
        }
        #endregion
    }
}
