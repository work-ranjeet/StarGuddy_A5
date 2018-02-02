import { NgModule } from "@angular/core";
import { CommonModule } from "@angular/common";
import { FormsModule } from "@angular/forms";
import { RouterModule } from "@angular/router";

import { ManageAccountService } from "./manage.account.Service";

import { AddEmailComponent } from "./addEmail/addEmail.component";
import { AddPhoneNumberComponent } from "./addPhoneNumber/addPhoneNumber.component";
import { ChangeAddressComponent } from "./changeAddress/changeAddress.component";
import { ChangePwdComponent } from "./changePassword/changePwd.component";
import { VerifyPhoneNumberComponent } from "./verifyPhoneNumber/verifyPhoneNumber.component";

@NgModule({
    declarations: [
        AddEmailComponent,
        AddPhoneNumberComponent,
        ChangeAddressComponent,
        ChangePwdComponent,
        VerifyPhoneNumberComponent
    ],
    imports: [
        RouterModule,
        CommonModule,
        FormsModule,
        RouterModule.forRoot([
            { path: "addEmail", component: AddEmailComponent },
            { path: "addPhoneNumber", component: AddPhoneNumberComponent },
            { path: "changeAddress", component: ChangeAddressComponent },
            { path: "changePwd", component: ChangePwdComponent },
            { path: "verifyPhoneNumber", component: VerifyPhoneNumberComponent }
        ])
    ],
    providers: [ManageAccountService],
    exports: [
        AddEmailComponent,
        AddPhoneNumberComponent,
        ChangeAddressComponent,
        ChangePwdComponent,
        VerifyPhoneNumberComponent
    ]
})

export class ManageAccountModuleShared {
}
