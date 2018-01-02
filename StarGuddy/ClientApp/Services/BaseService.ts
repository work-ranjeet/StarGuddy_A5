import { Injectable, Inject } from "@angular/core";
import { Http, RequestOptions } from "@angular/http";
import { Router } from "@angular/router";
import { AppConstant } from "../Constants/AppConstant";

@Injectable()

export class BaseService {

    private readonly appConstant: AppConstant;
    private readonly baseUrl: string;
    private readonly http: Http;
    private readonly router: Router;

    constructor(appConstant: AppConstant, http: Http, @Inject("BASE_URL") baseUrl: string, router: Router) {
        this.appConstant = appConstant;
        this.baseUrl = baseUrl;
        this.http = http;
        this.router = router;
    }

    get BaseUrl() {
        return this.baseUrl;
    }

    get BaseApiUrl() {
        return this.baseUrl + "api/";
    }

    get IsAuthenticated() {
        return !!localStorage.getItem(this.appConstant.TOKEN_KEY);
    }

    get UserName() {
        return localStorage.getItem(this.appConstant.USER_NAME);
    }

    get UserId() {
        return localStorage.getItem(this.appConstant.USER_ID);
    }

    get UserFirstName() {
        return localStorage.getItem(this.appConstant.USER_FIRST_NAME);
    }

    get UserEmail() {
        return localStorage.getItem(this.appConstant.USER_EMAIL);
    }

    get TokenHeader() {
        let token = localStorage.getItem(this.appConstant.TOKEN_KEY);
        let header = new Headers({ 'Authorization': 'Bearer ' + (token == null ? "" : token) });
        return new RequestOptions(({ headers: header }) as any);
    }

    authenticate(result: any) {
        if (!result.ok)
            return;

        const authResponse = result.json().result;
        localStorage.setItem(this.appConstant.USER_ID, authResponse.id);
        localStorage.setItem(this.appConstant.TOKEN_KEY, authResponse.token);
        localStorage.setItem(this.appConstant.USER_FIRST_NAME, authResponse.firstName);
        localStorage.setItem(this.appConstant.USER_NAME, authResponse.userName);
        localStorage.setItem(this.appConstant.USER_EMAIL, authResponse.email);
    }

    cancleAuthention() {
        localStorage.removeItem(this.appConstant.USER_ID);
        localStorage.removeItem(this.appConstant.TOKEN_KEY);
        localStorage.removeItem(this.appConstant.USER_FIRST_NAME);
        localStorage.removeItem(this.appConstant.USER_NAME);
        localStorage.removeItem(this.appConstant.USER_EMAIL);
    }

}