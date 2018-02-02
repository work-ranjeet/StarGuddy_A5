import { NgModule } from "@angular/core";
import { CommonModule } from "@angular/common";
import { FormsModule } from "@angular/forms";
import { RouterModule } from "@angular/router";

import { AccountService } from "./Account.Service";
import { AccountLoginComponent } from "./login/login.component";
import { SignUpComponent } from "./signup/signup.component";
import { SignUpJobProviderComponent } from "./signup/jobProvider/jobProvider.component";
import { SignUpJobSeekerComponent } from "./signup/jobSeeker/jobSeeker.component";

//Account Management
import { AddEmailComponent } from "./management/addEmail/addEmail.component";
import { AddPhoneNumberComponent } from "./management/addPhoneNumber/addPhoneNumber.component";
import { ChangeAddressComponent } from "./management/changeAddress/changeAddress.component";
import { ChangePwdComponent } from "./management/changePassword/changePwd.component";
import { VerifyPhoneNumberComponent } from "./management/verifyPhoneNumber/verifyPhoneNumber.component";

@NgModule({
    declarations: [
        AccountLoginComponent,
        SignUpComponent,
        SignUpJobProviderComponent,
        SignUpJobSeekerComponent,
        AddEmailComponent, AddPhoneNumberComponent, ChangeAddressComponent, ChangePwdComponent, VerifyPhoneNumberComponent
    ],
    imports: [
        RouterModule,
        CommonModule,
        FormsModule,
        RouterModule.forRoot([
            { path: "login", component: AccountLoginComponent },
            { path: "signup", component: SignUpComponent },
            { path: "jobseeker", component: SignUpJobSeekerComponent },
            { path: "jobprovider", component: SignUpJobProviderComponent },
            { path: "addEmail", component: AddEmailComponent },
            { path: "addPhoneNumber", component: AddPhoneNumberComponent },
            { path: "changeAddress", component: ChangeAddressComponent },
            { path: "changePwd", component: ChangePwdComponent },
            { path: "verifyPhoneNumber", component: VerifyPhoneNumberComponent }
        ])
    ],
    providers: [AccountService],
    exports: [
        AccountLoginComponent,
        SignUpComponent,
        SignUpJobProviderComponent,
        SignUpJobSeekerComponent,
        AddEmailComponent, AddPhoneNumberComponent, ChangeAddressComponent, ChangePwdComponent, VerifyPhoneNumberComponent
    ]
})

export class AccountModuleShared {
}
