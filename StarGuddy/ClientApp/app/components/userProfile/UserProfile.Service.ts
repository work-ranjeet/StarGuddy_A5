//import { Observable } from "rxjs/Observable";
import "rxjs/add/operator/map";
import { BehaviorSubject } from "rxjs/BehaviorSubject";
import { Injectable, Inject } from "@angular/core";
import { Router } from "@angular/router";
import { BaseService } from "../../../Services/BaseService";
import { DataConverter } from "../../../Helper/DataConverter";
import { Observable } from "rxjs/Observable";

import IPhysicalAppearance = App.Client.Profile.IPhysicalAppearanceModal;
import { HttpErrorResponse } from "@angular/common/http";

@Injectable()
export class UserProfileService {
    private isLoggedInSource = new BehaviorSubject<boolean>(false);

    constructor(
        @Inject(BaseService) private readonly baseService: BaseService,
        private readonly router: Router,
        private readonly dataConverter: DataConverter) { }

    GetUserPhysicalAppreance(): Observable<IPhysicalAppearance> {
        return this.baseService.HttpService.getData<IPhysicalAppearance>("Profile/Operations/PhysicalApperance")
            .map(
                (result: IPhysicalAppearance) => {
                    return result;
                },
                (err: HttpErrorResponse) => {
                    if (err.error instanceof Error) {
                        console.log("Client-side error occurred.");
                    } else {
                        console.log("Server-side error occurred.");
                    }
                });
    }

    SaveUserPhysicalAppreance(physicalAppearance: IPhysicalAppearance): Observable<boolean> {
        return this.baseService.HttpService.postData<IPhysicalAppearance>("Profile/Operations/SavePhysicalApperance", physicalAppearance)
            .map(
                (result: any) => {
                    return result;
                },
                (err: HttpErrorResponse) => {
                    if (err.error instanceof Error) {
                        console.log("Client-side error occurred.");
                    } else {
                        console.log("Server-side error occurred.");
                    }
                });
    }
}