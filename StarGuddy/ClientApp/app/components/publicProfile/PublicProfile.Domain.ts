namespace App.Client.PublicProfile {

    import Profile = App.Client.Profile;

    export interface IUserProfile {
        physicalAppearance: Profile.IPhysicalAppearanceModal;
        userCredits: Array<Profile.ICredits>;
        dancing: Profile.IDancingModel;
        acting: Profile.IUserActingModel;
        modeling: Profile.IUserModelingModel;
    }
}