import { NgModule } from "@angular/core";
import { CommonModule } from "@angular/common";
import { HttpClientModule, HTTP_INTERCEPTORS } from "@angular/common/http"
import { RouterModule } from "@angular/router";
import { Expertlavel } from "../Enums/enums";
import { JwtInterceptor } from "../Interceptor/jwt.interceptor";


// Directives

//// Providers
import { AppConstant, DbOperation } from "../Constants/AppConstant";
import { DataConverter } from "../Helper/DataConverter";
import { DataValidator } from "../Helper/DataValidator";
import { BaseService } from "../Services/BaseService";

//// shared Modules
import { CommonModuleShared } from "./components/common/common.module.shared";
import { HomeModuleShared } from "./components/home/home.module.shared";
import { AccountModuleShared } from "./components/account/account.module.shared";
import { UserProfileSettingModuleShared } from "./components/userProfileSettings/userProfileSettings.module.shared"
import { UserProfileModuleShared } from "./components/userProfile/UserProfile.module.shared";

import { AppComponent } from "./components/app/app.component";
import { HttpService } from "../Services/HttpClient";
import { FetchDataComponent } from "./components/fetchdata/fetchdata.component";
import { CounterComponent } from "./components/counter/counter.component";
import { AuthGuard } from "../Services/AuthenticationGuard";



@NgModule({
    declarations: [
        AppComponent,
        CounterComponent, FetchDataComponent
    ],
    imports: [
        CommonModule, HttpClientModule, //FormsModule, ReactiveFormsModule
        CommonModuleShared,
        HomeModuleShared,
        AccountModuleShared,
        UserProfileModuleShared,
        UserProfileSettingModuleShared,
        RouterModule.forRoot([
            { path: "", redirectTo: "home", pathMatch: "full", canActivate: [AuthGuard] },
            { path: "counter", component: CounterComponent },
            { path: "fetch-data", component: FetchDataComponent },
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


