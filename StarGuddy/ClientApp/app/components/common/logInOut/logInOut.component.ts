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

    public isLoggedIn: boolean = false;
    public showUserSettingMenu: boolean = true;
    public subscription: any;

    constructor(router: Router, authRoute: ActivatedRoute, accountService: AccountService) {
        this.router = router;
        this.authenticateRoute = authRoute;
        this.accountService = accountService;      
    }
    
    ngOnInit() {
        this.subscription = this.accountService.IsLoggedIn.subscribe(val => this.isLoggedIn = val);
    }

    ngOnDestroy() {
        this.subscription.unsubscribe();
    }

    get UserFirstName() { return this.accountService.getUserFirstName(); }


    toggleUserSettingMenu() {
        this.showUserSettingMenu = !this.showUserSettingMenu;
    }
    
    logOut() {
        this.accountService.logOut();
        this.router.navigate(["/"]);
    }
}
