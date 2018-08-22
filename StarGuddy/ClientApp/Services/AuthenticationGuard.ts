import { Injectable } from "@angular/core";
import { Router, CanActivate, ActivatedRouteSnapshot, RouterStateSnapshot } from "@angular/router";
import { BaseService } from "./BaseService";

@Injectable()
export class AuthGuard implements CanActivate {

    constructor(
        private readonly router: Router,
        private readonly baseService: BaseService) { }

    canActivate(route: ActivatedRouteSnapshot, state: RouterStateSnapshot): boolean {
        if (this.baseService.IsAuthenticated) {
            return true;
        }
        else {
            this.baseService.cancleAuthention();
            this.router.navigate(["login"], { queryParams: { returnUrl: state.url } });
        }

        return false;
    }
}