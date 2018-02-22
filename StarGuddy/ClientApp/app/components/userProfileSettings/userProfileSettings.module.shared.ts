import { NgModule } from "@angular/core";
import { CommonModule } from "@angular/common";
import { FormsModule } from "@angular/forms";
import { RouterModule } from "@angular/router";

import { UserProfileSettingsService } from "./userProfileSettings.Service";

import { AddEmailComponent } from "./addEmail/addEmail.component";
import { AddPhoneNumberComponent } from "./addPhoneNumber/addPhoneNumber.component";
import { ChangeAddressComponent } from "./changeAddress/changeAddress.component";
import { ChangePwdComponent } from "./changePassword/changePwd.component";
import { VerifyPhoneNumberComponent } from "./verifyPhoneNumber/verifyPhoneNumber.component";
import { UserProfileSettingsIndex } from "./userProfileSettingsIndex/userProfileSettingsIndex.component";
import { PageHeadingComponent } from "../common/pageHeading/pageHeadingComponent";
import { HeadingComponent } from "../common/headings/headingComponent";

@NgModule({
    declarations: [
        PageHeadingComponent,
        HeadingComponent,
        AddEmailComponent,
        AddPhoneNumberComponent,
        ChangeAddressComponent,
        ChangePwdComponent,
        VerifyPhoneNumberComponent,
        UserProfileSettingsIndex
    ],
    imports: [
        RouterModule,
        CommonModule,
        FormsModule,
        RouterModule.forRoot([
            { path: "profileSetting", component: UserProfileSettingsIndex },
            { path: "addEmail", component: AddEmailComponent },
            { path: "addPhoneNumber", component: AddPhoneNumberComponent },
            { path: "changeAddress", component: ChangeAddressComponent },
            { path: "changePwd", component: ChangePwdComponent },
            { path: "verifyPhoneNumber", component: VerifyPhoneNumberComponent }
        ])
    ],
    providers: [UserProfileSettingsService],
    exports: [
        PageHeadingComponent,
        HeadingComponent,
        AddEmailComponent,
        AddPhoneNumberComponent,
        ChangeAddressComponent,
        ChangePwdComponent,
        VerifyPhoneNumberComponent,
        UserProfileSettingsIndex
    ]
})

export class UserProfileSettingModuleShared {
}
