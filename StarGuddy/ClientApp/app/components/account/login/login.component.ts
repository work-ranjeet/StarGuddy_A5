import { Component } from "@angular/core";
import { Router, ActivatedRoute } from "@angular/router";
import { AccountService } from "../Account.Service";
import ILoginData = App.Client.Account.ILoginData;

@Component({
    selector: "account-login",
    templateUrl: "././login.component.html"
})

export class AccountLoginComponent {
    loginData: ILoginData;
    accountService: AccountService;
    router: Router;
    returnUrl: string;
    authenticateRoute: ActivatedRoute;

    constructor(router: Router, authRoute: ActivatedRoute, accountService: AccountService) {
        this.router = router;
        this.authenticateRoute = authRoute;
        this.accountService = accountService;
    }

    ngOnInit() {
        this.loginData = {} as ILoginData;

        // get return url from route parameters or default to '/'
        this.returnUrl = this.authenticateRoute.snapshot.queryParams["returnUrl"] || "/";
    }

    login() {
        this.accountService.login(this.loginData).subscribe(
            result => {
                this.router.navigate([this.returnUrl]);
            },
            error => {
            });
    }
}
