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

    constructor(private readonly profileService: ProfileService) {}

    ngOnInit() {       
        this.loadActingDetails();
    }

    loadActingDetails() {
        this.profileService.GetUserActingDetail().subscribe(response => {
            if (response != null) {
                this.actingDetailModel = _.cloneDeep(response);
            }
            else {
                console.info("Got empty result GetUserActingDetail(): IActingDetailModel");
            }
        });
    }
}
