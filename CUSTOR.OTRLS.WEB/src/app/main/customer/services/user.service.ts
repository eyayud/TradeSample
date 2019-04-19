import { Injectable, Injector } from '@angular/core';
import { UserDTO } from '../models/user.model';
import { BusinessesType } from '../mock-data/business';
import { Observable, of } from 'rxjs';
import { ConfigurationService } from 'src/@custor/services/configuration.service';
import { HttpClient } from '@angular/common/http';
import { EndpointFactory } from 'src/@custor/services/security/endpoint-factory.service';
import { map, catchError } from 'rxjs/operators';
@Injectable({
    providedIn: 'root'
})
export class UserService extends EndpointFactory {
    private lang: string;
    user: UserDTO = new UserDTO();
    private readonly _userProfileUrl: string = 'api/manager/GetManagerByCustomerId';
    get userProfileUrl() { return this.config.baseUrl + this._userProfileUrl; }
    // constructor(private configService: ConfigurationService, private httpClient: HttpClient) {
    //     this.lang = this.configService.language;
    // }
    constructor(private httpClient: HttpClient,
        private config: ConfigurationService,
        injector: Injector) {
        super(httpClient, config, injector);
    }
    saveProfile(user : UserDTO){
        console.log(user);
        console.log(this.userProfileUrl);
        // return;
        return this.httpClient.post<UserDTO>(this.userProfileUrl, user, this.getRequestHeaders())
            .pipe(
                map(usr => {
                    this.user = usr;
                    return this.user;
                }),
                catchError(error => {
                    return this.handleError(error, () => this.saveProfile(user));
                })
            );
    }
}