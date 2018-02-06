import { Component } from "@angular/core";
import { Router, ActivatedRoute } from "@angular/router";
import { AccountService } from "../Account.Service";
import { DataValidator } from "../../../../Helper/DataValidator";
import ILoginData = App.Client.Account.ILoginData;

@Component({
    selector: "account-verify-code",
    templateUrl: "././verifyCode.component.html"
})

export class AccountVerifyCodeComponent {
    loginData: ILoginData;
    accountService: AccountService;
    router: Router;
    returnUrl: string;
    authenticateRoute: ActivatedRoute;

    private readonly dataValidator: DataValidator

    constructor(router: Router, authRoute: ActivatedRoute, accountService: AccountService, dataValidator: DataValidator) {
        this.router = router;
        this.authenticateRoute = authRoute;
        this.accountService = accountService;
        this.dataValidator = dataValidator;
    }

    ngOnInit() {
        this.loginData = {} as ILoginData;

        // get return url from route parameters or default to '/'
        this.returnUrl = this.authenticateRoute.snapshot.queryParams["returnUrl"] || "/";
    }
}