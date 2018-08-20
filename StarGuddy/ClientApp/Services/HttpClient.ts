import { Injectable, Inject, PLATFORM_ID } from '@angular/core';
import { HttpClient,  HttpParams } from '@angular/common/http';
import { Observable } from 'rxjs/Observable';
import { isPlatformBrowser } from "@angular/common";

@Injectable()
export class HttpService {

    private readonly baseUrl: string;

    constructor(
        @Inject("BASE_URL") baseUrl: string,
        @Inject(PLATFORM_ID) private platformId: Object,
        private http: HttpClient) {
        this.baseUrl = baseUrl;

    }

    private get UrlPrifix() { return this.baseUrl + "api/"; }

    get(Url: string) {
        return this.http.get(this.UrlPrifix + Url);
    }

    getData<T>(Url: string): Observable<T> {
        return this.http.get<T>(this.UrlPrifix + Url);
    }

    post(Url: string, data: any) {
        return this.http.post(this.UrlPrifix + Url, data);
    }

    postData<T>(Url: string, data: any) {
        return this.http.post<T>(this.UrlPrifix + Url, data);
    }

    deleteData<T>(Url: string, params: HttpParams) {
        return this.http.delete<T>(this.UrlPrifix + Url, {
            params: params
        });
    }

    postSimple(Url: string, data: any) {
        return this.http.post(this.UrlPrifix + Url, data);
    }
}