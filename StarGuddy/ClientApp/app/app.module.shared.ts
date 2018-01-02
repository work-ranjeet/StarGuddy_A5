import { NgModule } from "@angular/core";
import { CommonModule } from "@angular/common";
import { FormsModule } from "@angular/forms";
import { HttpModule } from "@angular/http";
import { RouterModule } from "@angular/router";
//import { MatButtonModule, MatCardModule, MatInputModule, MatSnackBarModule, MatToolbarModule } from "@angular/material";
//import { MatInputModule } from "@angular/material/input";

//// Providers
import { AppConstant } from "../Constants/AppConstant";
import { AccountService } from "./components/account/Account.Service";
import { DataConverter } from "../Helper/DataConverter";
import { BaseService } from "../Services/BaseService";

//// shared Modules
import { CommonModuleShared } from "./components/common/common.module.shared";
import { HomeModuleShared } from "./components/home/home.module.shared";

import { AppComponent } from "./components/app/app.component";
import { FetchDataComponent } from "./components/fetchdata/fetchdata.component";
import { CounterComponent } from "./components/counter/counter.component";

import { AccountLoginComponent } from "./components/account/login/login.component";

import { SignUpComponent } from "./components/account/signup/signup.component";
import { SignUpJobProviderComponent } from "./components/account/signup/jobProvider/jobProvider.component";
import { SignUpJobSeekerComponent } from "./components/account/signup/jobSeeker/jobSeeker.component";


@NgModule({
    declarations: [
        AppComponent,
        AccountLoginComponent, SignUpComponent, SignUpJobProviderComponent, SignUpJobSeekerComponent,
        CounterComponent, FetchDataComponent
    ],
    imports: [
        CommonModule, HttpModule, FormsModule,// MatInputModule,
        //MatButtonModule, MatCardModule, MatInputModule, MatSnackBarModule, MatToolbarModule,
        CommonModuleShared,
        HomeModuleShared,
        RouterModule.forRoot([
            { path: "", redirectTo: "home", pathMatch: "full" },
            { path: "login", component: AccountLoginComponent },
            { path: "signup", component: SignUpComponent },
            { path: "jobseeker", component: SignUpJobSeekerComponent },
            { path: "jobprovider", component: SignUpJobProviderComponent },
            { path: "counter", component: CounterComponent },
            { path: "fetch-data", component: FetchDataComponent },
            { path: "**", redirectTo: "home" }
        ])
    ],
    providers: [AppConstant, BaseService, AccountService, DataConverter]
})
export class AppModuleShared {
}
