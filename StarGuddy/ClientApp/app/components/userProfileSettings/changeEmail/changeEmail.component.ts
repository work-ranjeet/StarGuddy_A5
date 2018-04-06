import { Component } from "@angular/core";
import { Router, ActivatedRoute } from "@angular/router";
import { UserProfileSettingsService } from "../../userProfileSettings/userProfileSettings.Service";
import { DataValidator } from "../../../../Helper/DataValidator";
import IUserEmail = App.Client.Profile.Setting.IUserEmail;

@Component({
    selector: "account-management-change-email",
    templateUrl: "././changeEmail.component.html",
    styleUrls: ['././changeEmail.component.css']
})

export class ChangeEmailComponent {
    userEmail: IUserEmail;
    profileSettingService: UserProfileSettingsService;
    router: Router;
    returnUrl: string;
    authenticateRoute: ActivatedRoute;

    private readonly dataValidator: DataValidator

    constructor(router: Router, authRoute: ActivatedRoute, profileSettingService: UserProfileSettingsService, dataValidator: DataValidator) {
        this.router = router;
        this.authenticateRoute = authRoute;
        this.profileSettingService = profileSettingService;
        this.dataValidator = dataValidator;
    }

    ngOnInit() {
        this.userEmail = {} as IUserEmail;

        // get return url from route parameters or default to '/'
        this.returnUrl = this.authenticateRoute.snapshot.queryParams["returnUrl"] || "/";
    }

    updateEmail() {
        if (this.dataValidator.IsValidObject(this.userEmail)) {
            this.profileSettingService.updateEmail(this.userEmail).subscribe(
                result => {

                },
                error => {
                    console.error(error);
                });
        }
    }
}
