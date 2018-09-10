import { Component, Input, Output, EventEmitter } from "@angular/core";
import { ProfileEditService } from "../../profileEdit/profileEdit.Service";
import IJobGroupModel = App.Client.Profile.IJobGroupModel;

@Component({
    selector: "profile-edit-menu",
    templateUrl: "././profileEditMenu.component.html",
    styleUrls: ['././profileEditMenu.component.css']
})


export class ProfileEditMenu {
    profileEditService: ProfileEditService;

    @Input() selectedJobGroup: Array<IJobGroupModel> = [];
    @Input() about: string = "";

    @Output() menuSelectionChange = new EventEmitter();

    constructor(profileEditService: ProfileEditService) {
        this.profileEditService = profileEditService;
    }

    menuSelectionChanged(menuCode: string) {
        this.menuSelectionChange.emit(menuCode);
    }
}
