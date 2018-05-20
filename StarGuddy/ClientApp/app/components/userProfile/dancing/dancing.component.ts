import { Component } from "@angular/core";
import { Router, ActivatedRoute } from "@angular/router";
import { UserProfileService } from "../../userProfile/UserProfile.Service";
import { DataValidator } from "../../../../Helper/DataValidator";
import ILoginData = App.Client.Account.ILoginData;

@Component({
    selector: "user-profile-dancing",
    templateUrl: "././dancing.component.html",
    styleUrls: ['././dancing.component.css']
})


export class DancingComponent {

    private readonly dataValidator: DataValidator;
    private userProfileService: UserProfileService;

    public showEditHtml: boolean;

    constructor(userProfileService: UserProfileService, dataValidator: DataValidator) {
        this.userProfileService = userProfileService;
        this.dataValidator = dataValidator;
    }

    ngOnInit() {
        this.showEditHtml = false;
    }

    edit() {
        this.showEditHtml = !this.showEditHtml;
    }
}
