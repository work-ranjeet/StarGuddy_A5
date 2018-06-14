import { Injectable, Inject } from '@angular/core';
import { Http, Headers, RequestOptions } from '@angular/http';
//import { HttpClient, HttpHeaders, HttpRequest } from '@angular/common/http';
import { AppConstant } from "../Constants/AppConstant";
//import { LOCAL_STORAGE, WebStorageService } from 'angular-webstorage-service';

@Injectable()
export class HttpService {

    private readonly baseUrl: string;

    constructor(
        @Inject("BASE_URL") baseUrl: string, // @Inject(LOCAL_STORAGE) private localStorage: WebStorageService,
        private http: Http, private appConstant: AppConstant) {
        this.baseUrl = baseUrl;
    }

    private get UrlPrifix() { return this.baseUrl + "api/"; }

    get TokenHeader(): Headers {
        let token = "";//this.localStorage.get(this.appConstant.TOKEN_KEY);
        //let header = new Headers({ 'Authorization': 'Bearer ' + (token == null ? "" : token), '': '' });
        let header = new Headers();
        header.append('Content-Type', 'application/json');
        header.append('Authorization', 'Bearer ' + (token == null ? "" : token));

        return header;
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
}