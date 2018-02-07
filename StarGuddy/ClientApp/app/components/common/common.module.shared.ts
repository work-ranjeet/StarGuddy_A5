import { NgModule } from "@angular/core";
import { CommonModule } from "@angular/common";
import { FormsModule } from "@angular/forms";
import { RouterModule } from "@angular/router";

import { NavMenuComponent } from "./navmenu/navmenu.component";
import { FooterComponent } from "./footer/footer.component";
import { LogInOutComponent } from "./logInOut/logInOut.component";

@NgModule({
    declarations: [
        LogInOutComponent,
        NavMenuComponent,
        FooterComponent
    ],
    imports: [RouterModule, CommonModule, FormsModule],
    exports: [LogInOutComponent, NavMenuComponent, FooterComponent]
})

export class CommonModuleShared {
}
