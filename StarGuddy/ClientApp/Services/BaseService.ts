import { Injectable, Inject } from "@angular/core";
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
        appConstant: AppConstant, router: Router) {
        this.httpService = httpService;
        this.appConstant = appConstant;
        this.router = router;
    }
    private get storage(): Storage { return localStorage; }

    get IsAuthenticated() {
        return this.storage.get(this.appConstant.TOKEN_KEY);
    }

    get UserName() {
        let userName = this.storage.getItem(this.appConstant.USER_NAME);
        return userName != undefined && userName != null ? userName : String.Empty;
    }

    //get UserId() {
    //    let userId = this.storage.getItem(this.appConstant.USER_ID);
    //    return userId != undefined && userId != null ? userId : String.Empty;
    //}

    get UserFirstName() {
        return this.storage.getItem(this.appConstant.USER_FIRST_NAME);
    }

    //get UserEmail() {
    //    return this.storage.getItem(this.appConstant.USER_EMAIL);
    //}

    get HttpService() {
        return this.httpService;
    }

    authenticate(result: any): void {
        const authResponse = result;
        if (this.storage == undefined) {
            console.info("Storage is undefined:" + this.storage);
            return;
        }

        this.storage.setItem(this.appConstant.USER_ID, authResponse.userId);
        this.storage.setItem(this.appConstant.TOKEN_KEY, authResponse.token);
        this.storage.setItem(this.appConstant.USER_FIRST_NAME, authResponse.firstName);
        this.storage.setItem(this.appConstant.USER_NAME, authResponse.userName);
        this.storage.setItem(this.appConstant.USER_EMAIL, authResponse.email);
    }

    cancleAuthention() {
        if (this.storage == undefined) {
            console.info("Storage is undefined:" + this.storage);
            return;
        }
        this.storage.clear();
        //this.storage.removeItem(this.appConstant.USER_ID);
        //this.storage.removeItem(this.appConstant.TOKEN_KEY);
        //this.storage.removeItem(this.appConstant.USER_FIRST_NAME);
        //this.storage.removeItem(this.appConstant.USER_NAME);
        //this.storage.removeItem(this.appConstant.USER_EMAIL);
    }

}