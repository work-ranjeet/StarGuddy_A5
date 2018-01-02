import { Component } from '@angular/core';

@Component({
    selector: 'account-signup',
    template: `<div class="container">
                    <div style="width:150px; padding-top:10%" class="margin-auto">
                        <div class="row">
                            <div class="col-sm-6 text-right">
                                <a class="" [routerLink]="['/jobseeker']">Are you have talent?</a>
                            </div>
                            <div class="col-sm-6 text-left">
                                <a class="" [routerLink]="['/jobprovider']">Are you searching for talent?</a>
                            </div>
                        </div>
                    </div>
                </div>`
})
export class SignUpComponent {
}
