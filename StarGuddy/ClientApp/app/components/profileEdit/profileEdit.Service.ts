import { HttpErrorResponse, HttpParams } from "@angular/common/http";
import { Inject, Injectable } from "@angular/core";
import { Observable } from "rxjs/Observable";
import "rxjs/add/operator/map";
import { DataConverter } from "../../../Helper/DataConverter";
import { BaseService } from "../../../Services/BaseService";
import IUserCredits = App.Client.Profile.ICredits;
import IPhysicalAppearance = App.Client.Profile.IPhysicalAppearanceModal;
import IDancingModel = App.Client.Profile.IDancingModel;
import IDancingStyle = App.Client.Profile.IDancingStyleModel;
import IActingDetailModel = App.Client.Profile.IUserActingModel;
import IModelingDetailModel = App.Client.Profile.IUserModelingModel;
import IJobGroupModel = App.Client.Profile.IJobGroupModel;

@Injectable()
export class ProfileEditService {

    constructor(
        @Inject(BaseService) private readonly baseService: BaseService,
        private readonly dataConverter: DataConverter) {
    }

    //-------------Physical Appearance-------------------------------//
    GetUserPhysicalAppreance(): Observable<IPhysicalAppearance> {
        return this.baseService.HttpService.getData<IPhysicalAppearance>("Profile/Operations/PhysicalApperance")
            .map(
                (result: IPhysicalAppearance) => {
                    return result;
                },
                (err: HttpErrorResponse) => {
                    if (err.error instanceof Error) {
                        console.log("Client-side error occurred. Error:" + err.message);
                    } else {
                        console.log("Server-side error occurred. Error:" + err.message);
                    }
                });
    }

    SaveUserPhysicalAppreance(physicalAppearance: IPhysicalAppearance): Observable<boolean> {
        return this.baseService.HttpService.postData<IPhysicalAppearance>("Profile/Operations/SavePhysicalApperance", physicalAppearance)
            .map(
                (result: any) => {
                    return result;
                },
                (err: HttpErrorResponse) => {
                    if (err.error instanceof Error) {
                        console.log("Client-side error occurred. Error:" + err.message);
                    } else {
                        console.log("Server-side error occurred. Error:" + err.message);
                    }
                });
    }


    // --------------- User Credits ------------------------//
    GetUserCredits(): Observable<IUserCredits[]> {
        return this.baseService.HttpService.getData<IUserCredits[]>("Profile/Operations/Credit")
            .map(
                (result: IUserCredits[]) => {
                    return result;
                },
                (err: HttpErrorResponse) => {
                    if (err.error instanceof Error) {
                        console.log("Client-side error occurred. Error:" + err.message);
                    } else {
                        console.log("Server-side error occurred. Error:" + err.message);
                    }
                });
    }

    SaveUserCredits(credits: IUserCredits[]): Observable<boolean> {
        return this.baseService.HttpService.postData<boolean>("Profile/Operations/Credit", credits)
            .map(
                (result: any) => {
                    return result;
                },
                (err: HttpErrorResponse) => {
                    if (err.error instanceof Error) {
                        console.log("Client-side error occurred. Error:" + err.message);
                    } else {
                        console.log("Server-side error occurred. Error:" + err.message);
                    }
                });
    }

    DeleteUserCredits(id: string): Observable<boolean> {
        //let httpParams = new HttpParams();
        // httpParams.append("Id", id);

        return this.baseService.HttpService.deleteData<boolean>("Profile/Operations/Credit", new HttpParams().append("Id", id))
            .map(
                (result: any) => {
                    return result;
                },
                (err: HttpErrorResponse) => {
                    if (err.error instanceof Error) {
                        console.log("Client-side error occurred. Error:" + err.message);
                    } else {
                        console.log("Server-side error occurred. Error:" + err.message);
                    }
                });
    }


