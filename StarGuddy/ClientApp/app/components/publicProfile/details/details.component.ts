import { Component } from "@angular/core";
import * as _ from "lodash";
import { DataValidator } from "../../../../Helper/DataValidator";
import { PublicProfileService } from "../PublicProfile.Service";
import IUserProfile = App.Client.PublicProfile.IUserProfile;
import { ActivatedRoute } from "@angular/router";

@Component({
    selector: "public-profile-details",
    templateUrl: "././details.component.html",
    styleUrls: ['././details.component.css']
})


export class PublicProfileDetails {

    public ProfileDetail: IUserProfile = {} as IUserProfile;


    constructor(
        private readonly activatedRoute: ActivatedRoute,
        private readonly profileService: PublicProfileService,
        private readonly dataValidator: DataValidator) {
    }

    ngOnInit() {
        this.loadProfileDetils();
    }

    loadProfileDetils() {
        var profileUrl = String.Empty;
        this.activatedRoute.params.subscribe(param => profileUrl = param['profileUrl']);

        console.info("User ProfileUrl: " + profileUrl == undefined ? "" : profileUrl);
        if (profileUrl == undefined || profileUrl == null) {
            return false;
        }
        this.profileService.GetProfileDetails(profileUrl).subscribe(response => {
            if (response != null) {
                this.ProfileDetail = _.cloneDeep(response);
                this.profileService.SetPublicProfileData(response);
            }
            else {
                console.info("Got empty result: PublicProfileService.GetProfileDetails()");
            }
        });
    }

}
