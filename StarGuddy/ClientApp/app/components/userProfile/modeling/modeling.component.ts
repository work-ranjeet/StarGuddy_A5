import { Component } from "@angular/core";
import { Router, ActivatedRoute } from "@angular/router";
import { UserProfileService } from "../../userProfile/UserProfile.Service";
import { DataValidator } from "../../../../Helper/DataValidator";
import ILoginData = App.Client.Account.ILoginData;

@Component({
    selector: "user-profile-modeling",
    templateUrl: "././modeling.component.html",
    styleUrls: ['././modeling.component.css']
})


export class ModelingComponent {
    private readonly dataValidator: DataValidator;
    private userProfileService: UserProfileService;

    public showEditHtml: boolean = false;

    constructor(userProfileService: UserProfileService, dataValidator: DataValidator) {
        this.userProfileService = userProfileService;
        this.dataValidator = dataValidator;
    }

    edit() {
        this.showEditHtml = !this.showEditHtml;
    }
}
