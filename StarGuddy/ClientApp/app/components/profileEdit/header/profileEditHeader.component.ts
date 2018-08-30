import { Component } from "@angular/core";

import * as _ from "lodash";
import IProfileHeader = App.Client.PublicProfile.IProfileHeader;
import IJobGroupModel = App.Client.Profile.IJobGroupModel;
import { ProfileEditService } from "../../profileEdit/profileEdit.Service";

@Component({
    selector: "profile-edit-header",
    templateUrl: "././profileEditHeader.component.html",
    styleUrls: ['././profileEditHeader.component.css']
})


export class ProfileEditHeader {
    private jobGroupName: string = "";
    private jobGroupNameArray: Array<string> = [];
    private profileHeader: IProfileHeader = {} as IProfileHeader;

    constructor(private readonly profileService: ProfileEditService) { }

    ngOnInit() {
        this.loadHeader();
    }

    loadHeader() {
        this.profileService.GetUserProfileHeader().subscribe(response => {
            if (response != null) {
                this.profileHeader = _.cloneDeep(response);
                this.filterJobGroupNames(this.profileHeader.jobGroups);
                if (this.profileHeader.displayName == "" || this.profileHeader.displayName == undefined) {
                    this.profileHeader.displayName = response.firstName + " " + response.lastName;
                }
            }
            else {
                console.info("Got empty result: ProfileHeader.loadHeader()");
            }
        });
    }

    filterJobGroupNames(jobGroups: Array<IJobGroupModel>) {
        jobGroups.forEach(x => this.jobGroupNameArray.push(x.name));
        this.jobGroupName = this.jobGroupNameArray.join(", ");
    }
}
