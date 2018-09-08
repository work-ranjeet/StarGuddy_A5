import { Component } from "@angular/core";
import * as _ from "lodash";
import { ProfileEditService } from "../../profileEdit/profileEdit.Service";
import IProfileHeader = App.Client.PublicProfile.IProfileHeader;
import IJobGroupModel = App.Client.Profile.IJobGroupModel;

@Component({
    selector: "profile-edit-index",
    templateUrl: "././profileEditIndex.component.html",
    styleUrls: ['././profileEditIndex.component.css']
})


export class ProfileEditIndex {
    private jobGroupName: string = "";
    private aboutMe: string = "";
    private selectedMenuCode: number = 0;
    private selectedGroups: Array<IJobGroupModel> = [];
    private jobGroupNameArray: Array<string> = [];
    private profileHeader: IProfileHeader = {} as IProfileHeader;
    private readonly profileService: ProfileEditService;

    constructor(profileService: ProfileEditService) {    
        this.profileService = profileService;
    }

    ngOnInit() {
        this.loadHeaderData();
    }

    loadHeaderData() {
        this.profileService.GetUserProfileHeader().subscribe(response => {
            if (response != null) {
                this.profileHeader = _.cloneDeep(response);
                this.aboutMe = _.cloneDeep(response.about);
                this.selectedGroups = _.cloneDeep(response.jobGroups);
                this.filterData(response.jobGroups);                
            }
            else {
                console.info("Got empty result: ProfileEditIndex.loadHeaderData()");
            }
        });
    }

    filterData(jobGroups: Array<IJobGroupModel>) {
        if (this.profileHeader.displayName == "" || this.profileHeader.displayName == undefined) {
            this.profileHeader.displayName = this.profileHeader.firstName + " " + this.profileHeader.lastName;
        }

        if (this.aboutMe == undefined || this.aboutMe == "") {
            this.aboutMe = "A brief introduction of who you are.";
        }

        jobGroups.forEach(x => this.jobGroupNameArray.push(x.name));
        this.jobGroupName = this.jobGroupNameArray.join(", ");
    }

    changeMenuSelection(menuName: number) {
        this.selectedMenuCode = menuName;
    }

}
