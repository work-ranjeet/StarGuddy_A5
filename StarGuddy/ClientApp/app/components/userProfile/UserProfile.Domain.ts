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

    export interface IDancingStyle {
        id: string;
        selectedValue: number;
        value: number;
        name: string;
    }

    export interface IDancingModel {
        id: string;
        userId: string;
        danceAbilities: number;
        danceAbilitiesText: string;
        choreographyAbilities: number;
        choreographyAbilitiesText: string;
        agentNeed: number;
        experience: string;
        isAttendedSchool: boolean;
        isAgent: boolean;
        hasDanceStyle: boolean;
        dnacingStyles: IDancingStyle[];
    }

    
}