    // --------------- User Dancing ------------------------//
    GetUserDanceDetail(): Observable<IDancingModel> {
        return this.baseService.HttpService.getData<IDancingModel>("Profile/Operations/Dancing")
            .map(
                (result: IDancingModel) => {
                    return result;
                },
                (err: HttpErrorResponse) => {
                    if (err.error instanceof Error) {
                        console.log("Client-side error occurred. Error:" + err.message);
                    } else {
                        console.log("Server-side error occurred. Error:" + err.message);
                    }
                });
    }

    SaveUserDancingChanges(dancingModel: IDancingModel) {
        return this.baseService.HttpService.postData<boolean>("Profile/Operations/Dancing", dancingModel)
            .map(
                (result: any) => {
                    return result;
                },
                (err: HttpErrorResponse) => {
                    if (err.error instanceof Error) {
                        console.log("Client-side error occurred. Error:" + err.message);
                    } else {
                        console.log("Server-side error occurred. Error:" + err.message);
                    }
                });
    }


    // --------------- User Acting ------------------------//
    GetUserActingDetail(): Observable<IActingDetailModel> {
        return this.baseService.HttpService.getData<IActingDetailModel>("Profile/Operations/Acting")
            .map(
                (result: IActingDetailModel) => {
                    return result;
                },
                (err: HttpErrorResponse) => {
                    if (err.error instanceof Error) {
                        console.log("Client-side error occurred. Error:" + err.message);
                    } else {
                        console.log("Server-side error occurred. Error:" + err.message);
                    }
                });
    }

    SaveUserActingDetails(reqPayLoad: IActingDetailModel) {
        return this.baseService.HttpService.postData<boolean>("Profile/Operations/Acting", reqPayLoad)
            .map(
                (result: any) => {
                    return result;
                },
                (err: HttpErrorResponse) => {
                    if (err.error instanceof Error) {
                        console.log("Client-side error occurred. Error:" + err.message);
                    } else {
                        console.log("Server-side error occurred. Error:" + err.message);
                    }
                });
    }


    // --------------- User Modeling ------------------------//
    GetUserModelingDetail(): Observable<IModelingDetailModel> {
        return this.baseService.HttpService.getData<IModelingDetailModel>("Profile/Operations/Modeling")
            .map(
                (result: IModelingDetailModel) => {
                    return result;
                },
                (err: HttpErrorResponse) => {
                    if (err.error instanceof Error) {
                        console.log("Client-side error occurred. Error:" + err.message);
                    } else {
                        console.log("Server-side error occurred. Error:" + err.message);
                    }
                });
    }

    SaveUserModelingDetails(reqPayLoad: IModelingDetailModel) {
        return this.baseService.HttpService.postData<boolean>("Profile/Operations/Modeling", reqPayLoad)
            .map(
                (result: any) => {
                    return result;
                },
                (err: HttpErrorResponse) => {
                    if (err.error instanceof Error) {
                        console.log("Client-side error occurred. Error:" + err.message);
                    } else {
                        console.log("Server-side error occurred. Error:" + err.message);
                    }
                });
    }


    // --------------- User Interests ------------------------//
    GetUserInterestDetail(): Observable<IJobGroupModel[]> {
        return this.baseService.HttpService.getData<IJobGroupModel[]>("Profile/Interests")
            .map(
                (result: IJobGroupModel[]) => {
                    return result;
                },
                (err: HttpErrorResponse) => {
                    if (err.error instanceof Error) {
                        console.log("Client-side error occurred. Error:" + err.message);
                    } else {
                        console.log("Server-side error occurred. Error:" + err.message);
                    }
                });
    }

    SaveUserInterestDetail(requestData: IJobGroupModel[]): Observable<boolean> {
        return this.baseService.HttpService.postData<boolean>("Profile/Interests", requestData)
            .map(
                (result: any) => {
                    return result;
                },
                (err: HttpErrorResponse) => {
                    if (err.error instanceof Error) {
                        console.log("Client-side error occurred. Error:" + err.message);
                    } else {
                        console.log("Server-side error occurred. Error:" + err.message);
                    }
                });
    }
}