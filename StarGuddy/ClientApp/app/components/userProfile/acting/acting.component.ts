import * as _ from "lodash";
import { Component } from "@angular/core";
import { Router, ActivatedRoute } from "@angular/router";
import { UserProfileService } from "../../userProfile/UserProfile.Service";
import { DataValidator } from "../../../../Helper/DataValidator";

import IActingDetailModel = App.Client.Profile.IUserActingModel;
import IAccents = App.Client.Profile.IAccents;
import ILanguage = App.Client.Profile.ILanguage;
import IAuditionsAndJobsGroup = App.Client.Profile.IAuditionsAndJobsGroup;

@Component({
    selector: "user-profile-acting",
    templateUrl: "././acting.component.html",
    styleUrls: ['././acting.component.css']
})


export class ActingComponent {

    private readonly dataValidator: DataValidator;
    private userProfileService: UserProfileService;

    public showEditHtml: boolean = false;
    public actingDetailModel: IActingDetailModel;
    //public actingDetailResult: IActingDetailModel;
    public actingDetailReset: IActingDetailModel;

    constructor(userProfileService: UserProfileService, dataValidator: DataValidator) {
        this.userProfileService = userProfileService;
        this.dataValidator = dataValidator;
        this.actingDetailModel = _.cloneDeep({} as IActingDetailModel);
        //this.actingDetailResult = _.cloneDeep({} as IActingDetailModel);
        this.actingDetailReset = _.cloneDeep({} as IActingDetailModel);
    }

    ngOnInit() {
        this.loadActingDetails();
    }

    edit() {
        this.showEditHtml = !this.showEditHtml;
    }

    loadActingDetails() {
        this.userProfileService.GetUserActingDetail().subscribe(response => {
            if (response != null) {
                this.actingDetailModel = _.cloneDeep(response);
                //this.actingDetailResult = _.cloneDeep(response);
                this.actingDetailReset = _.cloneDeep(response);
            }
            else {
                console.info("Got empty result GetUserActingDetail(): IActingDetailModel");
            }
        });
    }

    updateSelectedJobGroup(event: any) { }

    onAgentGroupSelectionChange($event: any) { }

}
