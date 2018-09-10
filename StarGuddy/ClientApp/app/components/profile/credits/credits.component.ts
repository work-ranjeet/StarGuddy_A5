import { Component } from "@angular/core";
import { ProfileService } from "../../profile/profile.Service";
import ICredits = App.Client.Profile.ICredits;


@Component({
    selector: "profile-credits",
    templateUrl: "././credits.component.html"
})


export class ProfileCreditsComponent {

    private subscription: any;
    private hasCredits: boolean = false;
    private CreditsList: Array<ICredits> = [];

    constructor(private readonly profileService: ProfileService) { }

    ngOnInit() {
      
    }

    ngOnDestroy() {
        
    }

    loadCredits(creditsList: Array<ICredits>) {
        try {
            if (creditsList != undefined && creditsList.length > 0) {
                this.CreditsList = creditsList;
            }
            else {
                console.info("Got empty result: ProfileCreditsComponent.loadCredits()");
            }
        }
        catch (ex) {
            console.error("Got error ProfileCreditsComponent.loadCredits() : " + ex);
        }
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
