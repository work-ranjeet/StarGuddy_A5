import { Component, ViewContainerRef } from "@angular/core";
import { ToastsManager } from "ng2-toastr";

@Component({
    selector: "app",
    templateUrl: "./app.component.html",
    styleUrls: ["./app.component.css"]
})
export class AppComponent {
    constructor(public toastr: ToastsManager, vcr: ViewContainerRef) {
        this.toastr.setRootViewContainerRef(vcr);
    }
}
