import { Component } from "@angular/core";
import * as _ from "lodash";
import { ProfileService } from "../profile.Service";
import IModelingDetailModel = App.Client.Profile.IUserModelingModel;

@Component({
    selector: "profile-modeling",
    templateUrl: "././modeling.component.html"
})


export class ProfileModelingComponent {
    public modelingDetailModel: IModelingDetailModel = {} as IModelingDetailModel;

    constructor(private readonly profileService: ProfileService) {}

    ngOnInit() {
        this.loadModelingDetails(); 
    }


    loadModelingDetails() {
        this.profileService.GetUserModelingDetail().subscribe(response => {
            if (response != null) {
                this.modelingDetailModel = _.cloneDeep(response);
            }
            else {
                console.info("Got empty result GetUserActingDetail(): IActingDetailModel");
            }
        });
    }   
}
