//import { Observable } from "rxjs/Observable";
import "rxjs/add/operator/map";
import { BehaviorSubject } from "rxjs/BehaviorSubject";
import { Injectable, Inject } from "@angular/core";
import { Router } from "@angular/router";
import { BaseService } from "../../../Services/BaseService";
import { DataConverter } from "../../../Helper/DataConverter";
import IUserEmail = App.Client.Profile.Setting.IUserEmail;
import IPhysicalAppearance = App.Client.Profile.IPhysicalAppearanceModal;
import { Http } from '@angular/http';


@Injectable()
export class UserProfileService {
    public UserId: string;
    private isLoggedInSource = new BehaviorSubject<boolean>(false);

    constructor(
        @Inject(BaseService) private readonly baseService: BaseService,
        private readonly router: Router,
        private readonly dataConverter: DataConverter,
        private http: Http) {
        this.UserId = baseService.UserId,
    }

    GetUserPhysicalAppreance() {
        return this.baseService.HttpService.get("Profile/Operations/PhysicalApperance");
    }

    SaveUserPhysicalAppreance(physicalAppearance: IPhysicalAppearance) {
        return this.baseService.HttpService.post("Profile/Operations/SavePhysicalApperance", physicalAppearance);
    }

    
}