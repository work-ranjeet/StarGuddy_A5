﻿//import { Observable } from "rxjs/Observable";
import "rxjs/add/operator/map";
import { BehaviorSubject } from "rxjs/BehaviorSubject";
import { Injectable, Inject} from "@angular/core";
import { Http } from "@angular/http";
import { Router } from "@angular/router";
import { BaseService } from "../../../Services/BaseService";
import { DataConverter } from "../../../Helper/DataConverter";
import ILoginData = App.Client.Account.ILoginData;


@Injectable()
export class AccountService {

    private isLoggedInSource = new BehaviorSubject<boolean>(false);

    constructor(@Inject(BaseService) private readonly baseService: BaseService,
        private readonly http: Http,
        private readonly router: Router,
        private readonly dataConverter: DataConverter) {}


    get IsLoggedIn() { return this.isLoggedInSource.asObservable(); }

    get IsAuthenticated() { return this.baseService.IsAuthenticated; }

    login(loginData: ILoginData) {
        return this.http.post(this.baseService.BaseApiUrl + "Account/login", loginData).map(response => {
            this.isLoggedInSource.next(true);
            this.baseService.authenticate(response);
        });
    }

    getUserFirstName(): string {
        return this.dataConverter.ConvertToString(this.baseService.UserFirstName);
    }

    //register(user) {
    //    delete user.confirmPassword;
    //    this.http.post(this.BASE_URL + "/register", user).subscribe(res => {
    //        this.authenticate(res);
    //    });
    //}

    logOut() {
        this.isLoggedInSource.next(false);
        this.baseService.cancleAuthention();
    }
}