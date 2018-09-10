import { Component } from "@angular/core";
import * as _ from "lodash";
import { ProfileService } from "../../profile/profile.Service";
import IActingDetailModel = App.Client.Profile.IUserActingModel;

@Component({
    selector: "profile-acting",
    templateUrl: "././acting.component.html",
    styleUrls: ['././acting.component.css']
})


export class ProfileActingComponent {
    private subscription: any;
    private showActing: boolean = false;
    public actingDetailModel: IActingDetailModel = {} as IActingDetailModel;

    constructor(private readonly profileService: ProfileService) {
        
    }

    ngOnInit() {
       
        
    }

    ngOnDestroy() {
     
    }

    loadActingDetails(actingDetails: IActingDetailModel) {
        try {           
            if (actingDetails != undefined && actingDetails != null) {
                this.actingDetailModel = actingDetails;
            }
            else {
                console.info("Got empty result: ProfileActingComponent.loadActingDetails()");
            }
        }
        catch (ex) {
            console.error("Got error ProfileActingComponent.loadActingDetails() : " + ex);
        }
    }
}
