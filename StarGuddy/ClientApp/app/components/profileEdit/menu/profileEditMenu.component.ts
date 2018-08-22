import { Component } from "@angular/core";
import { Router, ActivatedRoute } from "@angular/router";
import { ProfileEditService } from "../../profileEdit/profileEdit.Service";
import { DataValidator } from "../../../../Helper/DataValidator";
import ILoginData = App.Client.Account.ILoginData;

@Component({
    selector: "profile-edit-menu",
    templateUrl: "././profileEditMenu.component.html",
    styleUrls: ['././profileEditMenu.component.css']
})


export class ProfileEditMenu {
    profileEditService: ProfileEditService;
    router: Router;
    authenticateRoute: ActivatedRoute;

    private readonly dataValidator: DataValidator

    constructor(router: Router, authRoute: ActivatedRoute, profileEditService: ProfileEditService, dataValidator: DataValidator) {
        this.router = router;
        this.authenticateRoute = authRoute;
        this.profileEditService = profileEditService;
        this.dataValidator = dataValidator;
    }

}
