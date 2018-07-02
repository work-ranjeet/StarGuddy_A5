import { Component } from "@angular/core";
import { Router, ActivatedRoute } from "@angular/router";
import { AccountService } from "../Account.Service";
import { DataValidator } from "../../../../Helper/DataValidator";
import ILoginData = App.Client.Account.ILoginData;

@Component({
    selector: "account-send-code",
    templateUrl: "././sendCode.component.html"
})

export class AccountSendCodeComponent {
    accountService: AccountService;
    router: Router;
    authenticateRoute: ActivatedRoute;

    private readonly dataValidator: DataValidator

    constructor(router: Router, authRoute: ActivatedRoute, accountService: AccountService, dataValidator: DataValidator) {
        this.router = router;
        this.authenticateRoute = authRoute;
        this.accountService = accountService;
        this.dataValidator = dataValidator;
    }
}
