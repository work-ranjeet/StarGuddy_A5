import * as _ from "lodash";
import { Component } from "@angular/core";
import { Router, ActivatedRoute } from "@angular/router";
import { UserProfileService } from "../../userProfile/UserProfile.Service";
import { DataValidator } from "../../../../Helper/DataValidator";

import IModelingDetailModel = App.Client.Profile.IUserModelingModel;
import IAuditionsAndJobsGroup = App.Client.Profile.IAuditionsAndJobsGroup;
import { ModelingExperiance, AgentNeed } from "../../../../Enums/enums";

@Component({
    selector: "user-profile-modeling",
    templateUrl: "././modeling.component.html",
    styleUrls: ['././modeling.component.css']
})


export class ModelingComponent {
    private readonly dataValidator: DataValidator;
    private userProfileService: UserProfileService;

    public showEditHtml: boolean = false;
    public modelingDetailModel: IModelingDetailModel;
    public modelingDetailReset: IModelingDetailModel;

    constructor(userProfileService: UserProfileService, dataValidator: DataValidator) {
        this.userProfileService = userProfileService;
        this.dataValidator = dataValidator;
        this.modelingDetailModel = _.cloneDeep({} as IModelingDetailModel);
        this.modelingDetailReset = _.cloneDeep({} as IModelingDetailModel);
    }

    ngOnInit() {
        this.loadModelingDetails();
    }

    edit() {
        this.showEditHtml = !this.showEditHtml;
    }

    loadModelingDetails() {
        this.userProfileService.GetUserModelingDetail().subscribe(response => {
            if (response != null) {
                this.modelingDetailModel = _.cloneDeep(response);
                this.modelingDetailReset = _.cloneDeep(response);
            }
            else {
                console.info("Got empty result GetUserActingDetail(): IActingDetailModel");
            }
        });
    }

    updateSelectedJobGroup(checkEvent: any) {
        var checkboxIndex = this.modelingDetailModel.modelingRoles.findIndex(x => x.code == checkEvent.target.value);

        if (checkboxIndex > -1) {
            this.modelingDetailModel.modelingRoles[checkboxIndex].selectedCode = checkEvent.target.checked ? parseInt(checkEvent.target.value) : 0;
        }
    }

    onModelingExpSelectionChange(checkEvent: any) {
        var expValue = parseInt(checkEvent.currentTarget.value);
        this.modelingDetailModel.expCode = expValue;
        this.modelingDetailModel.expText = ModelingExperiance[expValue];
    }

    onAgentGroupSelectionChange(checkEvent: any) {
        var agentValue = parseInt(checkEvent.currentTarget.value);
        this.modelingDetailModel.agentNeedCode = agentValue;
    }

    resetChanges() {
        if (!this.showEditHtml) {
            this.modelingDetailModel = _.cloneDeep({} as IModelingDetailModel);
            this.modelingDetailModel = _.cloneDeep(this.modelingDetailReset);
        }
    }

    saveChanges() {
        this.userProfileService.SaveUserModelingDetails(this.modelingDetailModel).subscribe(response => {
            if (response != null && response) {
                console.info("Updated");
                this.loadModelingDetails();
            }
            else {
                console.warn(response.statusText);
            }
        });
    }
}
