import { Injectable, Inject, PLATFORM_ID } from "@angular/core";
import { isPlatformBrowser } from "@angular/common";

import { RequestOptions, Headers } from "@angular/http";
import { Router } from "@angular/router";
import { AppConstant } from "../Constants/AppConstant";
import { HttpService } from "../Services/HttpClient";
import { HttpHeaders } from '@angular/common/http';
import IJwtPacket = App.Client.Account.IJwtPacket;

@Injectable()

export class BaseService {
    private readonly httpService: HttpService;
    private readonly appConstant: AppConstant;
    private readonly router: Router;

    constructor(
        @Inject(HttpService) httpService: HttpService,
        @Inject(PLATFORM_ID) private platformId: Object,
        appConstant: AppConstant, router: Router) {
        this.httpService = httpService;
        this.appConstant = appConstant;
        this.router = router;
    }  

    get IsAuthenticated() {
        return isPlatformBrowser(this.platformId) && localStorage.length > 0? localStorage.getItem(this.appConstant.TOKEN_KEY) : String.Empty;
    }

    get UserName() {
        return isPlatformBrowser(this.platformId) && localStorage.length > 0 ? localStorage.getItem(this.appConstant.USER_NAME) : String.Empty;
    }

    //get UserId() {
    //    let userId = this.storage.getItem(this.appConstant.USER_ID);
    //    return userId != undefined && userId != null ? userId : String.Empty;
    //}

    get UserFirstName() {
        return isPlatformBrowser(this.platformId) && localStorage.length > 0? localStorage.getItem(this.appConstant.USER_FIRST_NAME) : String.Empty;
    }

    //get UserEmail() {
    //    return this.storage.getItem(this.appConstant.USER_EMAIL);
    //}

    get HttpService() {
        return this.httpService;
    }

    authenticate(result: any): void {
        const authResponse = result;
        if (isPlatformBrowser(this.platformId)) {
            localStorage.setItem(this.appConstant.USER_ID, authResponse.userId);
            localStorage.setItem(this.appConstant.TOKEN_KEY, authResponse.token);
            localStorage.setItem(this.appConstant.USER_FIRST_NAME, authResponse.firstName);
            localStorage.setItem(this.appConstant.USER_NAME, authResponse.userName);
            localStorage.setItem(this.appConstant.USER_EMAIL, authResponse.email);
        }
    }

    cancleAuthention() {
        if (isPlatformBrowser(this.platformId)) {
            localStorage.clear();
        }
        //this.storage.removeItem(this.appConstant.USER_ID);
        //this.storage.removeItem(this.appConstant.TOKEN_KEY);
        //this.storage.removeItem(this.appConstant.USER_FIRST_NAME);
        //this.storage.removeItem(this.appConstant.USER_NAME);
        //this.storage.removeItem(this.appConstant.USER_EMAIL);
    }

}