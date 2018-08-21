//import { Observable } from "rxjs/Observable";
import "rxjs/add/operator/map";
import { BehaviorSubject } from "rxjs/BehaviorSubject";
import { Injectable, Inject } from "@angular/core";
import { Router } from "@angular/router";
import { BaseService } from "../../../Services/BaseService";
import { DataConverter } from "../../../Helper/DataConverter";
import { Observable } from "rxjs/Observable";
import { HttpErrorResponse, HttpParams } from "@angular/common/http";


import { Response } from "@angular/http";

@Injectable()
export class PublicProfileService {
    private isLoggedInSource = new BehaviorSubject<boolean>(false);

    constructor(
        @Inject(BaseService) private readonly baseService: BaseService,
        private readonly router: Router,
        private readonly dataConverter: DataConverter) { }

    //-------------Physical Appearance-------------------------------//
    //GetUserPhysicalAppreance(): Observable<IPhysicalAppearance> {
    //    return this.baseService.HttpService.getData<IPhysicalAppearance>("Profile/Operations/PhysicalApperance")
    //        .map(
    //            (result: IPhysicalAppearance) => {
    //                return result;
    //            },
    //            (err: HttpErrorResponse) => {
    //                if (err.error instanceof Error) {
    //                    console.log("Client-side error occurred. Error:" + err.message);
    //                } else {
    //                    console.log("Server-side error occurred. Error:" + err.message);
    //                }
    //            });
    //}

}