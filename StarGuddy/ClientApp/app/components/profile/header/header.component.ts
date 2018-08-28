import { Component } from "@angular/core";
import * as _ from "lodash";
import { ProfileService } from "../profile.Service";
//import IAppUserDetail = App.Client.PublicProfile.IAppUserDetail;
import IAppUser = App.Client.PublicProfile.IAppUser;
import IAddress = App.Client.PublicProfile.IAddress;
import IUserDetail = App.Client.PublicProfile.IUserDetail;
import IPhone = App.Client.PublicProfile.IPhone;
import IEmail = App.Client.PublicProfile.IEmail;

@Component({
    selector: "profile-header",
    templateUrl: "././header.component.html",
    styleUrls: ['././header.component.css']
})


export class ProfileHeader {
    private appUser: IAppUser = {} as IAppUser;
    private address: IAddress = {} as IAddress;
    private userDetail: IUserDetail = {} as IUserDetail;
    private phone: IPhone = {} as IPhone;
    private email: IEmail = {} as IEmail;
    //private appUserDetail: IAppUserDetail = {} as IAppUserDetail;

    constructor(private readonly profileService: ProfileService) {

    }

    ngOnInit() {
        this.loadHeader();
    }

    loadHeader() {
        this.profileService.GetUserDetails().subscribe(response => {
            if (response != null) {
                //this.appUserDetail = _.cloneDeep(response);

                this.appUser = _.cloneDeep(response.applicationUser);
                this.address = _.cloneDeep(response.currentAddress);
                this.userDetail = _.cloneDeep(response.userDetails);
                this.phone = _.cloneDeep(response.phone);
                this.email = _.cloneDeep(response.email);

            }
            else {
                console.info("Got empty result: ProfileHeader.loadHeader()");
            }
        });
    }
}
