// import {catchError, map} from 'rxjs/operators';
import {Injectable, Injector} from '@angular/core';
import {ManagerDTO} from '../models/manager.model';
import {HttpClient} from '@angular/common/http';
import {Observable} from 'rxjs';
import {catchError, map} from 'rxjs/operators';
import {ConfigurationService} from 'src/@custor/services/configuration.service';
import {EndpointFactory} from 'src/@custor/services/security/endpoint-factory.service';
import {AngularWaitBarrier} from 'blocking-proxy/built/lib/angular_wait_barrier';

@Injectable()
export class BusinessApiService extends EndpointFactory {

  sectorsList: any;
  subSectorsList: any;
  sectionsList: any;
  subSectionsList: any;
  application: any;

  private readonly sectorsUrl: string = 'api/sectors';
  private readonly subSectorsUrl: string = 'api/sectors/getBySectorId';
  private readonly sectionsUrl: string = 'api/sectors/getSectionBySubsectorId';
  private readonly subSectionsUrl: string = 'api/sectors/getSubSectionBySectionId';
  private readonly applicationUrl: string = 'api/business/application';

  constructor(private httpClient: HttpClient,
              private config: ConfigurationService,
              injector: Injector) {
    super(httpClient, config, injector);
  }

  // TODO: get real sectors data form api
  // get dummy sectors from json file for now

  getJSON(): Observable<any> {
    return this.httpClient.get('./assets/dummySectors.json');
  }


  get getSectoresUrl() {
    return this.config.baseUrl + this.sectorsUrl;
  }

  get getSubSectoresUrl() {
    return this.config.baseUrl + this.subSectionsUrl;
  }

  get getSectionsUrl() {
    return this.config.baseUrl + this.sectionsUrl;
  }

  get getSubSectionsUrl() {
    return this.config.baseUrl + this.subSectionsUrl;
  }

  get getapplicationUrl() {
    return this.config.baseUrl + this.applicationUrl;
  }


  getSectors(): Observable<any> {
    const endpointUrl = `${this.getSectoresUrl}`;
    return this.httpClient.get(endpointUrl, this.getRequestHeaders())
      .pipe(
        map(sectorsList => this.sectorsList = sectorsList)
      );
  }

  // get subsectores by sector Id

  getSubSectors(id): Observable<any> {

    const endpointUrl = `${this.getSubSectoresUrl}/${id}`;
    return this.httpClient.get(endpointUrl, this.getRequestHeaders()).pipe(
      map(subSectors => {
        this.subSectorsList = subSectors;
        return this.subSectorsList;
      }));
  }


  // get sections by subsector Id

  getSectionList(id): Observable<any> {

    const endpointUrl = `${this.getSectionsUrl}/${id}`;
    return this.httpClient.get(endpointUrl, this.getRequestHeaders()).pipe(
      map(sections => {
        this.sectionsList = sections;
        return this.sectionsList;
      }));
  }


  // get sub sections by section Id

  getSubSections(id): Observable<any> {

    const endpointUrl = `${this.getSubSectionsUrl

      }/${id}`;
    return this.httpClient.get(endpointUrl, this.getRequestHeaders()).pipe(
      map(subSections => {
        this.subSectionsList = subSections;
        return this.subSectionsList;
      }));
  }


  saveApplication(application): Observable<any> {
    return this.httpClient.post(this.getapplicationUrl, application, this.getRequestHeaders())
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
