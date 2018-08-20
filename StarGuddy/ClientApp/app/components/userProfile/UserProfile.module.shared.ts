import { NgModule } from "@angular/core";
import { CommonModule } from "@angular/common";
import { FormsModule } from "@angular/forms";
import { RouterModule } from "@angular/router";

import { UserProfileService } from "./UserProfile.Service";

import { ActingComponent } from "./acting/acting.component";
import { CreditsComponent } from "./credits/credits.component";
import { DancingComponent } from "./dancing/dancing.component";
import { ModelingComponent } from "./modeling/modeling.component";
import { PhotosComponent } from "./photos/photos.component";
import { TrainingsComponent } from "./trainings/trainings.component";
import { PhysicalDetailsComponent } from "./physicalDetails/physicalDetails.component";
import { UserProfileIndex } from "./UserProfileIndex/UserProfileIndex.component";
import { AuthGuard } from "../../../Services/AuthenticationGuard";
 
@NgModule({
    declarations: [
        ActingComponent, CreditsComponent, DancingComponent, ModelingComponent, PhotosComponent, TrainingsComponent,  PhysicalDetailsComponent,
        UserProfileIndex
    ],
    imports: [
        RouterModule,
        CommonModule,
        FormsModule,
        RouterModule.forRoot([
            { path: "profile", component: UserProfileIndex, canActivate: [AuthGuard] }
        ])
    ],
    providers: [UserProfileService],
    exports: [
        ActingComponent, CreditsComponent, DancingComponent, ModelingComponent, PhotosComponent, TrainingsComponent, PhysicalDetailsComponent,
        UserProfileIndex
    ]
})

export class UserProfileModuleShared {
}
