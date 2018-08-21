import { NgModule } from "@angular/core";
import { CommonModule } from "@angular/common";
import { FormsModule } from "@angular/forms";
import { RouterModule } from "@angular/router";

import { PublicProfileService } from "../publicProfile/PublicProfile.Service";

import { PublicProfileIndex } from "../publicProfile/index/index.component";

@NgModule({
    declarations: [
        PublicProfileIndex
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
    exports: [PublicProfileIndex]
})

export class PublicProfileModuleShared {
}
