import { Component } from "@angular/core";
import { Router, ActivatedRoute } from "@angular/router";

@Component({
    selector: "account-confirm-email-sent",
    template: `<div>
                    <p>
                        <a asp-controller="Account" asp-action="Login">Please check your email and confirm your email address.</a>.
                    </p>
               </div>`
})

export class AccountConfirmEmailSentComponent {
    router: Router;
    returnUrl: string;
    authenticateRoute: ActivatedRoute;

    constructor(router: Router, authRoute: ActivatedRoute) {
        this.router = router;
        this.authenticateRoute = authRoute;
    }

    ngOnInit() {
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
