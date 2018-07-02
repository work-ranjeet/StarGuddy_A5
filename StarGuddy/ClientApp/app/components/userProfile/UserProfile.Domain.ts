namespace App.Client.Profile {


    export interface IPhysicalAppearanceModal {
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
    }

    export interface ICredits {
        Id: string;
        Action: string;
        WorkYear: string;
        WorkPlace: string;
        WorkDetail: string;
    }
}