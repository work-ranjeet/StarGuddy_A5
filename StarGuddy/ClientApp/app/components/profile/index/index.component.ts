import { Component } from "@angular/core";
import { ProfileService } from "../../profile/profile.Service";
import { ProfileIndexAbstract } from "../../../comBase/profileIndexAbstract";
import * as _ from "lodash";
@Component({
    selector: "profile-index",
    templateUrl: "././index.component.html",
    styleUrls: ['././index.component.css']
})


export class ProfileIndex extends ProfileIndexAbstract{

    constructor(private readonly profileService: ProfileService) { super();}

    ngOnInit() {
        this.loadHeaderData();
    }

    loadHeaderData() {
        this.profileService.GetUserProfileHeader().subscribe(response => {
            if (response != null) {
                this.ProfileHeader = _.cloneDeep(response);
                this.AboutMe = _.cloneDeep(response.about);
                this.SelectedGroups = _.cloneDeep(response.jobGroups);
                this.FilterData(response.jobGroups);
                this.LoadSection();
            }
            else {
                console.info("Got empty result: ProfileIndex.loadHeaderData()");
            }
        });
    }
}

