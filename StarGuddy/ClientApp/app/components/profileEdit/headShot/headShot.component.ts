import { Component, Input } from '@angular/core';
import { ProfileEditService } from "../../profileEdit/profileEdit.Service";
import * as _ from 'lodash';
import { Router, ActivatedRoute } from '@angular/router';
import IHeadShot = App.Client.Profile.IImageModel;
import { HttpEventType, HttpEvent } from '@angular/common/http';


/** @title Simple form field */
@Component({
    selector: "profile-head-shot",
    templateUrl: "././headShot.component.html",
    styleUrls: ['././headShot.component.css']
})
export class ProfileHeadShotComponent {
    private _gender: string = "";

    //private imageUrl: string = "/css/icons/mail.png";
    //private fileToUpload: File = {} as File;
    private fileReader: FileReader = new FileReader();
    private headShotModel: IHeadShot = {} as IHeadShot;


    public progress: number = 0;
    public message: string = "";


    @Input()
    set Gender(gender: string) { this._gender = gender; }
    get Gender(): string { return this._gender; }

    constructor(
        private readonly router: Router,
        private readonly activatedRoute: ActivatedRoute,
        private readonly profileService: ProfileEditService) { }

    ngOnInit() {
        this.activatedRoute.params.subscribe(param => this.Gender = param['gender']);
        this.fileReader.onload = (event: any) => {
            this.headShotModel.imageUrl = event.target.result;
        };
    }

    handleFileInput(files: FileList) {
        var file = files.item(0);
        if (file != null) {
            this.headShotModel.fileToUpload = file;
            this.headShotModel.name = file.name;
            this.headShotModel.size = file.size;
            this.fileReader.readAsDataURL(this.headShotModel.fileToUpload);
        }
    }

    load() {
        this.profileService.GetUserDetail().subscribe(response => {
            if (response != null) {

            }
            else {
                console.info("Got empty result: ProfileHeadShotComponent.load()");
            }
        });
    }

    uploadImage() {
        //const formData: FormData = new FormData
        //formData.append('Image', this.headShotModel.fileToUpload, this.headShotModel.fileToUpload.name);
        //formData.append('ImageCaption', this.headShotModel.caption);

        //this.http.request(new HttpRequest('POST', "api/Profile/Image/UploadImage", formData, { reportProgress: true })).subscribe((event: any) => {


        //    if (event.type === HttpEventType.UploadProgress)
        //        this.progress = Math.round(100 * event.loaded / event.total);
        //    else if (event.type === HttpEventType.Response)
        //        this.message = event.body.toString();
        //});
     

        this.profileService.UploadHeadShotImage(this.headShotModel).subscribe((event: any) => {
            if (event.type === HttpEventType.UploadProgress)
                this.progress = Math.round(100 * event.loaded / event.total);
            else if (event.type === HttpEventType.Response)
                this.message = event.body.toString();
        });
    }
}