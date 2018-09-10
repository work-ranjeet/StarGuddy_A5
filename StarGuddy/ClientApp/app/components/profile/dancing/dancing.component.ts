import { Component } from "@angular/core";
import { ProfileService } from "../../profile/profile.Service";
import IDancingModel = App.Client.Profile.IDancingModel;

@Component({
    selector: "profile-dancing",
    templateUrl: "././dancing.component.html"
})


export class ProfileDancingComponent {
    private subscription: any;
    public showDancing: boolean = false;
    public dancingResult: IDancingModel = {} as IDancingModel;

    constructor(private readonly profileService: ProfileService) { }

    ngOnInit() {
        
    }

    ngOnDestroy() {
       
    }

    loadDancingDetails(model: IDancingModel) {
        try {
            if (model != undefined) {
                this.dancingResult = model;
            }
            else {
                console.info("Got empty result: ProfileDancingComponent.loadDancingDetails()");
            }
        }
        catch (ex) {
            console.error("Got error ProfileDancingComponent.loadDancingDetails() : " + ex);
        }
    }
}
