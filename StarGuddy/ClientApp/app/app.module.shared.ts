import { NgModule } from "@angular/core";
import { CommonModule } from "@angular/common";
import { FormsModule } from "@angular/forms";
import { HttpModule } from "@angular/http";
//import { HttpClientModule } from "@angular/common/http"
import { RouterModule } from "@angular/router";
import { StorageServiceModule } from 'angular-webstorage-service';
//import { MatButtonModule, MatCardModule, MatInputModule, MatSnackBarModule, MatToolbarModule } from "@angular/material";
//import { MatInputModule } from "@angular/material/input";

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



@NgModule({
    declarations: [
        AppComponent, 
        CounterComponent, FetchDataComponent
    ],
    imports: [
        CommonModule, HttpModule, FormsModule, StorageServiceModule, // MatInputModule,
        //MatButtonModule, MatCardModule, MatInputModule, MatSnackBarModule, MatToolbarModule,
        CommonModuleShared,
        HomeModuleShared,
        AccountModuleShared,
        UserProfileModuleShared,
        UserProfileSettingModuleShared,
        RouterModule.forRoot([
            { path: "", redirectTo: "home", pathMatch: "full" },
            { path: "counter", component: CounterComponent },
            { path: "fetch-data", component: FetchDataComponent },
            { path: "**", redirectTo: "home" }
        ])
    ],
    providers: [AppConstant, DbOperation, HttpService, BaseService, DataConverter, DataValidator]
})
export class AppModuleShared {
}
