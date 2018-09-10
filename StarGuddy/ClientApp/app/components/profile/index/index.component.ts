import { Component } from "@angular/core";
import { ProfileService } from "../../profile/profile.Service";
@Component({
    selector: "profile-index",
    templateUrl: "././index.component.html",
    styleUrls: ['././index.component.css']
})


export class ProfileIndex{

    constructor(private readonly  profileService: ProfileService) {}

    ngOnInit() {
       
    }

    loadHeaderData() {
        this.profileService.GetUserProfileHeader().subscribe(response => {
            if (response != null) {
                //this.profileHeader = _.cloneDeep(response);
                //this.aboutMe = _.cloneDeep(response.about);
                //this.selectedGroups = _.cloneDeep(response.jobGroups);
                //this.filterData(response.jobGroups);
                //this.loadSection();
            }
            else {
                console.info("Got empty result: ProfileEditIndex.loadHeaderData()");
            }
        });
    }
}

