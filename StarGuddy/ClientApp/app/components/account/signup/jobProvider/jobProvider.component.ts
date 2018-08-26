import { Component } from "@angular/core";
import { Router, ActivatedRoute } from "@angular/router";
import { AccountService } from "../../Account.Service";
import { DataValidator } from "../../../../../Helper/DataValidator";
import IApplicationUser = App.Client.Account.IApplicationUser;

@Component({
    selector: 'signup-jobProvider',
    templateUrl: './././jobProvider.component.html',
    styleUrls: ['./././jobProvider.component.css']
})
export class SignUpJobProviderComponent {
    private readonly accountService: AccountService;
    private readonly dataValidator: DataValidator
    router: Router;
    applicationUser: IApplicationUser;

    constructor(router: Router, accountService: AccountService, dataValidator: DataValidator) {
        this.router = router;
        this.accountService = accountService;
        this.dataValidator = dataValidator;
        this.applicationUser = { Gender: 'M', IsCastingProfessional: true } as IApplicationUser;
    }
   

    save() {
        if (this.dataValidator.IsValidObject(this.applicationUser)) {
            this.accountService.signup(this.applicationUser).subscribe(
                result => {
                    if (result != undefined) {
                        this.router.navigate(["/interests"]);
                    }
                    else {
                        this.router.navigate(["/error"]);
                    }
                },
                error => {
                });
        }
    }
}
