import { Component } from "@angular/core";
import * as _ from "lodash";
import { ProfileEditService } from "../../profileEdit/profileEdit.Service";
import IJobGroupModel = App.Client.Profile.IJobGroupModel;

@Component({
    selector: "job-group",
    templateUrl: "./jobGroup.component.html",
    styleUrls: ["./jobGroup.component.css"]
})
export class JobGroupComponent {
    private readonly userProfileService: ProfileEditService;
    public userInterestList: Array<IJobGroupModel> = [];

    constructor(userProfileService: ProfileEditService) {
        this.userProfileService = userProfileService;
    }

    ngOnInit() {
        this.loadUserInterests();
    }

    loadUserInterests() {
        this.userProfileService.GetUserInterestDetail().subscribe(response => {
            if (response != null) {
                this.userInterestList = _.cloneDeep(response);
            }
            else {
                console.info("Got empty result: JobGroupComponent.GetUserInterestDetail()");
            }
        });
    }
}
