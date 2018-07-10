import { Injectable, Inject } from '@angular/core';
import { HttpClient, HttpHeaders, HttpRequest } from '@angular/common/http';
import { AppConstant } from "../Constants/AppConstant";
import { Observable } from 'rxjs/Observable';
@Injectable()
export class HttpService {

    private readonly baseUrl: string;

    constructor(
        @Inject("BASE_URL") baseUrl: string,
        private http: HttpClient, private appConstant: AppConstant) {
        this.baseUrl = baseUrl;

    }

    private get UrlPrifix() { return this.baseUrl + "api/"; }

    private get storage(): Storage { return localStorage; }
    get TokenHeader(): HttpHeaders {
        if (this.storage == undefined) {
            console.info("LocalStorage is undefined:" + this.storage);
            return new HttpHeaders();
        }

        let token = this.storage.getItem(this.appConstant.TOKEN_KEY);
        if (token != undefined && token != null) {

            return new HttpHeaders({ 'Authorization': 'Bearer ' + token });
        }

        return new HttpHeaders();
    }

    get(Url: string) {
        return this.http.get(this.UrlPrifix + Url, {
            headers: this.TokenHeader
        });
    }

    getData<T>(Url: string): Observable<T> {
        return this.http.get<T>(this.UrlPrifix + Url, {
            headers: this.TokenHeader
        });
    }

    post(Url: string, data: any) {
        return this.http.post(this.UrlPrifix + Url, data, {
            headers: this.TokenHeader
        });
    }

    postData<T>(Url: string, data: any) {
        return this.http.post<T>(this.UrlPrifix + Url, data, {
            headers: this.TokenHeader
        });
    }

    postSimple(Url: string, data: any) {
        return this.http.post(this.UrlPrifix + Url, data);
    }
}