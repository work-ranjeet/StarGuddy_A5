import { Component, OnInit } from "@angular/core";
import { Router, ActivatedRoute } from "@angular/router";
import { UserProfileService } from "../../userProfile/UserProfile.Service";
import { DataValidator } from "../../../../Helper/DataValidator";
import { DbOperation } from "../../../../Constants/AppConstant";
import ICredits = App.Client.Profile.ICredits;
import { Form, NgForm } from "@angular/forms";


@Component({
    selector: "user-profile-credits",
    templateUrl: "././credits.component.html",
    styleUrls: ['././credits.component.css']
})


export class CreditsComponent {

    private readonly dataValidator: DataValidator;
    private readonly dbOperation: DbOperation;
    private userProfileService: UserProfileService;

    public showEditHtml: boolean = false;
    public hasCredits: boolean = false;
    public enableSaveButton: boolean = false;
    public Credits: ICredits;
    public CreditsList: Array<ICredits> = [];

    get UniqueNumber() { return Math.random().toString(36).slice(2); }

    private readonly initCreditsClass = { id: String.Empty, action: String.Empty, workYear: "0", workPlace: String.Empty, workDetail: String.Empty } as ICredits;

    constructor(userProfileService: UserProfileService, dataValidator: DataValidator, dbOperation: DbOperation) {
        this.userProfileService = userProfileService;
        this.dataValidator = dataValidator;
        this.dbOperation = dbOperation;
        this.Credits = Object.assign({}, this.initCreditsClass);
    }

    ngOnInit() {
        this.loadCredits();
    }

    edit() {
        this.showEditHtml = !this.showEditHtml;
        if (this.showEditHtml)// && (!this.CreditsList != undefined && this.CreditsList.length > 0)) 
        {
            this.loadCredits();
        }
    }

    workYearChange($event: any) {
        var creditsObj = this.CreditsList.find(x => x.workYear == $event.target.value && x.action != this.dbOperation.Delete);
        if (creditsObj != undefined) {
            this.Credits = Object.assign({}, creditsObj);

        }
    }

    addToCreditList(frmEdit: NgForm) {
        let newCreditsObj = Object.assign({}, this.Credits);
        if (newCreditsObj != undefined && newCreditsObj.workYear != "0" && newCreditsObj.workPlace != String.Empty) {
            newCreditsObj.action = newCreditsObj.id == String.Empty ? this.dbOperation.Insert : this.dbOperation.Update;

            let index = this.CreditsList.findIndex(x => x.workYear == newCreditsObj.workYear);
            if (index > -1) {
                this.CreditsList[index] = Object.assign({}, newCreditsObj);
            }
            else {
                this.CreditsList.push(newCreditsObj);
            }

            // clear fields
            this.Credits = Object.assign({}, this.initCreditsClass);

            if (frmEdit != undefined) {
                frmEdit.reset();
                frmEdit.control.markAsPristine();
            }

            this.enableSaveButton = this.isCreditsDirty();
            this.hasCredits = this.CreditsList != undefined && this.CreditsList.length > 0;
        }
    }

    editCreditList(selectedYear: string) {
        if (selectedYear != undefined && selectedYear != String.Empty) {
            let creditsObj = this.CreditsList.find(x => x.workYear == selectedYear);
            if (creditsObj != undefined) {
                this.Credits = Object.assign({}, creditsObj);
            }
        }

        this.hasCredits = this.isCreditsDirty();
    }

    deleteCredits(selectedYear: string) {

        var actionResult = confirm("Do you want to delete this entry?")
        if (actionResult && selectedYear != undefined && selectedYear != ";") {

            let index = this.CreditsList.findIndex(x => x.workYear == selectedYear);
            if (index > -1) {
                let objForDelete = <ICredits>this.CreditsList.find(x => x.workYear == selectedYear);
                if (objForDelete != undefined && objForDelete.id == String.Empty) {
                    this.CreditsList.splice(index, 1);
                    return;
                }

                this.userProfileService.DeleteUserCredits(objForDelete.id).subscribe(response => {
                    if (response != null && response) {
                        this.CreditsList.splice(index, 1);
                    }
                    else {
                        console.info("Error");
                    }

                    this.hasCredits = this.CreditsList != undefined && this.CreditsList.length > 0;
                });
            }
        }
    }

    loadCredits() {
        this.userProfileService.GetUserCredits().subscribe(response => {
            if (response != null && response.length > 0) {
                this.CreditsList = response;
            }
            else {
                console.info("Got empty result:" + response.toString());
            }
        });

        this.hasCredits = this.CreditsList != undefined && this.CreditsList.length > 0;
    }

    saveChanges() {
        let editedCredits = this.CreditsList.filter(x => x.id == String.Empty || x.action == this.dbOperation.Insert || x.action == this.dbOperation.Update || x.action == this.dbOperation.Delete);
        if (editedCredits != undefined && editedCredits.length > 0) {
            this.userProfileService.SaveUserCredits(editedCredits).subscribe(response => {
                if (response != null && response) {
                    console.info("Updated");
                }

                this.showEditHtml = false;
            });
        }
    }

    isCreditsDirty(): boolean {
        let editedCredits = this.CreditsList.filter(x => x.id == String.Empty ||
            x.action == this.dbOperation.Insert || x.action == this.dbOperation.Update || x.action == this.dbOperation.Delete);

        return editedCredits != undefined && editedCredits.length > 0;
    }

    public workYearJson = [
        { key: "2016", value: "2016" },
        { key: "2015", value: "2015" },
        { key: "2014", value: "2014" },
        { key: "2013", value: "2013" },
        { key: "2012", value: "2012" },
        { key: "2011", value: "2011" },
        { key: "2010", value: "2010" },
        { key: "2009", value: "2009" },
        { key: "2008", value: "2008" },
        { key: "2007", value: "2007" },
        { key: "2006", value: "2006" },
        { key: "2005", value: "2005" },
        { key: "2004", value: "2004" },
        { key: "2003", value: "2003" },
        { key: "2002", value: "2002" },
        { key: "2001", value: "2001" },
        { key: "2000", value: "2000" },
        { key: "1999", value: "1999" },
        { key: "1998", value: "1998" },
        { key: "1997", value: "1997" },
        { key: "1996", value: "1996" },
        { key: "1995", value: "1995" },
        { key: "1994", value: "1994" },
        { key: "1993", value: "1993" },
        { key: "1992", value: "1992" },
        { key: "1991", value: "1991" },
        { key: "1990", value: "1990" },
        { key: "1989", value: "1989" },
        { key: "1988", value: "1988" },
        { key: "1987", value: "1987" },
        { key: "1986", value: "1986" },
        { key: "1985", value: "1985" },
        { key: "1984", value: "1984" },
        { key: "1983", value: "1983" }
    ];
}
