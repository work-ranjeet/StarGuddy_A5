namespace App.Client.Profile {


    export interface IPhysicalAppearanceModal {
        bodyType: string;
        chest: string;
        eyeColor: string;
        hairColor: string;
        hairLength: string;
        hairType: string;
        skinColor: string;
        height: string;
        weight: string;
        west: string;
        ethnicity: string;
    }

    export interface ICredits {
        id: string;
        action: string;
        workYear: string;
        workPlace: string;
        workDetail: string;
    }
}