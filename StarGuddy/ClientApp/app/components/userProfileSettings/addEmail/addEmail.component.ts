import { Component } from "@angular/core";
import { Router, ActivatedRoute } from "@angular/router";
import { UserProfileSettingsService } from "../../userProfileSettings/userProfileSettings.Service";
import { DataValidator } from "../../../../Helper/DataValidator";
import ILoginData = App.Client.Account.ILoginData;

@Component({
    selector: "account-management-add-email",
    templateUrl: "././addEmail.component.html",
    styleUrls: ['././addEmail.component.css']
})

export class AddEmailComponent {
   
    router: Router;
    returnUrl: string;
    authenticateRoute: ActivatedRoute;
    loginData: ILoginData = {} as ILoginData;
    manageAccountService: UserProfileSettingsService;

    private readonly dataValidator: DataValidator

    constructor(router: Router, authRoute: ActivatedRoute, manageAccountService: UserProfileSettingsService, dataValidator: DataValidator) {
        this.router = router;
        this.authenticateRoute = authRoute;
        this.manageAccountService = manageAccountService;
        this.dataValidator = dataValidator;
        this.returnUrl = this.authenticateRoute.snapshot.queryParams["returnUrl"] || "/";
    }


    //login() {
    //    if (this.dataValidator.IsValidObject(this.loginData)) {
    //        this.accountService.login(this.loginData).subscribe(
    //            result => {
    //                this.router.navigate([this.returnUrl]);
    //            },
    //            error => {
    //                console.error(error);
    //            });
    //    }
    //}
}
