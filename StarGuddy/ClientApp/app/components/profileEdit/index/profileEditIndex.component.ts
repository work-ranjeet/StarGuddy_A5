import { Component } from "@angular/core";
import { Router, ActivatedRoute } from "@angular/router";
import { ProfileEditService } from "../../profileEdit/profileEdit.Service";
import { DataValidator } from "../../../../Helper/DataValidator";
import ILoginData = App.Client.Account.ILoginData;

@Component({
    selector: "profile-edit-index",
    templateUrl: "././profileEditIndex.component.html",
    styleUrls: ['././profileEditIndex.component.css']
})


export class ProfileEditIndex {
    loginData: ILoginData = {} as ILoginData;
    manageAccountService: ProfileEditService;
    router: Router;
    returnUrl: string;
    authenticateRoute: ActivatedRoute;

    private readonly dataValidator: DataValidator

    constructor(router: Router, authRoute: ActivatedRoute, manageAccountService: ProfileEditService, dataValidator: DataValidator) {
        this.router = router;
        this.authenticateRoute = authRoute;
        this.manageAccountService = manageAccountService;
        this.dataValidator = dataValidator;

        // get return url from route parameters or default to '/'
        this.returnUrl = this.authenticateRoute.snapshot.queryParams["returnUrl"] || "/";
    }


    //scrollTo(selector: string, parentSelector?: string, horizontal?: boolean) {
    //    scrollTo(
    //        selector,       // scroll to this
    //        parentSelector, // scroll within (null if window scrolling)
    //        horizontal,     // is it horizontal scrolling
    //        0               // distance from top or left
    //    );
    //}

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
