using AutoMapper;
using StarGuddy.Api.Models.Dto;
using StarGuddy.Api.Models.Interface.Profile;
using StarGuddy.Api.Models.Profile;
using StarGuddy.Api.Models.UserJobs;
using StarGuddy.Business.Interface.Profile;
using StarGuddy.Core.Constants;
using StarGuddy.Core.Context;
using StarGuddy.Core.Enums;
using StarGuddy.Repository.Interface;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarGuddy.Business.Modules.Profile
{
    public class ProfileManager : IProfileManager
    {
        private readonly IProfileFacade _profileFacade;
        private readonly IUserRepository _userRepository;
        private readonly IUserSettingsRepository _userSettingsRepository;
        private readonly IUserCreditsRepository _userCreditsRepository;
        private readonly IPhysicalAppearanceRepository _physicalAppearanceRepository;
        private readonly IUserDancingRepository _userDancingRepository;
        private readonly IUserActingRepository _userActingRepository;
        private readonly IUserModelingRepository _userModelingRepository;
        private readonly IMapper _mapper;

        public ProfileManager(
            IProfileFacade profileFacade,
            IUserRepository userRepository,
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
            _userSettingsRepository = userSettingsRepository;
            _userDancingRepository = userDancingRepository;
            _userCreditsRepository = userCreditsRepository;
            _physicalAppearanceRepository = physicalAppearanceRepository;
            _userActingRepository = userActingRepository;
            _userModelingRepository = userModelingRepository;
            _mapper = mapper;
        }

        #region /// Profile
        public async Task<ProfileHeader> GetProfileHeaderByProfileUrl(string profileUrl)
        {
            var result = await _userRepository.GetUserProfileHeaderByProfilUrl(profileUrl);

            if (result.IsNotNull())
            {
                var profileHeader = _mapper.Map<ProfileHeader>(result);
                profileHeader.JobGroups = _mapper.Map<List<JobGroupModel>>(result.JobGroups).Where(x => x.Code == x.SelectedCode);

                return profileHeader;
            }

            return null;
        }

        public async Task<UserProfile> GetUserProfile(string profileUrl)
        {
            var userId = await _userSettingsRepository.GetUserIdByProfilUrl(profileUrl);
            if (userId != Guid.Empty)
            {
                var physic = _profileFacade.FetchPhysicalAppreance(userId);
                var credits = _profileFacade.FetchUserCredits(userId);
                var dancing = _profileFacade.FetchUserDancingAsync(userId);
                var acting = _profileFacade.FetchUserActingDetailAsync(userId);
                var modeling = _profileFacade.FetchUserModelingDetailAsync(userId);
                var taskResult = Task.WhenAll(physic, credits, dancing, acting, modeling);

                try
                {
                    await taskResult.ConfigureAwait(false);
                    if (taskResult.IsCompletedSuccessfully)
                    {
                        return new UserProfile
                        {
                            Acting = await acting,
                            Dancing = await dancing,
                            Modeling = await modeling,
                            UserCredits = await credits,
                            PhysicalAppearance = await physic
                        };
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }

            return null;
        }
        #endregion

        #region /// details
        public async Task<IPhysicalAppearanceModal> GetPhysicalAppreance(string profileUrl)
        {
            var userId = await _userSettingsRepository.GetUserIdByProfilUrl(profileUrl);
            if (userId != Guid.Empty)
            {
                return await _profileFacade.FetchPhysicalAppreance(userId);
            }

            return null;
        }

        public async Task<IEnumerable<IUserCreditModel>> GetUserCredits(string profileUrl)
        {
            var userId = await _userSettingsRepository.GetUserIdByProfilUrl(profileUrl);
            if (userId != Guid.Empty)
            {
                return await _profileFacade.FetchUserCredits(userId);
            }

            return null;
        }
        public async Task<DancingModel> GetUserDancingAsync(string profileUrl)
        {
            var userId = await _userSettingsRepository.GetUserIdByProfilUrl(profileUrl);
            if (userId != Guid.Empty)
            {
                return await _profileFacade.FetchUserDancingAsync(userId);
            }

            return null;
        }

        public async Task<UserActingModel> GetUserActingDetailAsync(string profileUrl)
        {
            var userId = await _userSettingsRepository.GetUserIdByProfilUrl(profileUrl);
            if (userId != Guid.Empty)
            {
                return await _profileFacade.FetchUserActingDetailAsync(userId);
            }

            return null;
        }

        public async Task<UserModelingModel> GetUserModelingDetailAsync(string profileUrl)
        {
            var userId = await _userSettingsRepository.GetUserIdByProfilUrl(profileUrl);
            if (userId != Guid.Empty)
            {
                return await _profileFacade.FetchUserModelingDetailAsync(userId);
            }

            return null;
        }

        
        #endregion       
    }
}
