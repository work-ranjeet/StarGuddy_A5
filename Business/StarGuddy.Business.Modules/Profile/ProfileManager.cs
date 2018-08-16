// -------------------------------------------------------------------------------
// <copyright file="ImageManager.cs" company="StarGuddy India">
// Copyright (c) 2017. All rights reserved.
// </copyright>
// -------------------------------------------------------------------------------
namespace StarGuddy.Business.Modules.Profile
{
    using AutoMapper;
    using StarGuddy.Api.Models.Dto;
    using StarGuddy.Api.Models.Interface.Profile;
    using StarGuddy.Api.Models.Profile;
    using StarGuddy.Business.Interface.Profile;
    using StarGuddy.Core.Constants;
    using StarGuddy.Core.Context;
    using StarGuddy.Core.Enums;
    using StarGuddy.Data.Entities;
    using StarGuddy.Data.Entities.Interface;
    using StarGuddy.Repository.Interface;
    using System;
    using System.Collections.Concurrent;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Models = Api.Models.Dto;

    public class ProfileManager : IProfileManager
    {
        private readonly IUserCreditsRepository _userCreditsRepository;
        private readonly IPhysicalAppearanceRepository _physicalAppearanceRepository;
        private readonly IUserDancingRepository _userDancingRepository;
        private readonly IUserActingRepository _userActingRepository;
        private readonly IMapper _mapper;

        public ProfileManager(
            IPhysicalAppearanceRepository physicalAppearanceRepository,
            IUserCreditsRepository userCreditsRepository,
            IUserDancingRepository userDancingRepository,
            IUserActingRepository userActingRepository,
            IMapper mapper)
        {
            _userDancingRepository = userDancingRepository;
            _userCreditsRepository = userCreditsRepository;
            _physicalAppearanceRepository = physicalAppearanceRepository;
            _userActingRepository = userActingRepository;
            _mapper = mapper;
            // InitMapper();
        }

        #region /// Physical Appearance
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
        #endregion

        #region /// User credits
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
                DnacingStyles = new List<DancingStyleDto>()
            };

            var userDancing = await _userDancingRepository.GetUserDancingAsync(userId);

            var dancingStyle = await _userDancingRepository.GetDancingStyleSelectedAsync(userId);

            //await Task.WhenAll(userDancing, dancingStyle);

            if (userDancing != null)//&& userDancing.IsCompletedSuccessfully)
            {
                dancingModel = new DancingModel
                {
                    Id = userDancing.Id,
                    AgentNeed = userDancing.AgentNeedCode ?? 0,
                    DanceAbilities = userDancing.DanceAbilitiesCode,
                    ChoreographyAbilities = userDancing.ChoreographyAbilitiesCode,
                    DanceAbilitiesText = ((ExpertLavel)userDancing.DanceAbilitiesCode).ToString(),
                    ChoreographyAbilitiesText = ((ExpertLavel)userDancing.ChoreographyAbilitiesCode).ToString(),
                    IsAgent = userDancing.IsAgent,
                    IsAttendedSchool = userDancing.IsAttendedSchool,
                    Experience = userDancing.Experiance,
                    UserId = userDancing.UserId,
                    DnacingStyles = new List<DancingStyleDto>()
                };
            }

            if (dancingStyle != null)// && dancingStyle.IsCompletedSuccessfully)
            {

                var danceStyle = dancingStyle.Select(x =>
                {
                    return new DancingStyleDto
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
                    UserId = UserContext.Current.UserId,
                    ChoreographyAbilitiesCode = dancingModel.ChoreographyAbilities,
                    AgentNeedCode = dancingModel.AgentNeed,
                    Experiance = dancingModel.Experience,
                    DanceAbilitiesCode = dancingModel.DanceAbilities,
                    IsAttendedSchool = dancingModel.IsAttendedSchool,
                    IsAgent = dancingModel.IsAgent,
                    IsActive = true,
                    IsDeleted = false
                };

                var danceStyleIds = new ConcurrentBag<long>();
                if (dancingModel.DnacingStyles != null && dancingModel.DnacingStyles.Any())
                {
                    dancingModel.DnacingStyles.AsParallel().ForAll(x =>
                    {
                        if (x.SelectedValue != 0)
                        {
                            danceStyleIds.Add(x.SelectedValue ?? 0);
                        }
                    });
                }

                return await _userDancingRepository.PerformSaveAndUpdateOperationAsync(userDancing, danceStyleIds);
            }

            return false;
        }
        #endregion

        #region /// User Acting
        public async Task<UserActingModel> GetUserActingDetailAsync(Guid userId)
        {
            var result = await _userActingRepository.GetUserActingDetailAsync(userId);
            if (result.IsNotNull())
            {
                return new UserActingModel
                {
                    Id = result.UserActing.Id,
                    UserId = UserContext.Current.UserId,
                    ActingExperianceCode = result.UserActing.ActingExperianceCode,
                    ActingExperiance = result.UserActing.ActingExperiance,
                    AgentNeedCode = result.UserActing.AgentNeedCode,
                    Experiance = result.UserActing.Experiance,
                    Accents = _mapper.Map<List<AccentsDto>>(result.Accents),
                    Languages = _mapper.Map<List<LanguageDto>>(result.Languages),
                    AuditionsAndJobsGroup = _mapper.Map<List<AuditionsAndJobsGroupDto>>(result.ActingRoles),
                };
            }

            return new UserActingModel
            {
                Accents = new List<Models.AccentsDto>(),
                Languages = new List<Models.LanguageDto>(),
                AuditionsAndJobsGroup = new List<Models.AuditionsAndJobsGroupDto>()
            };
        }

        public async Task<bool> SaveUserActingDetailsAsync(UserActingModel userActingModel)
        {
            if (userActingModel.IsNotNull())
            {
                var userActingDetail = new UserActingDetail
                {
                    UserActing = new UserActing
                    {
                        Id = userActingModel.Id,
                        UserId = userActingModel.UserId,
                        ActingExperianceCode = userActingModel.ActingExperianceCode,
                        ActingExperiance = userActingModel.ActingExperiance,
                        AgentNeedCode = userActingModel.AgentNeedCode,
                        AgentNeed = string.Empty,
                        Experiance = userActingModel.Experiance,
                        IsActive = true,
                        IsDeleted = false,
                        DttmModified = DateTime.UtcNow
                    },
                    Accents = _mapper.Map<List<Accents>>(userActingModel.Accents).Where(x => string.IsNullOrWhiteSpace(x.SelectedAccent)),
                    Languages = _mapper.Map<List<Language>>(userActingModel.Languages).Where(x => string.IsNullOrWhiteSpace(x.SelectedLanguageCode)),
                    ActingRoles = _mapper.Map<List<ActingRoles>>(userActingModel.AuditionsAndJobsGroup).Where(x => x.SelectedCode != 0)
                };

                return await _userActingRepository.PerformSaveAndUpdateOperationAsync(userActingDetail);
            }

            return false;
        }
        #endregion
    }
}


