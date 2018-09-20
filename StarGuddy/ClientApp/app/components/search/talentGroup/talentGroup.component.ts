import { Component } from "@angular/core";
import { SearchService } from "../../search/search.Service";
import { ProfileIndexAbstract } from "../../../comBase/profileIndexAbstract";
import * as _ from "lodash";
import { ActivatedRoute } from "@angular/router";
import ITalentGroupModel = App.Client.Search.ITalentGroupModel;


@Component({
    selector: "search-talent-group",
    templateUrl: "././talentGroup.component.html",
    styleUrls: ['././talentGroup.component.css']
})


export class SearchTalentGroupComponent {
    public talentGroupList: Array<ITalentGroupModel> = [];

    constructor(
        private readonly activatedRoute: ActivatedRoute,
        private readonly searchService: SearchService) {  }

    ngOnInit() {      
        this.loadTalentMainGroup();  
    }

    loadTalentMainGroup() {
        this.searchService.GetTalentGroupDetail().subscribe(response => {
            if (response != null) {
                this.talentGroupList = _.cloneDeep(response);
            }
            else {
                console.info("Got empty result: SearchTalentGroupComponent.GetTalentGroupDetail()");
            }
        });
    }
}

