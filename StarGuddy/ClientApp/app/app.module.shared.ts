import { CommonModule } from "@angular/common";
import { HTTP_INTERCEPTORS, HttpClientModule } from "@angular/common/http";
import { NgModule } from "@angular/core";
import { RouterModule } from "@angular/router";

//// Providers
import { AppConstant, DbOperation } from "../Constants/AppConstant";
import { DataConverter } from "../Helper/DataConverter";
import { DataValidator } from "../Helper/DataValidator";
import { JwtInterceptor } from "../Interceptor/jwt.interceptor";
import { AuthGuard } from "../Services/AuthenticationGuard";
import { BaseService } from "../Services/BaseService";
import { HttpService } from "../Services/HttpClient";
import { AccountModuleShared } from "./components/account/account.module.shared";
import { AppComponent } from "./components/app/app.component";
import { CommonModuleShared } from "./components/common/common.module.shared";
import { HomeModuleShared } from "./components/home/home.module.shared";
import { ProfileEditModuleShared } from "./components/profileEdit/profileEdit.module.shared";

//// shared Modules
import { ProfileModuleShared } from "./components/profile/profile.module.shared";
import { ProfileSettingModuleShared } from "./components/profileSettings/profileSettings.module.shared";
import { JobGroupComponent } from "./components/common/jobGroup/JobGroup.component";

@NgModule({
    declarations: [
        AppComponent
    ],
    imports: [
        CommonModule, HttpClientModule, //FormsModule, ReactiveFormsModule
        CommonModuleShared,
        HomeModuleShared,
        AccountModuleShared,
        ProfileEditModuleShared,
        ProfileSettingModuleShared,
        ProfileModuleShared,
        RouterModule.forRoot([
            { path: "", redirectTo: "home", pathMatch: "full", canActivate: [AuthGuard] },
            { path: "interests", component: JobGroupComponent },
            { path: "**", redirectTo: "home" }
        ])
    ],
    providers: [AuthGuard, AppConstant, DbOperation, HttpService, BaseService, DataConverter, DataValidator,
        {
            provide: HTTP_INTERCEPTORS,
            useClass: JwtInterceptor,
            multi: true
        }]
})
export class AppModuleShared {
}


