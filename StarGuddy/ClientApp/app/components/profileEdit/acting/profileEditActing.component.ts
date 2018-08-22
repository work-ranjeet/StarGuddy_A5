import * as _ from "lodash";
import { Component } from "@angular/core";
import { Router, ActivatedRoute } from "@angular/router";
import { ProfileEditService } from "../../profileEdit/profileEdit.Service";
import { DataValidator } from "../../../../Helper/DataValidator";

import IActingDetailModel = App.Client.Profile.IUserActingModel;
import IAccents = App.Client.Profile.IAccents;
import ILanguage = App.Client.Profile.ILanguage;
import IAuditionsAndJobsGroup = App.Client.Profile.IAuditionsAndJobsGroup;
import { ActingExperiance, AgentNeed } from "../../../../Enums/enums";

@Component({
    selector: "profile-edit-acting",
    templateUrl: "././profileEditActing.component.html",
    styleUrls: ['././profileEditActing.component.css']
})


export class ProfileEditActingComponent {

    private readonly dataValidator: DataValidator;
    private userProfileService: ProfileEditService;

    public showEditHtml: boolean = false;
    public actingDetailModel: IActingDetailModel;
    public actingDetailReset: IActingDetailModel;

    constructor(userProfileService: ProfileEditService, dataValidator: DataValidator) {
        this.userProfileService = userProfileService;
        this.dataValidator = dataValidator;
        this.actingDetailModel = _.cloneDeep({} as IActingDetailModel);
        this.actingDetailReset = _.cloneDeep({} as IActingDetailModel);
    }

    ngOnInit() {
        this.loadActingDetails();
    }

    edit() {
        this.showEditHtml = !this.showEditHtml;
        this.resetChanges();
    }

    loadActingDetails() {
        this.userProfileService.GetUserActingDetail().subscribe(response => {
            if (response != null) {
                this.actingDetailModel = _.cloneDeep(response);
                this.actingDetailReset = _.cloneDeep(response);
            }
            else {
                console.info("Got empty result GetUserActingDetail(): IActingDetailModel");
            }
        });
    }

    updateSelectedJobGroup(checkEvent: any) {
        var checkboxIndex = this.actingDetailModel.auditionsAndJobsGroup.findIndex(x => x.code == checkEvent.target.value);

        if (checkboxIndex > -1) {
            this.actingDetailModel.auditionsAndJobsGroup[checkboxIndex].selectedCode = checkEvent.target.checked ? parseInt(checkEvent.target.value) : 0;
        }
    }

    updateSelectedLanguageChange(checkEvent: any) {
        var checkboxIndex = this.actingDetailModel.languages.findIndex(x => x.code == checkEvent.target.value);

        if (checkboxIndex > -1) {
            this.actingDetailModel.languages[checkboxIndex].selectedLanguageCode = checkEvent.target.checked ? checkEvent.target.value : String.Empty;
        }
    }

    updateSelectedAccentChange(checkEvent: any) {
        var checkboxIndex = this.actingDetailModel.accents.findIndex(x => x.code == checkEvent.target.value);

        if (checkboxIndex > -1) {
            this.actingDetailModel.accents[checkboxIndex].selectedAccent = checkEvent.target.checked ? checkEvent.target.value : String.Empty;
        }
    }

    onActingExpSelectionChange(checkEvent: any) {
        var actExpValue = parseInt(checkEvent.currentTarget.value);
        this.actingDetailModel.actingExperianceCode = actExpValue;
        this.actingDetailModel.actingExperiance = ActingExperiance[actExpValue];
    }

    onAgentGroupSelectionChange(checkEvent: any) {
        var agentValue = parseInt(checkEvent.currentTarget.value);
        this.actingDetailModel.agentNeedCode = agentValue;
    }

    resetChanges() {
        if (!this.showEditHtml) {
            this.actingDetailModel = _.cloneDeep({} as IActingDetailModel);
            this.actingDetailModel = _.cloneDeep(this.actingDetailReset);
        }
    }

    saveChanges() {
        this.userProfileService.SaveUserActingDetails(this.actingDetailModel).subscribe(response => {
            if (response != null && response) {
                console.info("Updated");
                this.loadActingDetails();
            }
            else {
                console.warn(response.statusText);
            }
        });
    }
}
