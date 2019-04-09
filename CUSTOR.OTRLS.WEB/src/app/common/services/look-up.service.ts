import {Injectable, Injector} from '@angular/core';
import {Lookup} from '../models/lookup.model';
import {HttpClient} from '@angular/common/http';
import {catchError, map} from 'rxjs/operators';
import {Observable} from 'rxjs';
import { ConfigurationService } from 'src/@custor/services/configuration.service';
import { EndpointFactory } from 'src/@custor/services/security/endpoint-factory.service';

@Injectable()
export class LookUpService extends EndpointFactory  {
  private readonly _lookupsUrl: string = 'api/Lookups';
  private readonly _lookupByParentUrl: string = 'api/Lookup';

  constructor(private httpClient: HttpClient,
              private config: ConfigurationService,
              injector: Injector) {
      super(httpClient, config, injector);
}

get lookupsUrl() {return this.config.baseUrl + this._lookupsUrl; }
get lookupByParentUrl() {return this.config.baseUrl + this._lookupByParentUrl; }

getLookup(lang: string): Observable<Lookup[]> {
  const endpointUrl = `${this.lookupsUrl}/${lang}`;
  return this.httpClient.get<Lookup[]>(endpointUrl, this.getRequestHeaders()).pipe(
    map(result => result)
  );
}

getLookupByParentId(lang: string, id: string): Observable<Lookup[]> {
    const endpointUrl = `${this.lookupByParentUrl}/${lang}/${id}`;
    return this.httpClient.get<Lookup[]>(endpointUrl, this.getRequestHeaders()).pipe(
      map(result => {
        return result;
      }));
}
}
