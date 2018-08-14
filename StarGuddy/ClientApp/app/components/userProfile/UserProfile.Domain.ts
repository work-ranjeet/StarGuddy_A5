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

    export interface IDancingStyleModel {
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
        dnacingStyles: IDancingStyleModel[];
    }

    export interface IAccents {
        id: number;
        name: string;
        code: string;
        languageCode: string;
        selectedAccent: string;
        isActive: boolean;
        isDeleted: boolean;
    }

    export interface ILanguage {
        id: number;
        name: string;
        code: string;
        selectedLanguageCode: string;
        countryCode: string;
        isActive: boolean;
        isDeleted: boolean;
    }

    export interface IAuditionsAndJobsGroup {
        id: number;
        name: string;
        code: number;
        selectedCode: number;
        detail: string;
        displayOrder: number;
        isActive: boolean;
        isDeleted: boolean;
    }

    export interface IUserActingModel {
        id: string;
        userId: string;
        actingExperianceCode: number;
        actingExperiance: string;
        agentNeedCode: number;
        experiance: string;
        languages: ILanguage[];
        accents: IAccents[];
        auditionsAndJobsGroup: IAuditionsAndJobsGroup[];
    }
}