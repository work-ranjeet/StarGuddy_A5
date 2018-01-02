import { NgModule } from "@angular/core";
import { CommonModule } from "@angular/common";
import { FormsModule } from "@angular/forms";
import { RouterModule } from "@angular/router";

import { NavMenuComponent } from "./navmenu/navmenu.component";
import { FooterComponent } from "./footer/footer.component";
import { LogOutComponent } from "./logOut/logOut.component";

@NgModule({
    declarations: [
        LogOutComponent,
        NavMenuComponent,
        FooterComponent
    ],
    imports: [RouterModule, CommonModule, FormsModule],
    exports: [LogOutComponent, NavMenuComponent, FooterComponent]
})

export class CommonModuleShared {
}
