import { Injectable, Injector } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { RegisterDTO } from '../models/register.model';
@Injectable({
    providedIn: 'root'
})
export class RegistrationService {
    registrationInfo : RegisterDTO = [];
    baseUrl :string = "";
    constructor(private httpClient: HttpClient,
                 injector: Injector,
               ) { }

    getRegistrationInfo(userId : number){
        var url = this.baseUrl + "api/quiz/";
        this.httpClient.get<RegisterDTO>(url).subscribe(result => {
            this.registrationInfo = result;
        }, error => console.error(error));
    }

    saveRegistrationInfo(registrationInfo : RegisterDTO){
        var url = this.baseUrl + "api/quiz/";
        this.httpClient.put<RegisterDTO>(url, registrationInfo).subscribe(res => {
            var v = res;
        }, error => console.error(error));
    }
    updateRegistrationInfo(registrationInfo: RegisterDTO){
        var url = this.baseUrl + "api/quiz/";
        this.httpClient.post<RegisterDTO>(url, registrationInfo).subscribe(res => {
            var v = res;
        }, error => console.error(error));
    }
}