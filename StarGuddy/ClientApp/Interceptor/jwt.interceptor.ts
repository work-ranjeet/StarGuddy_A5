﻿import { Injectable, PLATFORM_ID, Inject } from "@angular/core";
import { HttpRequest, HttpHandler, HttpEvent, HttpInterceptor, HttpErrorResponse } from "@angular/common/http";
import { isPlatformBrowser } from "@angular/common";
import { AppConstant } from "../Constants/AppConstant";

import { Observable } from 'rxjs/Observable'
//import { Observable } from 'rxjs';
//import { catchError } from 'rxjs/operators';
//import 'rxjs/add/observable/throw'
//import 'rxjs/add/operator/catch';

@Injectable()
export class JwtInterceptor implements HttpInterceptor {

    constructor(
        @Inject(PLATFORM_ID) private platformId: Object,
        private appConstant: AppConstant) { }

    intercept(request: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
        try {
            let token = isPlatformBrowser(this.platformId) && sessionStorage.length > 0 ? sessionStorage.getItem(this.appConstant.TOKEN_KEY) : String.Empty;
            if (token != undefined && token != null) {
                request = request.clone({
                    setHeaders: {
                        Authorization: `Bearer ${token}`
                    }
                });
            }

            //return next.handle(request).catch(error => {
            //    if (error instanceof HttpErrorResponse) {
            //        if (error.status === 401) {
            //            //Unauthorized Error response
            //            if (isPlatformBrowser(this.platformId)) {
            //                localStorage.clear();
            //            }
            //            console.info(error.statusText);
            //            location.reload(true);
            //        }
            //    };

            //    return Observable.of(error);
            //    //return Observable.throw(error.message || error.statusText);
            //});

        }
        catch (er) {
            console.error(er);
        }

        return next.handle(request);
    }
}