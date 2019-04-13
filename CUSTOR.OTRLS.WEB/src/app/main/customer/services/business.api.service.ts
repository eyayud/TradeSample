// import {catchError, map} from 'rxjs/operators';
import {Injectable, Injector} from '@angular/core';
import {ManagerDTO} from '../models/manager.model';
import {HttpClient} from '@angular/common/http';
import {Observable} from 'rxjs';
import {catchError, map} from 'rxjs/operators';
import {ConfigurationService} from 'src/@custor/services/configuration.service';
import {EndpointFactory} from 'src/@custor/services/security/endpoint-factory.service';
import { AngularWaitBarrier } from 'blocking-proxy/built/lib/angular_wait_barrier';

@Injectable()
export class BusinessApiService extends EndpointFactory {
  constructor(private httpClient: HttpClient,
              private config: ConfigurationService,
              injector: Injector) {
    super(httpClient, config, injector);
  }

  sectorsList:any;
  subSectorsList:any;
  sectionsList:any;
  subSectionsList:any;
  application:any;

  private readonly _sectorsUrl: string = 'api/sectors';
  private readonly _subSectorsUrl: string = 'api/sectors/getBySectorId';
  private readonly _sectiosnUrl: string = 'api/sectors/getSectionBySubsectorId';
  private readonly _subSectionsUrl: string = 'api/sectors/getSubSectionBySectionId';
  private readonly _applicatonUrl:string = 'api/business/application'
 
  get sectoresUrl() {return this.config.baseUrl + this._sectorsUrl; }
  get subSectoresUrl() {return this.config.baseUrl + this._subSectionsUrl; }
  get sectionsUrl() {return this.config.baseUrl + this._sectiosnUrl; }
  get subSectionsUrl() {return this.config.baseUrl + this._subSectionsUrl; }
  get applicationUrl(){return this.config.baseUrl + this._applicatonUrl}
 

  

  getSectors(): Observable<any> {
    const endpointUrl = `${this.sectoresUrl}`;
    return this.httpClient.get(endpointUrl, this.getRequestHeaders())
      .pipe(
        map(sectorsList => this.sectorsList = sectorsList)
        );
  }

  //get subsectores by sector Id

  getSubSectors(id): Observable<any> {
    
    const endpointUrl = `${this.subSectoresUrl}/${id}`;
    return this.httpClient.get(endpointUrl, this.getRequestHeaders()).pipe(
      map(subSectors => {
        this.subSectorsList = subSectors;
        return this.subSectorsList;
      }));
  }


  //get sections by subsector Id

  getSectionList(id): Observable<any> {
    
    const endpointUrl = `${this.sectionsUrl}/${id}`;
    return this.httpClient.get(endpointUrl, this.getRequestHeaders()).pipe(
      map(sections => {
        this.sectionsList = sections;
        return this.sectionsList;
      }));
  }


  //get sub sections by section Id

  getSubSectorList(id): Observable<any> {
    
    const endpointUrl = `${this.sectionsUrl}/${id}`;
    return this.httpClient.get(endpointUrl, this.getRequestHeaders()).pipe(
      map(subSections => {
        this.subSectionsList = subSections;
        return this.subSectionsList;
      }));
  }


  saveApplication(application): Observable<any> {
    return this.httpClient.post(this.applicationUrl, application, this.getRequestHeaders())
      .pipe(
        map(app => {
          this.application = app;
          return this.application;
        }),
        catchError(error => {
          return this.handleError(error, () => this.saveApplication(application));
        })
      );
  }

 
}
