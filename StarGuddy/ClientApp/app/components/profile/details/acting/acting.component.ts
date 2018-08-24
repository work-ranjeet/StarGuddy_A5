import { Component } from "@angular/core";
import * as _ from "lodash";
import { ProfileService } from "../../../profile/profile.Service";
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
        this.actingDetailModel = {} as IActingDetailModel;
        this.subscription = this.profileService.PublicProfileData.subscribe(x => this.loadActingDetails(x.acting));
    }

    ngOnDestroy() {
        this.subscription.unsubscribe();
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
