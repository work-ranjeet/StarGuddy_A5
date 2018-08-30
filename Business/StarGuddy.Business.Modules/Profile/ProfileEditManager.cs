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
    using StarGuddy.Api.Models.UserJobs;
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

    public class ProfileEditManager : IProfileEditManager
    {
        private readonly IUserRepository _userRepository;
        private readonly IUserCreditsRepository _userCreditsRepository;
        private readonly IPhysicalAppearanceRepository _physicalAppearanceRepository;
        private readonly IUserDancingRepository _userDancingRepository;
        private readonly IUserActingRepository _userActingRepository;
        private readonly IUserModelingRepository _userModelingRepository;
        private readonly IMapper _mapper;

        public ProfileEditManager(
            IUserRepository userRepository,
            IPhysicalAppearanceRepository physicalAppearanceRepository,
            IUserCreditsRepository userCreditsRepository,
            IUserDancingRepository userDancingRepository,
            IUserActingRepository userActingRepository,
            IUserModelingRepository userModelingRepository,
            IMapper mapper)
        {
            _userRepository = userRepository;
            _userDancingRepository = userDancingRepository;
            _userCreditsRepository = userCreditsRepository;
            _physicalAppearanceRepository = physicalAppearanceRepository;
            _userActingRepository = userActingRepository;
            _userModelingRepository = userModelingRepository;
            _mapper = mapper;
        }

        #region /// Physical Appearance
        public async Task<IPhysicalAppearanceModal> GetPhysicalAppreance()
        {
            var result = await _physicalAppearanceRepository.GetPhysicalAppreanceById(UserContext.Current.UserId);
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
        public async Task<IEnumerable<IUserCreditModel>> GetUserCredits()
        {
            var result = await this._userCreditsRepository.GetUserCreditsById(UserContext.Current.UserId);
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

        public async Task<bool> DeleteUserCredits(Guid Id) => await this._userCreditsRepository.PerformDeleteOperation(Id);
        #endregion

        #region /// User dancing
        public async Task<DancingModel> GetUserDancingAsync()
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

            var userDancing = await _userDancingRepository.GetUserDancingAsync(UserContext.Current.UserId);

            var dancingStyle = await _userDancingRepository.GetDancingStyleSelectedAsync(UserContext.Current.UserId);

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
        public async Task<UserActingModel> GetUserActingDetailAsync()
        {
            var result = await _userActingRepository.GetUserActingDetailAsync(UserContext.Current.UserId);
            if (result.IsNotNull())
            {
                return new UserActingModel
                {
                    Id = result.UserActing?.Id ?? Guid.Empty,
                    UserId = UserContext.Current.UserId,
                    ActingExperianceCode = result.UserActing?.ActingExperianceCode ?? 0,
                    ActingExperiance = result.UserActing?.ActingExperiance ?? string.Empty,
                    AgentNeedCode = result.UserActing?.AgentNeedCode ?? 0,
                    Experiance = result.UserActing?.Experiance ?? string.Empty,
                    Accents = _mapper.Map<List<AccentsDto>>(result.Accents),
                    Languages = _mapper.Map<List<LanguageDto>>(result.Languages),
                    AuditionsAndJobsGroup = _mapper.Map<List<AuditionsAndJobsGroupDto>>(result.ActingRoles)
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
                    ActingRoles = _mapper.Map<List<JobSubGroup>>(userActingModel.AuditionsAndJobsGroup).Where(x => x.SelectedCode != 0)
                };

                return await _userActingRepository.PerformSaveAndUpdateOperationAsync(userActingDetail);
            }

            return false;
        }

        #endregion

        #region /// User Modeling
        public async Task<UserModelingModel> GetUserModelingDetailAsync()
        {
            var result = await _userModelingRepository.GetUserModelingDetailAsync(UserContext.Current.UserId);
            if (result.IsNotNull())
            {
                var userModelingModel = _mapper.Map<UserModelingModel>(result.UserModeling);
                if (userModelingModel.IsNull())
                {
                    userModelingModel = new UserModelingModel { ModelingRoles = new List<AuditionsAndJobsGroupDto>() };
                }

                userModelingModel.ModelingRoles = _mapper.Map<List<AuditionsAndJobsGroupDto>>(result.ModelingRoles);

                return userModelingModel;
            }

            return new UserModelingModel { ModelingRoles = new List<AuditionsAndJobsGroupDto>() };
        }

        public async Task<bool> SaveUserModelingDetailsAsync(UserModelingModel userModelingModel)
        {
            if (userModelingModel.IsNotNull())
            {
                var userModelingDetails = new UserModelingDetails
                {
                    UserModeling = _mapper.Map<UserModeling>(userModelingModel),
                    ModelingRoles = _mapper.Map<List<JobSubGroup>>(userModelingModel.ModelingRoles).Where(x => x.SelectedCode != 0)
                };

                userModelingDetails.UserModeling.UserId = UserContext.Current.UserId;

                return await _userModelingRepository.PerformSaveAndUpdateOperationAsync(userModelingDetails);
            }

            return false;
        }
        #endregion


        public async Task<ProfileHeader> GetProfileHeaderByUserId(Guid userId)
        {
            var result = await _userRepository.GetUserProfileHeaderById(userId);

            if (result.IsNotNull())
            {
                var profileHeader = _mapper.Map<ProfileHeader>(result);
                profileHeader.JobGroups = _mapper.Map<List<JobGroupModel>>(result.JobGroups).Where(x => x.Code == x.SelectedCode);

                return profileHeader;
            }

            return null;
        }
    }
}


