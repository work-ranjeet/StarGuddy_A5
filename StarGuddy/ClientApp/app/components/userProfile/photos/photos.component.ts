import { Component } from "@angular/core";
import { Router, ActivatedRoute } from "@angular/router";
import { UserProfileService } from "../../userProfile/UserProfile.Service";
import { DataValidator } from "../../../../Helper/DataValidator";
import ILoginData = App.Client.Account.ILoginData;

@Component({
    selector: "user-profile-photos",
    templateUrl: "././photos.component.html",
    styleUrls: ['././photos.component.css']
})


export class PhotosComponent {

    private readonly dataValidator: DataValidator;
    private userProfileService: UserProfileService;

    constructor(userProfileService: UserProfileService, dataValidator: DataValidator) {
        this.userProfileService = userProfileService;
        this.dataValidator = dataValidator;
    }

    ngOnInit() {
       
    }

    
}
