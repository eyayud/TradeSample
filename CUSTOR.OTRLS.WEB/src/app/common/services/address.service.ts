import { catchError, map } from 'rxjs/operators';
import { Injectable, OnInit, Injector } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Region, Zone, Woreda, Kebele } from '../models/address.model';
// import { NationalityModel } from '../models/nationality.model';
import { Observable, throwError } from 'rxjs';
import {ConfigurationService} from 'src/@custor/services/configuration.service';
import {EndpointFactory} from 'src/@custor/services/security/endpoint-factory.service';


@Injectable()
export class AddressService extends EndpointFactory implements OnInit {
  // private readonly _lookupsUrl: string = 'api/Lookups';
  private readonly _regionsUrl: string = 'api/Region';
  private readonly _zonesUrl: string = 'api/Zone';
  private readonly _woredasUrl: string = 'api/Woreda';
  private readonly _kebelesUrl: string = 'api/Kebele';
  // private readonly _natUrl: string = 'api/nationality';

  kebeleList: Kebele[];
  allKebeleList: Kebele[];
  woredaList: Woreda[];
  zoneList: Zone[];
  allZoneList: Zone[];
  allWoredaList: Woreda[];
  regList: Region[];
  // NationList: NationalityModel[];
  lang: string;

  constructor(private httpClient: HttpClient,
              private config: ConfigurationService,
              injector: Injector) {
   super(httpClient, config, injector);
  }

  ngOnInit(): void {
    // this.lang = 'et';
    this.lang = this.config.language;
  }

  getRegionsByLang(lang: string): Observable<any> {
    const endpointUrl = `${this.regionsUrl}/${lang}`;
    return this.httpClient.get<Region[]>(endpointUrl, this.getRequestHeaders()).pipe(
      map(regionList => this.regList = regionList),
      catchError(err => throwError(err || 'Server error')));
  }


  getAllZones(): Observable<Zone[]> {
    const endpointUrl = `${this.zonesUrl}`;
    return this.httpClient.get<Zone[]>(endpointUrl, this.getRequestHeaders()).pipe(
      map(zoneList => this.allZoneList = zoneList));
  }

  getAllZonesByLang(lang: string): Observable<Zone[]> {
    const endpointUrl = `${this.zonesUrl}/${lang}`;
    return this.httpClient.get<Zone[]>(endpointUrl, this.getRequestHeaders()).pipe(
      map(zoneList => this.allZoneList = zoneList));
  }
  getZones(id: string): Observable<Zone[]> {
    const endpointUrl = `${this.zonesUrl}/${this.lang}/${id}`;
    return this.httpClient.get<Zone[]>(endpointUrl, this.getRequestHeaders()).pipe(
      map(zoneList => this.zoneList = zoneList));

  }

  getWoredas(id: string): Observable<Woreda[]> {
    const endpointUrl = `${this.woredasUrl}/${this.lang}/${id}`;
    return this.httpClient.get<Woreda[]>(endpointUrl, this.getRequestHeaders()).pipe(
      map(woredaList => this.woredaList = woredaList));

  }

  getAllWoredasByLang(lang: string): Observable<Woreda[]> {
    const endpointUrl = `${this.woredasUrl}/${lang}`;
    return this.httpClient.get<Woreda[]>(endpointUrl, this.getRequestHeaders()).pipe(
      map(woredaList => this.allWoredaList = woredaList));
  }


  getKebeles(id: string): Observable<Kebele[]> {
    const endpointUrl = `${this.kebelesUrl}/${id}`;
    return this.httpClient.get<Kebele[]>(endpointUrl, this.getRequestHeaders()).pipe(
      map(kebeleList => this.kebeleList = kebeleList));

  }
  getAllKebelesByLang(lang: string): Observable<Kebele[]> {
    const endpointUrl = `${this.kebelesUrl}/${lang}`;
    return this.httpClient.get<Kebele[]>(endpointUrl, this.getRequestHeaders()).pipe(
      map(kebeleList => this.kebeleList = kebeleList));

  }

  getKebelesByWoreda(lang: string, id: string): Observable<Kebele[]> {
    const endpointUrl = `${this.kebelesUrl}/${lang}/${id}`;
    return this.httpClient.get<Kebele[]>(endpointUrl, this.getRequestHeaders()).pipe(
      map(kebeleList => this.kebeleList = kebeleList));

  }

  getAllKebeles(): Observable<Kebele[]> {
    const endpointUrl = `${this.kebelesUrl}/${this.lang}`;
    return this.httpClient.get<Kebele[]>(endpointUrl, this.getRequestHeaders()).pipe(
      map(kebeleList => this.allKebeleList = kebeleList));
  }

  // URLS
  get regionsUrl() {return this.config.baseUrl + this._regionsUrl; }
  get zonesUrl() {return this.config.baseUrl + this._zonesUrl; }
  get woredasUrl() {return this.config.baseUrl + this._woredasUrl; }
  get kebelesUrl() {return this.config.baseUrl + this._kebelesUrl; }
}
