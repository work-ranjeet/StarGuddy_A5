import { Component } from "@angular/core";
import { Router, ActivatedRoute } from "@angular/router";
import { UserProfileService } from "../../userProfile/UserProfile.Service";
import { DataValidator } from "../../../../Helper/DataValidator";
import IDancingStyle = App.Client.Profile.IDancingStyle;
import IDancingModel = App.Client.Profile.IDancingModel;

@Component({
    selector: "user-profile-dancing",
    templateUrl: "././dancing.component.html",
    styleUrls: ['././dancing.component.css']
})


export class DancingComponent {

    private readonly dataValidator: DataValidator;
    private readonly userProfileService: UserProfileService;
    private readonly initDancingStyle = { id: String.Empty, name: String.Empty, selectedValue: 0, value: 0 } as IDancingStyle;
    private readonly initCreditsClass = { id: String.Empty, agentNeed: 0, choreographyAbilities: 0, danceAbilities: 0, dnacingStyles: Array<IDancingStyle>(), experience: String.Empty, isAgent: false, isAttendedSchool: false, userId: String.Empty } as IDancingModel;

    public showEditHtml: boolean = false;
    public dancingModel: IDancingModel;
    public dancingResult: IDancingModel;
    public dancingStyleList: Array<IDancingStyle> = [];

    constructor(userProfileService: UserProfileService, dataValidator: DataValidator) {
        this.userProfileService = userProfileService;
        this.dataValidator = dataValidator;
        this.dancingModel = Object.assign({}, this.initCreditsClass);
        this.dancingResult = Object.assign({}, this.initCreditsClass);
    }

    ngOnInit() {
        this.loadDancingDetails();
    }

    edit() {
        this.showEditHtml = !this.showEditHtml;
    }

    loadDancingDetails() {
        this.userProfileService.GetUserDanceDetail().subscribe(response => {
            if (response != null) {
                this.dancingModel = Object.assign({}, response);
                this.dancingResult = Object.assign({}, response);
            }
            else {
                console.info("Got empty result: IDancingModel");
            }
        });
    }

    updateSelectedDanceStyle(checkEvent: any) {
        if (checkEvent.target.checked) { }
    }

    onDanceExpertLavelGroupSelectionChange(entry: any) {
        var v = entry;
    }

    onAgentGroupSelectionChange(entry: any) {
        var v = entry;
    }

    saveChanges() {
        var v = this.dancingModel;
    }
}
