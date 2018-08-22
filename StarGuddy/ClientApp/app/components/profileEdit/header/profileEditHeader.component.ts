import { Component } from "@angular/core";
import { Router, ActivatedRoute } from "@angular/router";
import { DataValidator } from "../../../../Helper/DataValidator";

@Component({
    selector: "profile-edit-header",
    templateUrl: "././profileEditHeader.component.html",
    styleUrls: ['././profileEditHeader.component.css']
})


export class ProfileEditHeader {
    router: Router;
    authenticateRoute: ActivatedRoute;

    private readonly dataValidator: DataValidator

    constructor(router: Router, authRoute: ActivatedRoute, dataValidator: DataValidator) {
        this.router = router;
        this.authenticateRoute = authRoute;
        this.dataValidator = dataValidator;
    }

}
