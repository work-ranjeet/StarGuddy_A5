import { Injectable, Inject, PLATFORM_ID } from '@angular/core';
import { HttpClient, HttpHeaders, HttpRequest, HttpParams } from '@angular/common/http';
import { AppConstant } from "../Constants/AppConstant";
import { Observable } from 'rxjs/Observable';
import { isPlatformBrowser } from "@angular/common";

@Injectable()
export class HttpService {

    private readonly baseUrl: string;

    constructor(
        @Inject("BASE_URL") baseUrl: string,
        @Inject(PLATFORM_ID) private platformId: Object,
        private http: HttpClient, private appConstant: AppConstant) {
        this.baseUrl = baseUrl;

    }

    private get UrlPrifix() { return this.baseUrl + "api/"; }

    get TokenHeader(): HttpHeaders {
        if (!isPlatformBrowser(this.platformId)) {
            console.info("LocalStorage is undefined");
            return new HttpHeaders();
        }

        let token = isPlatformBrowser(this.platformId) && localStorage.length > 0 ? localStorage.getItem(this.appConstant.TOKEN_KEY) : String.Empty;
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

    deleteData<T>(Url: string, params: HttpParams) {
        return this.http.delete<T>(this.UrlPrifix + Url, {
            headers: this.TokenHeader,
            params: params
        });
    }

    postSimple(Url: string, data: any) {
        return this.http.post(this.UrlPrifix + Url, data);
    }
}