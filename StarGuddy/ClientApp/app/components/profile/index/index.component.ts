import { Component } from "@angular/core";
import * as _ from "lodash";
import { ProfileService } from "../../profile/profile.Service";
import IProfileHeader = App.Client.PublicProfile.IProfileHeader;
import IJobGroupModel = App.Client.Profile.IJobGroupModel;
import ISectionVesbility = App.Client.PublicProfile.ISectionVesbility;


import ILoginData = App.Client.Account.ILoginData;
import { ProfileEditIndex } from "../../profileEdit/index/profileEditIndex.component";

@Component({
    selector: "profile-index",
    templateUrl: "././index.component.html",
    styleUrls: ['././index.component.css']
})


export class ProfileIndex{
    public jobGroupName: string = "";
    public aboutMe: string = "";
    public selectedGroups: Array<IJobGroupModel> = [];
    public jobGroupNameArray: Array<string> = [];
    public profileHeader: IProfileHeader = {} as IProfileHeader;
    public setionVisbility: ISectionVesbility = {} as ISectionVesbility;

    constructor(private readonly  profileService: ProfileService) {}

    ngOnInit() {
       
    }

    loadHeaderData() {
        this.profileService.GetUserProfileHeader().subscribe(response => {
            if (response != null) {
                this.profileHeader = _.cloneDeep(response);
                this.aboutMe = _.cloneDeep(response.about);
                this.selectedGroups = _.cloneDeep(response.jobGroups);
                this.filterData(response.jobGroups);
                this.loadSection();
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

    changeMenuSelection(menuCode: string) {
        let el = document.getElementById(menuCode);
        if (el != null)
            el.scrollIntoView({ behavior: "smooth", block: "center", inline: "center" });
    }

    loadSection() {
        this.setionVisbility.showActing = _.findIndex(this.selectedGroups, function (o) { return o.code == 1001; }) > -1;
        this.setionVisbility.showModeling = _.findIndex(this.selectedGroups, function (o) { return o.code == 1002; }) > -1;
        this.setionVisbility.showExtras = _.findIndex(this.selectedGroups, function (o) { return o.code == 1003; }) > -1;
        this.setionVisbility.showPresenter = _.findIndex(this.selectedGroups, function (o) { return o.code == 1004; }) > -1;
        this.setionVisbility.showMusician = _.findIndex(this.selectedGroups, function (o) { return o.code == 1005; }) > -1;
        this.setionVisbility.showPhotography = _.findIndex(this.selectedGroups, function (o) { return o.code == 1006; }) > -1;
        this.setionVisbility.showTVReality = _.findIndex(this.selectedGroups, function (o) { return o.code == 1007; }) > -1;
        this.setionVisbility.showDancing = _.findIndex(this.selectedGroups, function (o) { return o.code == 1008; }) > -1;
        this.setionVisbility.showFilmStageCrew = _.findIndex(this.selectedGroups, function (o) { return o.code == 1009; }) > -1;
        this.setionVisbility.showHairMakeupStyling = _.findIndex(this.selectedGroups, function (o) { return o.code == 1010; }) > -1;
        this.setionVisbility.showSurvivalJobs = _.findIndex(this.selectedGroups, function (o) { return o.code == 1011; }) > -1;
    }
}

