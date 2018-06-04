namespace App.Client.Profile {

    export interface IPhysicalAppearance {
        UserId: string;
        BodyType: string;
        Chest: string;
        EyeColor: string;
        HairColor: string;
        HairLength: string;
        HairType: string;
        SkinColor: string;
        Height: string;
        Weight: string;
        West: string;
        Ethnicity: string;
        IsActive: Boolean;
        IsDeleted: Boolean;
    }

    export interface ICredits {
        Id: string;
        Action: string;
        WorkYear: string;
        WorkPlace: string;
        WorkDetail: string;
    }
}