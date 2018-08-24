import { CommonModule } from "@angular/common";
import { NgModule } from "@angular/core";
import { FormsModule } from "@angular/forms";
import { RouterModule } from "@angular/router";
import { ProfileService } from "../profile/profile.Service";
import { ProfileDetails } from "../profile/details/details.component";
import { ProfileHeader } from "../profile/header/header.component";
import { ProfileIndex } from "../profile/index/index.component";
import { ProfileMenu } from "../profile/menu/menu.component";
import { ProfilePhotosComponent } from "../profile/details/photos/photos.component";
import { PhysicalDetailsComponent } from "../profile/details/physicalDetails/physicalDetails.component";
import { ProfileCreditsComponent } from "../profile/details/credits/credits.component";
import { ProfileActingComponent } from "../profile/details/acting/acting.component";
import { ProfileDancingComponent } from "../profile/details/dancing/dancing.component";
import { ProfileModelingComponent } from "../profile/details/modeling/modeling.component";

@NgModule({
    declarations: [
        ProfileIndex,
        ProfileHeader,
        ProfileMenu,
        ProfileDetails,
        ProfilePhotosComponent, PhysicalDetailsComponent, ProfileCreditsComponent,
        ProfileActingComponent, ProfileDancingComponent, ProfileModelingComponent
    ],
    imports: [
        RouterModule,
        CommonModule,
        FormsModule,
        RouterModule.forRoot([
            { path: "profile/:profileUrl", component: ProfileIndex }
        ])
    ],
    providers: [ProfileService],
    exports: [
        ProfileIndex, ProfileHeader, ProfileMenu, ProfileDetails,
        ProfilePhotosComponent, PhysicalDetailsComponent, ProfileCreditsComponent,
        ProfileActingComponent, ProfileDancingComponent, ProfileModelingComponent
    ]
})

export class ProfileModuleShared {
}
