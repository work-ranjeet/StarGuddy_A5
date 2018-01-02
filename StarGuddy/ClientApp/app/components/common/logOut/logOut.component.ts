import { Component } from "@angular/core";
import { Subscription } from "rxjs/Subscription";
import { Router, ActivatedRoute } from "@angular/router";
import { AccountService } from "../../account/Account.Service";

@Component({
    selector: "log-out",
    templateUrl: "./logOut.component.html"
})

export class LogOutComponent {
    private readonly router: Router;
    private readonly accountService: AccountService;
    private readonly authenticateRoute: ActivatedRoute;

    private isLoggedIn: boolean;
    private subscription: Subscription;

    constructor(router: Router, authRoute: ActivatedRoute, accountService: AccountService) {
        this.router = router;
        this.authenticateRoute = authRoute;
        this.accountService = accountService;
    }

    get UserFirstName() { return this.accountService.getUserFirstName(); }

    ngOnInit() {
        this.subscription = this.accountService.IsLoggedIn.subscribe(val => this.isLoggedIn = val);
    }

    ngOnDestroy() {
        this.subscription.unsubscribe();
    }

    logOut() {
        this.accountService.logOut();
        this.router.navigate(["/"]);
    }
}
