// import {catchError, map} from 'rxjs/operators';
import {Injectable, Injector} from '@angular/core';
import {ManagerDTO} from '../models/manager.model';
import {HttpClient} from '@angular/common/http';
import {Observable} from 'rxjs';
import {catchError, map} from 'rxjs/operators';
import {ConfigurationService} from 'src/@custor/services/configuration.service';
import {EndpointFactory} from 'src/@custor/services/security/endpoint-factory.service';

@Injectable()
export class ManagerService extends EndpointFactory {
  constructor(private httpClient: HttpClient,
              private config: ConfigurationService,
              injector: Injector) {
    super(httpClient, config, injector);
  }

  private readonly _managersUrl: string = 'api/manager/GetManagerByCustomerId';
  private readonly _managerUrl: string = 'api/manager';
  get managersUrl() {return this.config.baseUrl + this._managersUrl; }
  get managerUrl() {return this.config.baseUrl + this._managerUrl; }

  // Declarations
  managerList: ManagerDTO[] = [];
  manager: ManagerDTO = new ManagerDTO();

  getManagers(customerId: number): Observable<any> {
    const endpointUrl = `${this.managersUrl}/${customerId}`;
    return this.httpClient.get<ManagerDTO[]>(endpointUrl, this.getRequestHeaders())
      .pipe(
        map(managerList => this.managerList = managerList)
        );
  }

  getManager(id): Observable<any> {
    console.log(this.managerUrl);
    const endpointUrl = `${this.managerUrl}/${id}`;
    return this.httpClient.get<ManagerDTO>(endpointUrl, this.getRequestHeaders()).pipe(
      map(cust => {
        this.manager = cust;
        return this.manager;
      }));
  }


  saveManager(manager: ManagerDTO): Observable<any> {
    return this.httpClient.post<ManagerDTO>(this.managerUrl, manager, this.getRequestHeaders())
      .pipe(
        map(mgr => {
          this.manager = mgr;
          return this.manager;
        }),
        catchError(error => {
          return this.handleError(error, () => this.saveManager(manager));
        })
      );
  }

  deleteManager(id): Observable<any> {
    const endpointUrl = `${this.managerUrl}/${id}`;
    return this.httpClient.delete<boolean>(endpointUrl, this.getRequestHeaders()).pipe(
      map(result => {
        // console.log(result);
        return result;
      }),
      catchError(err => Observable.throw(err || 'Server error')));
  }
}
