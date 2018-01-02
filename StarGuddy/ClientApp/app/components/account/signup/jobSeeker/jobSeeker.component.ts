import { Component } from "@angular/core";
import { AccountService } from "../../Account.Service";
import IApplicationUser = App.Client.Account.IApplicationUser;

@Component({
    selector: "signup-jobSeeker",
    templateUrl: "./././jobSeeker.component.html",
    styleUrls: ["./././jobSeeker.component.css"]
})

export class SignUpJobSeekerComponent {
  
    private readonly accountService: AccountService;

    applicationUser: IApplicationUser;

    constructor(accountService: AccountService) { this.accountService = accountService; }

    ngOnInit() {
        this.applicationUser = {} as IApplicationUser;
    }

}
