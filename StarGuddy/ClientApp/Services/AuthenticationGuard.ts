import { Injectable } from "@angular/core";
import { Observable } from 'rxjs/Observable';
import 'rxjs/add/operator/take';
import 'rxjs/add/operator/map';
import { Router, CanActivate, ActivatedRouteSnapshot, RouterStateSnapshot } from "@angular/router";
import { BaseService } from "./BaseService";
import { AccountService } from "../app/components/account/Account.Service";

@Injectable()
export class AuthenticationGuard implements CanActivate {

    constructor(
        private readonly router: Router,
        private readonly baseService: BaseService,
        private readonly accountService: AccountService)
    { }

   
    canActivate( next: ActivatedRouteSnapshot, state: RouterStateSnapshot): Observable<boolean> {
        return this.accountService.IsLoggedIn   
            .take(1)                           
            .map((isLoggedIn: boolean) => { 

                if (this.baseService.UserName) {
                    return true;
                }

                if (!isLoggedIn) {
                    this.router.navigate(["login"], { queryParams: { returnUrl: state.url } });
                    return false;
                }

                return true;
            });
    }
}