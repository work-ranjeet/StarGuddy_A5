namespace App.Client.Account {
    export interface IJwtPacket {
        UserId: string;
        Token: string;
        FirstName: string;
        UserName: string;
        Email: string;
    }

    export interface ILoginData {
        UserName: string;
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
        Gender: string;
        IsCastingProfessional: boolean;
        OrgName: string;
        OrgWebsite: string;
        Designation: string;
    }
}