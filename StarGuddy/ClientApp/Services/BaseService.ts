import { Injectable, Inject } from "@angular/core";
import { RequestOptions, Headers } from "@angular/http";
import { Router } from "@angular/router";
import { AppConstant } from "../Constants/AppConstant";
import { HttpService } from "../Services/HttpClient";
import IJwtPacket = App.Client.Account.IJwtPacket;

@Injectable()

export class BaseService {
    private readonly httpService: HttpService;
    private readonly appConstant: AppConstant;
    private readonly router: Router;

    constructor( @Inject(HttpService) httpService: HttpService, appConstant: AppConstant, router: Router) {
        this.httpService = httpService;
        this.appConstant = appConstant;
        this.router = router;
    }

    get IsAuthenticated() {
        return "";//!!localStorage.getItem(this.appConstant.TOKEN_KEY);
    }

    get UserName() {
        let userName = "";//localStorage.getItem(this.appConstant.USER_NAME);
        return userName != undefined && userName != null ? userName : String.Empty;
    }

    get UserId() {
        let userId = "";//.getItem(this.appConstant.USER_ID);
        return userId != undefined && userId != null ? userId : String.Empty;
    }

    get UserFirstName() {
        return "";//localStorage.getItem(this.appConstant.USER_FIRST_NAME);
    }

    get UserEmail() {
        return "";//.getItem(this.appConstant.USER_EMAIL);
    }

    get HttpService() {
        return this.httpService;
    }

    authenticate(result: any): void {
        if (!result.ok)
            return;

        const authResponse = result.json() ;
        localStorage.setItem(this.appConstant.USER_ID, authResponse.userId);
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