import { Component } from "@angular/core";
import { Router, ActivatedRoute } from "@angular/router";
import { DataValidator } from "../../../../Helper/DataValidator";
import ILoginData = App.Client.Account.ILoginData;

@Component({
    selector: "profile-menu",
    templateUrl: "././menu.component.html",
    styleUrls: ['././menu.component.css']
})


export class ProfileMenu {
    loginData: ILoginData = {} as ILoginData;
    router: Router;
    authenticateRoute: ActivatedRoute;

    private readonly dataValidator: DataValidator

    constructor(router: Router, authRoute: ActivatedRoute, dataValidator: DataValidator) {
        this.router = router;
        this.authenticateRoute = authRoute;
        this.dataValidator = dataValidator;
    }

}
