import { Injectable } from '@angular/core';
import { BusinessDTO } from '../models/bussiness.model';
import { BusinessesType } from '../mock-data/business';
import { Observable, of } from 'rxjs';
import { ConfigurationService } from 'src/@custor/services/configuration.service';


@Injectable({
    providedIn: 'root'
})
export class BusinessService {
    private lang:string;
    getBusinessBySelectedLanguage(currentLang: string): any {
        return of(BusinessesType);
    }
    constructor(private configService: ConfigurationService) {
        this.lang = this.configService.language;
     }


    getTypeOfBusiness(currentLang: string): Observable<BusinessDTO[]> {
        return of(BusinessesType);
        // const endpointUrl = `${this.businessTypeUrl}/${currentLang}`;
        // return this.httpClient.get<BusinessDTO[]>(endpointUrl, this.getRequestHeaders()).pipe(
        //     map(BusinessesType => this.BusinessesType = BusinessesType),
        //     catchError(err => throwError(err || 'Server error')));
    }
    saveBusiness(manager: BusinessDTO): Observable<BusinessDTO[]> {
        // return this.httpClient.post<BusinessDTO>(this.businessUrl, manager, this.getRequestHeaders())
        //     .pipe(
        //         map(business => {
        //             this.business = business;
        //             return this.business;
        //         }),
        //         catchError(error => {
        //             return this.handleError(error, () => this.saveBusiness(manager));
        //         })
        //     );
        return of(BusinessesType);
    }
    
}
