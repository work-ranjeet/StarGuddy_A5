namespace App.Client.Account {

    export interface ILoginData {
        Email: string;
        Password: string;
        RememberMe: boolean;
    }

    export class IApplicationUser {
        Id: string;
        UserName: string;
        Email: string;
        FirstName: string;
        LastName: string;
        Password: string;
        CnfPassword:string;
        Dob: string;
        Gender: string;
        IsCastingProfessional: boolean;
        OrgName: string;
        OrgWebsite: string;
        Designation: string;
    }
}