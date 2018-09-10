import { Component, Input } from "@angular/core";
import IProfileHeader = App.Client.PublicProfile.IProfileHeader;
import IJobGroupModel = App.Client.Profile.IJobGroupModel;

@Component({
    selector: "profile-header",
    templateUrl: "././header.component.html",
    styleUrls: ['././header.component.css']
})


export class ProfileHeader {
    private _jobGroupName: string = "";
    private _profileHeader: IProfileHeader = {} as IProfileHeader

    @Input()
    set jobGroupNames(jobGroupNames: string) { this._jobGroupName = jobGroupNames; }
    get jobGroupNames(): string { return this._jobGroupName; }

    @Input()
    set profileHeader(profileHeader: IProfileHeader) { this._profileHeader = profileHeader; console.info(this._profileHeader.cityOrTown); }
    get profileHeader() { return this._profileHeader; }
}
