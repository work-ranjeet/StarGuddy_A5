import { Component } from "@angular/core";
import { Router, ActivatedRoute } from "@angular/router";
import { UserProfileSettingsService } from "../../userProfileSettings/userProfileSettings.Service";
import { DataValidator } from "../../../../Helper/DataValidator";
import ILoginData = App.Client.Account.ILoginData;

@Component({
    selector: "account-management-change-address",
    templateUrl: "././changeAddress.component.html",
    styleUrls: ['././changeAddress.component.css']
})

export class ChangeAddressComponent {
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

        // get return url from route parameters or default to '/'
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
