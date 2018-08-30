import { Component } from "@angular/core";
import * as _ from "lodash";
import { DataValidator } from "../../../../Helper/DataValidator";
import { ProfileService } from "../profile.Service";
import IUserProfile = App.Client.PublicProfile.IUserProfile;
import { ActivatedRoute } from "@angular/router";

@Component({
    selector: "profile-details",
    templateUrl: "././details.component.html",
    styleUrls: ['././details.component.css']
})


export class ProfileDetails {

    public ProfileDetail: IUserProfile = {} as IUserProfile;


    constructor(
        private readonly activatedRoute: ActivatedRoute,
        private readonly profileService: ProfileService,
        private readonly dataValidator: DataValidator) {
    }

    ngOnInit() {
        this.loadProfileDetils();
    }

    loadProfileDetils() {
        var profileUrl = "";
        this.activatedRoute.params.subscribe(param => profileUrl = param['profileUrl']);

        console.info("User ProfileUrl: " + profileUrl == undefined ? "" : profileUrl);
        if (profileUrl == undefined || profileUrl == null) {
            return false;
        }

        if (JSON.stringify(this.ProfileDetail) == "{}" || this.ProfileDetail == undefined) {
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

}
