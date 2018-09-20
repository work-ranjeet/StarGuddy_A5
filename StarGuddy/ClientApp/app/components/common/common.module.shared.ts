import { NgModule } from "@angular/core";
import { CommonModule } from "@angular/common";
import { FormsModule } from "@angular/forms";
import { RouterModule } from "@angular/router";

import { NavMenuComponent } from "./navmenu/navmenu.component";
import { FooterComponent } from "./footer/footer.component";

import { PageHeadingComponent } from "../common/pageHeading/pageHeadingComponent";
import { HeadingComponent } from "../common/headings/headingComponent";

import { LogInOutComponent } from "./logInOut/logInOut.component";


@NgModule({
    declarations: [
        NavMenuComponent,
        FooterComponent,
        PageHeadingComponent,
        HeadingComponent,
        LogInOutComponent
    ],
    imports: [RouterModule, CommonModule, FormsModule],
    exports: [NavMenuComponent, FooterComponent, PageHeadingComponent, HeadingComponent, LogInOutComponent]
})

export class CommonModuleShared {
}
