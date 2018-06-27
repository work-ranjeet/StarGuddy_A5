import { Injectable, Inject } from '@angular/core';
import { Http, Headers, RequestOptions } from '@angular/http';
import { AppConstant } from "../Constants/AppConstant";

@Injectable()
export class HttpService {

    private readonly baseUrl: string;

    constructor(
        @Inject("BASE_URL") baseUrl: string,
        private http: Http, private appConstant: AppConstant) {
        this.baseUrl = baseUrl;
    }

    private get UrlPrifix() { return this.baseUrl + "api/"; }

    get TokenHeader(): Headers {
        let token = localStorage.getItem(this.appConstant.TOKEN_KEY);
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