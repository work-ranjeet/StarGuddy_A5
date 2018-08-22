import { CommonModule } from "@angular/common";
import { NgModule } from "@angular/core";
import { FormsModule } from "@angular/forms";
import { RouterModule } from "@angular/router";
import { PublicProfileService } from "../publicProfile/PublicProfile.Service";
import { PublicPhysicalDetailsComponent } from "../publicProfile/details/PublicPhysicalDetails/publicPhysicalDetails.component";
import { PublicProfileDetails } from "../publicProfile/details/details.component";
import { PublicProfileHeader } from "../publicProfile/header/header.component";
import { PublicProfileIndex } from "../publicProfile/index/index.component";
import { PublicProfileMenu } from "../publicProfile/menu/menu.component";

@NgModule({
    declarations: [
        PublicProfileIndex,
        PublicProfileHeader,
        PublicProfileMenu,
        PublicProfileDetails,
        PublicPhysicalDetailsComponent
    ],
    imports: [
        RouterModule,
        CommonModule,
        FormsModule,
        RouterModule.forRoot([
            { path: "profile/:profileUrl", component: PublicProfileIndex }
        ])
    ],
    providers: [PublicProfileService],
    exports: [PublicProfileIndex, PublicProfileHeader, PublicProfileMenu, PublicProfileDetails, PublicPhysicalDetailsComponent]
})

export class PublicProfileModuleShared {
}
