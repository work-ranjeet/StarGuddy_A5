import { NgModule } from "@angular/core";
import { CommonModule } from "@angular/common";
import { FormsModule } from "@angular/forms";
import { RouterModule } from "@angular/router";

import { NavMenuComponent } from "./navmenu/navmenu.component";
import { FooterComponent } from "./footer/footer.component";
import { LogInOutComponent } from "./logInOut/logInOut.component";

import { PageHeadingComponent } from "../common/pageHeading/pageHeadingComponent";
import { HeadingComponent } from "../common/headings/headingComponent";
import { JobGroupComponent } from "../common/jobGroup/JobGroup.component";


@NgModule({
    declarations: [
        LogInOutComponent,
        NavMenuComponent,
        FooterComponent,
        PageHeadingComponent,
        HeadingComponent,
        JobGroupComponent
    ],
    imports: [RouterModule, CommonModule, FormsModule],
    exports: [LogInOutComponent, NavMenuComponent, FooterComponent, PageHeadingComponent, HeadingComponent, JobGroupComponent]
})

export class CommonModuleShared {
}
