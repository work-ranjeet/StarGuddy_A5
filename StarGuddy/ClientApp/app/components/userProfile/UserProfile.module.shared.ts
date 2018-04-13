import { NgModule } from "@angular/core";
import { CommonModule } from "@angular/common";
import { FormsModule } from "@angular/forms";
import { RouterModule } from "@angular/router";

import { UserProfileService } from "./UserProfile.Service";

import { UserProfileIndex } from "./UserProfileIndex/UserProfileIndex.component"

@NgModule({
    declarations: [
        UserProfileIndex
    ],
    imports: [
        RouterModule,
        CommonModule,
        FormsModule,
        RouterModule.forRoot([
            { path: "profile", component: UserProfileIndex }
        ])
    ],
    providers: [UserProfileService],
    exports: [
        UserProfileIndex
    ]
})

export class UserProfileModuleShared {
}
