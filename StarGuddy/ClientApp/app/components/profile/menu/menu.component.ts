import { Component, Input, Output, EventEmitter } from "@angular/core";
import { ProfileService } from "../../profile/profile.Service";
import IJobGroupModel = App.Client.Profile.IJobGroupModel;

@Component({
    selector: "profile-menu",
    templateUrl: "././menu.component.html",
    styleUrls: ['././menu.component.css']
})


export class ProfileMenu {
    private readonly profileService: ProfileService;

    @Input() selectedJobGroup: Array<IJobGroupModel> = [];
    @Input() about: string = "";

    @Output() menuSelectionChange = new EventEmitter();

    constructor(profileEditService: ProfileService) {
        this.profileService = profileEditService;
    }

    menuSelectionChanged(menuCode: string) {
        this.menuSelectionChange.emit(menuCode);
    }
}
