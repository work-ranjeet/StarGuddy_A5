import { Component, Input } from "@angular/core";

@Component({
    selector: "page-heading",
    template: `<div class="row">
                    <div class="col-md-12 page-heading">
                        <h2>{{text}}</h2>
                    </div>
                </div>`
})
export class PageHeadingComponent {
    @Input() text: string;
}
