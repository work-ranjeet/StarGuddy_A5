import { NgModule } from "@angular/core";
import { CommonModule } from "@angular/common";
import { FormsModule } from "@angular/forms";
import { RouterModule } from "@angular/router";

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
import { ProfileEditIndex } from "./index/profileEditIndex.component";
import { JobGroupComponent } from "./jobGroup/JobGroup.component";
import { AuthGuard } from "../../../Services/AuthenticationGuard";

@NgModule({
    declarations: [
        ProfileEditActingComponent, ProfileEditCreditsComponent, ProfileEditDancingComponent, ProfileEditModelingComponent,
        ProfileEditPhotosComponent, ProfileEditTrainingsComponent, ProfileEditPhysicalComponent,
        ProfileEditIndex, ProfileEditHeader, ProfileEditMenu, JobGroupComponent
    ],
    imports: [
        RouterModule,
        CommonModule,
        FormsModule,
        RouterModule.forRoot([
            { path: "profile", component: ProfileEditIndex, canActivate: [AuthGuard] },
            { path: "profile/interests", component: JobGroupComponent, canActivate: [AuthGuard] }
        ])
    ],
    providers: [ProfileEditService],
    exports: [
        ProfileEditActingComponent, ProfileEditCreditsComponent, ProfileEditDancingComponent, ProfileEditModelingComponent,
        ProfileEditPhotosComponent, ProfileEditTrainingsComponent, ProfileEditPhysicalComponent,
        ProfileEditIndex, ProfileEditHeader, ProfileEditMenu, JobGroupComponent
    ]
})

export class ProfileEditModuleShared {
}
