import { Component } from "@angular/core";
import * as _ from "lodash";
import { ProfileService } from "../profile.Service";
import IProfileHeader = App.Client.PublicProfile.IProfileHeader;
import IJobGroupModel = App.Client.Profile.IJobGroupModel;

@Component({
    selector: "profile-header",
    templateUrl: "././header.component.html",
    styleUrls: ['././header.component.css']
})


export class ProfileHeader {
    private jobGroupName: string = "";
    private jobGroupNameArray: Array<string> = [];
    private profileHeader: IProfileHeader = {} as IProfileHeader;

    constructor(private readonly profileService: ProfileService) { }

    ngOnInit() {
        this.loadHeader();
    }

    loadHeader() {
        this.profileService.GetUserProfileHeader().subscribe(response => {
            if (response != null) {
                this.profileHeader = _.cloneDeep(response);
                this.filterJobGroupNames(this.profileHeader.jobGroups);
                if (this.profileHeader.displayName == "") {
                    this.profileHeader.displayName = this.profileHeader.firstName + " " + this.profileHeader.lastName;
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
