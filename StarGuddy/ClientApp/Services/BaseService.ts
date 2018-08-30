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
        var token = isPlatformBrowser(this.platformId) && sessionStorage.length > 0 ? sessionStorage.getItem(this.appConstant.TOKEN_KEY) : "";

        return token != undefined && token != null && token.length > 0;
    }

    get UserName() {
        return isPlatformBrowser(this.platformId) && sessionStorage.length > 0 ? sessionStorage.getItem(this.appConstant.USER_NAME) : "";
    }

    get UserFirstName() {
        return isPlatformBrowser(this.platformId) && sessionStorage.length > 0 ? sessionStorage.getItem(this.appConstant.USER_FIRST_NAME) : "";
    }

    get HttpService() {
        return this.httpService;
    }

    authenticate(result: any): void {
        const authResponse = result;
        if (isPlatformBrowser(this.platformId)) {
            sessionStorage.setItem(this.appConstant.TOKEN_KEY, authResponse.token);
            sessionStorage.setItem(this.appConstant.USER_FIRST_NAME, authResponse.firstName);
        }
    }

    cancleAuthention() {
        if (isPlatformBrowser(this.platformId)) {
            sessionStorage.clear();
        }
    }

}