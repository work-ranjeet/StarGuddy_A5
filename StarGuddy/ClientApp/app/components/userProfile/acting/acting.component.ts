import { Component } from "@angular/core";
import { Router, ActivatedRoute } from "@angular/router";
import { UserProfileService } from "../../userProfile/UserProfile.Service";
import { DataValidator } from "../../../../Helper/DataValidator";
import ILoginData = App.Client.Account.ILoginData;

@Component({
    selector: "user-profile-acting",
    templateUrl: "././acting.component.html",
    styleUrls: ['././acting.component.css']
})


export class ActingComponent {

    private readonly dataValidator: DataValidator;
    private userProfileService: UserProfileService;

    constructor(userProfileService: UserProfileService, dataValidator: DataValidator) {
        this.userProfileService = userProfileService;
        this.dataValidator = dataValidator;
    }

    ngOnInit() {
       
    }

    
}
