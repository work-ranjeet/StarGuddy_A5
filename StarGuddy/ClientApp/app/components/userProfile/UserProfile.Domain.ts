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

    export class PhysicalAppearanceModal implements IPhysicalAppearanceModal {
        public BodyType: string;
        public Chest: string;
        public EyeColor: string;
        public HairColor: string;
        public HairLength: string;
        public HairType: string;
        public SkinColor: string;
        public Height: string;
        public Weight: string;
        public West: string;
        public Ethnicity: string;
    }

    export interface ICredits {
        Id: string;
        Action: string;
        WorkYear: string;
        WorkPlace: string;
        WorkDetail: string;
    }
}