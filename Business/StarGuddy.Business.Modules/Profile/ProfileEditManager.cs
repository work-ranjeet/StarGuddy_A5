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
        private readonly IProfileFacade _profileFacade;
        private readonly IUserRepository _userRepository;
        private readonly IUserDetailRepository _userDetailRepository;
        private readonly IUserSettingsRepository _userSettingsRepository;
        private readonly IUserCreditsRepository _userCreditsRepository;
        private readonly IPhysicalAppearanceRepository _physicalAppearanceRepository;
        private readonly IUserDancingRepository _userDancingRepository;
        private readonly IUserActingRepository _userActingRepository;
        private readonly IUserModelingRepository _userModelingRepository;
        private readonly IMapper _mapper;

        public ProfileEditManager(
            IProfileFacade profileFacade,
            IUserRepository userRepository,
            IUserDetailRepository userDetailRepository,
            IUserSettingsRepository userSettingsRepository,
            IPhysicalAppearanceRepository physicalAppearanceRepository,
            IUserCreditsRepository userCreditsRepository,
            IUserDancingRepository userDancingRepository,
            IUserActingRepository userActingRepository,
            IUserModelingRepository userModelingRepository,
            IMapper mapper)
        {
            _profileFacade = profileFacade;
            _userRepository = userRepository;
            _userDetailRepository = userDetailRepository;
            _userSettingsRepository = userSettingsRepository;
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
            return await _profileFacade.FetchPhysicalAppreance(UserContext.Current.UserId);
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
            return await _profileFacade.FetchUserCredits(UserContext.Current.UserId);
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
            return await _profileFacade.FetchUserDancingAsync(UserContext.Current.UserId);
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
           return await _profileFacade.FetchUserActingDetailAsync(UserContext.Current.UserId);
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
                    Accents = _mapper.Map<List<Accents>>(userActingModel.Accents).Where(x => !string.IsNullOrWhiteSpace(x.SelectedAccent)),
                    Languages = _mapper.Map<List<Language>>(userActingModel.Languages).Where(x => !string.IsNullOrWhiteSpace(x.SelectedLanguageCode)),
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
            return await _profileFacade.FetchUserModelingDetailAsync(UserContext.Current.UserId);
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

        #region /// Name
        public async Task<UserNameModel> GetNameDetailsByUserId(Guid userId)
        {
            return await _profileFacade.FetchNameDetailsByUserId(UserContext.Current.UserId);
        }

        public async Task<bool> SaveNameDetails(UserNameModel nameModel)
        {

            var result = await _userRepository.UpdateNameDetails(
                new User
                {
                    Id = UserContext.Current.UserId,
                    FirstName = nameModel.FirstName,
                    LastName = nameModel.LastName,
                    OrgName = nameModel.OrgName,
                    DisplayName = nameModel.DisplayName
                });

            return result;
        }
        #endregion

        #region /// profile header
        public async Task<ProfileHeader> GetProfileHeaderByUserId(Guid userId)
        {
            return await _profileFacade.FetchProfileHeaderByUserId(UserContext.Current.UserId);
        }
        #endregion

        #region /// Profile Intro
        public async Task<UserDetailModel> GetProfileDetail()
        {
            return await _profileFacade.FetchProfileDetail(UserContext.Current.UserId);
        }

        public async Task<bool> SaveUserIntro(UserDetailModel detailModel)
        {
            var result = await _userDetailRepository.UpdateAboutIntro(detailModel.ProfileAddress, 
                new UserDetail
                {
                    UserId = UserContext.Current.UserId,
                    About = detailModel.About
                });

            return result;
        }
        #endregion
    }
}


