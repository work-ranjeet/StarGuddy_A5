import { Injectable, Inject } from '@angular/core';
//import { Http, Headers, RequestOptions } from '@angular/http';
import { HttpClient, HttpHeaders, HttpRequest } from '@angular/common/http';
import { AppConstant } from "../Constants/AppConstant";

@Injectable()
export class HttpService {

    private readonly baseUrl: string;

    constructor(
        @Inject("BASE_URL") baseUrl: string,
        private http: HttpClient, private appConstant: AppConstant) {
        this.baseUrl = baseUrl;
    }

    private get UrlPrifix() { return this.baseUrl + "api/"; }

    get TokenHeader(): HttpHeaders {


        let token = localStorage.getItem(this.appConstant.TOKEN_KEY);
        if (token != undefined && token != null) {

            return  new HttpHeaders({ 'Authorization': 'Bearer ' + token });
        }

        return new HttpHeaders();
    }

    get(Url: string) {
        return this.http.get(this.UrlPrifix + Url, {
            headers: this.TokenHeader
        });
    }

    post(Url: string, data: any) {
        return this.http.post(this.UrlPrifix + Url, data, {
            headers: this.TokenHeader
        });
    }

    postSimple(Url: string, data: any) {
        return this.http.post(this.UrlPrifix + Url, data);
    }
}