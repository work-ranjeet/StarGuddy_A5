import { Component } from "@angular/core";
import { Subscription } from "rxjs/Subscription";
import { Router, ActivatedRoute } from "@angular/router";
import { AccountService } from "../../account/Account.Service";

@Component({
    selector: "log-in-out",
    templateUrl: "./logInOut.component.html",
    styleUrls: ["./logInOut.component.css"]
})

export class LogInOutComponent {
    private readonly router: Router;
    private readonly accountService: AccountService;
    private readonly authenticateRoute: ActivatedRoute;

    private isLoggedIn: boolean;
    private showUserSettingMenu: boolean;
    private subscription: Subscription;

    constructor(router: Router, authRoute: ActivatedRoute, accountService: AccountService) {
        this.router = router;
        this.authenticateRoute = authRoute;
        this.accountService = accountService;

        this.subscription = this.accountService.IsLoggedIn.subscribe(val => this.isLoggedIn = val);
        this.isLoggedIn = false;
        this.showUserSettingMenu = true;
    }

    get UserFirstName() { return this.accountService.getUserFirstName(); }


    toggleUserSettingMenu() {
        this.showUserSettingMenu = !this.showUserSettingMenu;
    }

    ngOnDestroy() {
        this.subscription.unsubscribe();
    }

    logOut() {
        this.accountService.logOut();
        this.router.navigate(["/"]);
    }
}
