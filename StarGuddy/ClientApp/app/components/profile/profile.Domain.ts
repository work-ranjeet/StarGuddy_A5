namespace App.Client.PublicProfile {

    import Profile = App.Client.Profile;

    export interface IUserProfile {
        physicalAppearance: Profile.IPhysicalAppearanceModal;
        userCredits: Array<Profile.ICredits>;
        dancing: Profile.IDancingModel;
        acting: Profile.IUserActingModel;
        modeling: Profile.IUserModelingModel;
    }

    export interface IProfileHeader {
        id: string;
        firstName: string;
        lastName: string;
        displayName: string;
        about: string;
        cityOrTown: string;
        country: string;
        phoneNumber: string;
        email: string;
        jobGroups: Profile.IJobGroupModel[];
    }




    //export interface IAppUser {
    //    id: string;
    //    userName: string;
    //    firstName: string;
    //    gender: string;
    //    lastName: string;
    //    designation: string;
    //    orgName: string;
    //    orgWebsite: string;
    //    isCastingProfessional: boolean;
    //}

    //export interface IAddress {
    //    id: string;
    //    userId: string;
    //    isActive: boolean;
    //    isDeleted: boolean;
    //    accessFailedCount: number;
    //    appOrHouseName: string;
    //    cityOrTown: string;
    //    country: string;
    //    flat: string;
    //    landMark: string;
    //    lineOne: string;
    //    lineTwo: string;
    //    stateOrProvince: string;
    //    zipOrPostalCode: string;
    //}

    //export interface IUserDetail {
    //    id: string;
    //    userId: string;
    //    about: string;
    //    age: number;
    //    bloodGroup: number;
    //    dateOfBirth: Date;
    //    disability: string;
    //    healthInfo: string;
    //    maritalStatus: number;
    //    motherTongue: string;
    //    nickname: string;
    //    profileAddress: string;
    //    religion: string;
    //}

    //export interface IPhone {
    //    userId: string;
    //    phoneNumber: String;
    //    isActive: Boolean;
    //    isDeleted: Boolean;
    //}

    //export interface IEmail {
    //    userId: string;
    //    email: string;
    //    emailConfirmed: boolean;
    //    isActive: boolean;
    //    isDeleted: boolean;
    //}

    //export interface IAppUserDetail {
    //    applicationUser: IAppUser;
    //    currentAddress: IAddress;
    //    userDetails: IUserDetail;
    //    phone: IPhone;
    //    email: IEmail;
    //}
}