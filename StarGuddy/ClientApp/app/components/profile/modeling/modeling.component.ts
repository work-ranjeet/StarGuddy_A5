import { Component } from "@angular/core";
import { ProfileService } from "../profile.Service";

import IModelingDetailModel = App.Client.Profile.IUserModelingModel;
import IAuditionsAndJobsGroup = App.Client.Profile.IAuditionsAndJobsGroup;

@Component({
    selector: "profile-modeling",
    templateUrl: "././modeling.component.html"
})


export class ProfileModelingComponent {
    private subscription: any;
    public showModeling: boolean = false;
    public modelingDetailModel: IModelingDetailModel = {} as IModelingDetailModel;

    constructor(private readonly profileService: ProfileService) {}

    ngOnInit() {
        this.subscription = this.profileService.PublicProfileData.subscribe(x => this.loadModelingDetails(x.modeling));
    }


    loadModelingDetails(model: IModelingDetailModel) {
        try {
            if (model != undefined) {
                this.modelingDetailModel = model;
            }
            else {
                console.info("Got empty result: ProfileModelingComponent.loadModelingDetails()");
            }
        }
        catch (ex) {
            console.error("Got error ProfileModelingComponent.loadModelingDetails() : " + ex);
        }
    }   
}
