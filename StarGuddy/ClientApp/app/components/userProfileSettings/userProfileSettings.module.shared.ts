import { NgModule } from "@angular/core";
import { CommonModule } from "@angular/common";
import { FormsModule } from "@angular/forms";
import { RouterModule } from "@angular/router";
import { CommonModuleShared } from "../common/common.module.shared";

import { UserProfileSettingsService } from "./userProfileSettings.Service";

import { AddEmailComponent } from "./addEmail/addEmail.component";
import { AddPhoneNumberComponent } from "./addPhoneNumber/addPhoneNumber.component";
import { ChangeAddressComponent } from "./changeAddress/changeAddress.component";
import { ChangePwdComponent } from "./changePassword/changePwd.component";
import { ChangeEmailComponent } from "./changeEmail/changeEmail.component";
import { VerifyPhoneNumberComponent } from "./verifyPhoneNumber/verifyPhoneNumber.component";
import { UserProfileSettingsIndex } from "./userProfileSettingsIndex/userProfileSettingsIndex.component";
import { PageHeadingComponent } from "../common/pageHeading/pageHeadingComponent";
import { HeadingComponent } from "../common/headings/headingComponent";
import { AuthGuard } from "../../../Services/AuthenticationGuard";

@NgModule({
    declarations: [
        AddEmailComponent,
        AddPhoneNumberComponent,
        ChangeAddressComponent,
        ChangePwdComponent,
        ChangeEmailComponent,
        VerifyPhoneNumberComponent,
        UserProfileSettingsIndex
    ],
    imports: [
        RouterModule,
        CommonModule,
        FormsModule,
        CommonModuleShared,
        RouterModule.forRoot([
            { path: "profileSetting", component: UserProfileSettingsIndex, canActivate: [AuthGuard]},
            { path: "addEmail", component: AddEmailComponent, canActivate: [AuthGuard] },
            { path: "addPhoneNumber", component: AddPhoneNumberComponent, canActivate: [AuthGuard]},
            { path: "changeAddress", component: ChangeAddressComponent, canActivate: [AuthGuard]},
            { path: "changePwd", component: ChangePwdComponent, canActivate: [AuthGuard]},
            { path: "changeEmail", component: ChangeEmailComponent, canActivate: [AuthGuard]},
            { path: "verifyPhoneNumber", component: VerifyPhoneNumberComponent, canActivate: [AuthGuard]}
        ])
    ],
    providers: [UserProfileSettingsService],
    exports: [
        AddEmailComponent,
        AddPhoneNumberComponent,
        ChangeAddressComponent,
        ChangePwdComponent,
        ChangeEmailComponent,
        VerifyPhoneNumberComponent,
        UserProfileSettingsIndex
    ]
})

export class UserProfileSettingModuleShared {
}
