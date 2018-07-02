import { Component, OnInit } from "@angular/core";
import { Router, ActivatedRoute } from "@angular/router";
import { UserProfileService } from "../../userProfile/UserProfile.Service";
import { DataValidator } from "../../../../Helper/DataValidator";
import { DbOperation } from "../../../../Constants/AppConstant";
import Profile = App.Client.Profile;
import ICredits = App.Client.Profile.ICredits;


@Component({
    selector: "user-profile-credits",
    templateUrl: "././credits.component.html",
    styleUrls: ['././credits.component.css']
})


export class CreditsComponent {

    private readonly dataValidator: DataValidator;
    private readonly dbOperation: DbOperation;
    private userProfileService: UserProfileService;

    public showEditHtml: boolean;
    public Credits: ICredits;
    public CreditsList: Array<ICredits> = [];

    get UniqueNumber() { return Math.random().toString(36).slice(2); }

    private readonly initCreditsClass = { Id: String.Empty, Action: String.Empty, WorkYear: "0", WorkPlace: String.Empty, WorkDetail: String.Empty } as ICredits;

    constructor(userProfileService: UserProfileService, dataValidator: DataValidator, dbOperation: DbOperation) {
        this.userProfileService = userProfileService;
        this.dataValidator = dataValidator;
        this.dbOperation = dbOperation;

        this.showEditHtml = false;
        this.Credits = Object.assign({}, this.initCreditsClass);
    }
    
    edit() {
        this.showEditHtml = !this.showEditHtml;
    }

    workYearChange($event: any) {
        var creditsObj = this.CreditsList.find(x => x.WorkYear == $event.target.value && x.Action != this.dbOperation.Delete);
        if (creditsObj != undefined) {
            this.Credits = Object.assign({}, creditsObj);

        }
    }

    addToCreditList() {
        let newCreditsObj = Object.assign({}, this.Credits);
        if (newCreditsObj != undefined && newCreditsObj.WorkYear != "0" && newCreditsObj.WorkPlace != String.Empty) {
            newCreditsObj.Action = newCreditsObj.Id == String.Empty ? this.dbOperation.Insert : this.dbOperation.Update;

            let index = this.CreditsList.findIndex(x => x.WorkYear == newCreditsObj.WorkYear);
            if (index > -1) {
                this.CreditsList[index] = Object.assign({}, newCreditsObj);
            }
            else {
                this.CreditsList.push(newCreditsObj);
            }

            // clear fields
            this.Credits = Object.assign({}, this.initCreditsClass);
        }        
    }

    editCreditList(selectedYear: string) {
        if (selectedYear != undefined && selectedYear != String.Empty) {
            let creditsObj = this.CreditsList.find(x => x.WorkYear == selectedYear);
            if (creditsObj != undefined) {
                this.Credits = Object.assign({}, creditsObj);
            }
        }

    }

    deleteCredits(selectedYear: string) {
        if (selectedYear != undefined && selectedYear != "") {

            let index = this.CreditsList.findIndex(x => x.WorkYear == selectedYear);
            if (index > -1) {
                let objForDelete = this.CreditsList.find(x => x.WorkYear == selectedYear);
                if (objForDelete != undefined && objForDelete.Id == String.Empty) {
                    this.CreditsList.splice(index, 1);
                }
                else {
                    this.CreditsList[index].Action = this.dbOperation.Delete;
                }
            }
        }
    }

    saveChanges() {

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
