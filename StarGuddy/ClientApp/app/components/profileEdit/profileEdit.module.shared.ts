import { NgModule, CUSTOM_ELEMENTS_SCHEMA } from "@angular/core";
import { CommonModule } from "@angular/common";
import { FormsModule } from "@angular/forms";
import { RouterModule } from "@angular/router";
//import { MatButtonModule, MatFormFieldModule, MatInputModule, MatRippleModule, MatSelectModule } from '@angular/material';

import { ProfileEditService } from "./profileEdit.Service";
import { ProfileEditHeader } from "./header/profileEditHeader.component";
import { ProfileEditMenu } from "./menu/profileEditMenu.component";
import { ProfileEditActingComponent } from "./acting/profileEditActing.component";
import { ProfileEditCreditsComponent } from "./credits/profileEditCredits.component";
import { ProfileEditDancingComponent } from "./dancing/profileEditDancing.component";
import { ProfileEditModelingComponent } from "./modeling/profileEditModeling.component";
import { ProfileEditPhotosComponent } from "./photos/profileEditPhotos.component";
import { ProfileEditTrainingsComponent } from "./trainings/profileEditTrainings.component";
import { ProfileEditPhysicalComponent } from "./physicalDetails/profileEditPhysical.component";
import { ProfileEditNameComponent } from "./name/profileEditName.component";
import { ProfileEditIntroComponent } from "./intro/profileEditIntro.component";
import { ProfileEditIndex } from "./index/profileEditIndex.component";
import { JobGroupComponent } from "./jobGroup/JobGroup.component";
import { AuthGuard } from "../../../Services/AuthenticationGuard";

@NgModule({
    declarations: [
        ProfileEditActingComponent, ProfileEditCreditsComponent, ProfileEditDancingComponent, ProfileEditModelingComponent,
        ProfileEditPhotosComponent, ProfileEditTrainingsComponent, ProfileEditPhysicalComponent,
        ProfileEditIndex, ProfileEditHeader, ProfileEditMenu, JobGroupComponent, ProfileEditNameComponent, ProfileEditIntroComponent
    ],
    imports: [
        RouterModule,
        CommonModule,
        FormsModule,
        //MatButtonModule, MatFormFieldModule, MatInputModule, MatRippleModule, MatSelectModule,
        RouterModule.forRoot([
            {
                path: "profile",
                children: [
                    { path: "", redirectTo: "edit", pathMatch: "full" },
                    { path: "edit", component: ProfileEditIndex, canActivate: [AuthGuard] },
                    { path: "name", component: ProfileEditNameComponent, canActivate: [AuthGuard] },
                    { path: "intro", component: ProfileEditIntroComponent, canActivateChild: [AuthGuard] },
                    { path: "interests", component: JobGroupComponent, canActivateChild: [AuthGuard] }
                ]
            }
        ])
    ],
    providers: [ProfileEditService],
    exports: [

        ProfileEditActingComponent, ProfileEditCreditsComponent, ProfileEditDancingComponent, ProfileEditModelingComponent,
        ProfileEditPhotosComponent, ProfileEditTrainingsComponent, ProfileEditPhysicalComponent,
        ProfileEditIndex, ProfileEditHeader, ProfileEditMenu, JobGroupComponent, ProfileEditNameComponent, ProfileEditIntroComponent
    ],
    schemas: [CUSTOM_ELEMENTS_SCHEMA]
})

export class ProfileEditModuleShared {
}
