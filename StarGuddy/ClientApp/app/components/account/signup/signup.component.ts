import { Component } from '@angular/core';
import { Router, ActivatedRoute } from "@angular/router";

@Component({
    selector: 'account-signup',
    template: `<div class="container">
                    <div style="width:450px; padding-top:16%" class="margin-auto">
                        <div class="row">
                            <div class="col-sm-6 col-md-6 col-lg-6">                              
                                    <div (click)="loadPage('jobseeker')" style="height:200px; background-color: #006684; border-radius:5px; padding:5px; color:white; cursor: pointer;">
                                        <div style="height: 30px; font-size: 22px;">
                                            <i class="glyphicon glyphicon-globe" style="font-size:22px; float:left; padding-top: 5px;"></i>
                                            <span>&nbsp;Talent Directory</span>
                                        </div>
                                        <hr style="margin-top:5px; margin-bottom:5px;"/>
                                        <p style="padding:5px; text-align: center;">Are you have talent?</p>
                                    </div>
                            </div>
                            <div class="col-sm-6  col-lg-6 col-md-6">
                                <div (click)="loadPage('jobprovider')" style="height:200px; background-color: #006684; border-radius:5px; padding:5px; color:white; cursor: pointer;">
                                        <div style="height: 30px; font-size: 22px;">
                                            <i class="glyphicon glyphicon-bullhorn" style="font-size:22px; float:leftpadding-top: 5px; "></i>
                                            <span>&nbsp;Talent Search</span>
                                        </div>
                                        <hr style="margin-top:5px; margin-bottom:5px;"/>
                                        <p style="padding:5px; text-align: center;">Are you searching for talent?</p>
                                 </div>
                            </div>
                        </div>
                    </div>
                </div>`
})
export class SignUpComponent {

    router: Router;

    constructor(router: Router) { this.router = router; }

    ngOnInit() { }

    loadPage(value: string) {
        this.router.navigate(["/" + value]);
    }
}
