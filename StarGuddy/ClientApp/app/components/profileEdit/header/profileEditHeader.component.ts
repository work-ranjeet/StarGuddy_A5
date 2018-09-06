import { Component, Input } from "@angular/core";

import * as _ from "lodash";
import IProfileHeader = App.Client.PublicProfile.IProfileHeader;
import IJobGroupModel = App.Client.Profile.IJobGroupModel;
import { ProfileEditService } from "../../profileEdit/profileEdit.Service";

@Component({
    selector: "profile-edit-header",
    templateUrl: "././profileEditHeader.component.html",
    styleUrls: ['././profileEditHeader.component.css']
})


export class ProfileEditHeader {
    private _jobGroupName: string = "";
    private _profileHeader: IProfileHeader = {} as IProfileHeader
   
    constructor(private readonly profileService: ProfileEditService) { }
    
    @Input()
    set jobGroupNames(jobGroupNames: string) { this._jobGroupName = jobGroupNames; }
    get jobGroupNames(): string { return this._jobGroupName; }

    @Input()
    set profileHeader(profileHeader: IProfileHeader) { this._profileHeader = profileHeader; console.info(this._profileHeader.cityOrTown); }
    get profileHeader() { return this._profileHeader; }

}
