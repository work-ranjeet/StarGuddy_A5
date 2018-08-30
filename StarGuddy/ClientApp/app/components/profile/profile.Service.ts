import { HttpErrorResponse } from "@angular/common/http";
import { Inject, Injectable } from "@angular/core";
import { Observable } from "rxjs/Observable";
import "rxjs/add/operator/map";
import { DataConverter } from "../../../Helper/DataConverter";
import { BaseService } from "../../../Services/BaseService";
import { Subject } from "rxjs/Subject";
import { BehaviorSubject } from "rxjs/BehaviorSubject";
import IUserProfile = App.Client.PublicProfile.IUserProfile;
import IJobGroupModel = App.Client.Profile.IJobGroupModel;
import IProfileHeader = App.Client.PublicProfile.IProfileHeader;

@Injectable()
export class ProfileService {

    private profileDetailData = new BehaviorSubject<IUserProfile>({} as IUserProfile);
    public get PublicProfileData(): Observable<IUserProfile> { return this.profileDetailData.asObservable(); }
    public SetPublicProfileData(data: IUserProfile) { this.profileDetailData.next(data); }

    constructor(
        @Inject(BaseService) private readonly baseService: BaseService,
        private readonly dataConverter: DataConverter) { }

    //-------------Profile details-------------------------------//
    GetProfileDetails(profileUrl: string): Observable<IUserProfile> {
        return this.baseService.HttpService.getData<IUserProfile>("Profile/" + profileUrl)
            .map(
                (result: IUserProfile) => {
                    return result;
                },
                (err: HttpErrorResponse) => {
                    if (err.error instanceof Error) {
                        console.log("Client-side error occurred. Error:" + err.message);
                    } else {
                        console.log("Server-side error occurred. Error:" + err.message);
                    }
                });
    } 

    // Profile Header
    GetUserProfileHeader(): Observable<IProfileHeader> {
        return this.baseService.HttpService.getData<IProfileHeader>("Profile/header/ranjeetkumar1783")
            .map(
            (result: IProfileHeader) => {
                    return result;
                },
                (err: HttpErrorResponse) => {
                    if (err.error instanceof Error) {
                        console.log("Client-side error occurred. Error:" + err.message);
                    } else {
                        console.log("Server-side error occurred. Error:" + err.message);
                    }
                });
    }
}