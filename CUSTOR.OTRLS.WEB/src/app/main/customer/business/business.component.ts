import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl, FormBuilder, Validators } from '@angular/forms';
import { BusinessDTO } from '../models/bussiness.model';
import { BusinessService } from '../services/business.service';
import { AddressService } from '../../../common/services/address.service';
import { ConfigurationService } from 'src/@custor/services/configuration.service';
import { Region, Zone, Woreda, Kebele } from 'src/app/common/models/address.model';
import { ActivatedRoute, Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { AppTranslationService } from 'src/@custor/services/translation.service';
@Component({
  selector: 'app-business',
  templateUrl: './business.component.html',
  styleUrls: ['./business.component.scss']
})
export class BusinessComponent implements OnInit {

  title: string;

  addressForm: FormGroup;
  personalInfoForm: FormGroup;
  generalInfo: FormGroup;

  businessTypes: BusinessDTO[] = [];
  selectedBusiness: any = [];
  currentLang: string = 'am';
  regions: Region[] = [];
  zones: Zone[] = [];
  filteredZones: Zone[] = [];
  woredas: Woreda[] = [];
  filteredWoredas: Woreda[] = [];
  kebeles: Kebele[] = [];
  filteredKebeles: Kebele[] = [];
  AllowCascading = true;
  constructor(private fb: FormBuilder,
    private activatedRoute: ActivatedRoute,
    private router: Router,
    private toastr: ToastrService,
    private addressService: AddressService,
    private configService: ConfigurationService,
    private translationService: AppTranslationService,
    private businessService: BusinessService) {
    this.title = "Business"
    this.currentLang = this.configService.language;
    this.createForm();
  }
  ngOnInit() {
    this.getBusinessTypes();
    this.getRegions();
    this.getAllZones();
    this.getAllWoredas();
    this.getCountries();
  }

  // getFormControl(name: string) {
  //   return this.regForm.get(name);
  // }
  // isValid(name: string) {
  //   var e = this.getFormControl(name);
  //   return e && e.valid;
  // }
  // // returns TRUE if the FormControl has been changed
  // isChanged(name: string) {
  //   var e = this.getFormControl(name);
  //   return e && (e.dirty || e.touched);
  // }
  // // returns TRUE if the FormControl is invalid after user changes
  // hasError(name: string) {
  //   var e = this.getFormControl(name);
  //   return e && (e.dirty || e.touched) && !e.valid;
  // }
  
  getRegions() {
    this.addressService.getRegionsByLang(this.currentLang)
      .subscribe(result => {
        console.log(result);
        this.regions = result;
      },
        error => {
          return this.toastr.error(error);
        });
  }

  getAllZones() {
    this.addressService.getAllZonesByLang(this.currentLang)
      .subscribe(z => {
        this.zones = z;
        if (this.zones) {
          // console.log('Region ' + this.manager.RegionId);
          // this.filterRegion(this.manager.RegionId);
          this.filterRegion('');
        }
      },
        error => this.toastr.error(error));
  }

  getAllWoredas() {
    this.addressService.getAllWoredasByLang(this.currentLang)
      .subscribe(result => {
        this.woredas = result;
        // alert (result.length);
        if (this.woredas) {
          this.filterZone('');
        }
      },
        error => this.toastr.error(error));
  }
  getCountries() {
    console.log("test")
  }
  filterRegion(regionCode: string) {
    console.log(regionCode)
    if (!regionCode || !this.AllowCascading) {
      return;
    }
    this.filteredKebeles = null;
    this.filteredWoredas = null;
    if (!this.zones) {
      return;
    }
    this.filteredZones = this.zones.filter((item) => {
      return item.RegionId === regionCode;
    });
    // console.log(this.filteredZones)
  }

  filterZone(zoneCode: string) {
    if (!zoneCode || !this.AllowCascading) {
      return;
    }
    this.filteredKebeles = null;
    this.filteredWoredas = this.woredas.filter((item) => {
      return item.ZoneId === zoneCode;
    });
  }

  filterWoreda(woredaCode: string) {
    if (!woredaCode || !this.AllowCascading) {
      return;
    }
    this.getKebeleByWoredaId(woredaCode);
  }
  getKebeleByWoredaId(woredaId: any) {
    this.addressService.getKebelesByWoreda(this.configService.language, woredaId)
      .subscribe(result => {
        // this.kebeles = result;
        this.filteredKebeles = result;
        console.log(this.filteredKebeles)
      });
  }

  // valueChange(businessId, event) {
  //   this.selectedBusiness.push(businessId)
  //   console.log(this.selectedBusiness);
  //   console.log(event)

  // }
  addBusinessCategory(event, businessId,index){
    if (event.checked){
      this.selectedBusiness.push(businessId)
    }
    else {
      var removeIndex = this.selectedBusiness.indexOf(businessId)
      if (removeIndex !== -1)
        this.selectedBusiness.splice(removeIndex, 1);
    }
    console.log(this.selectedBusiness)
  }
  getBusinessTypes() {
    this.businessService.getBusinessBySelectedLanguage(this.currentLang).subscribe(result => {
      console.log(result);
      this.businessTypes = result;
    },
      error => {
        return this.toastr.error(error);
      });
  }
  createForm() {
    this.addressForm = this.fb.group({
      houseNumber: ['', [Validators.required]],
      KebeleId: [''],
      ZoneId: [''],
      WoredaId: [''],
      RegionId: [''],
      phoneNumber: [''],
      mobileNumber: [''],
      fax: [''],
      poBox: [''],
      email: [''],
      optionalAddress: [''],
    });
    this.personalInfoForm = this.fb.group({
      type: [''],
      noOfShares: [''],
      licenseRegNumber: [''],
      passPortNumber: [''],
    })
    this.generalInfo = this.fb.group({
      tinNumber: ['', [Validators.required, Validators.minLength(10), Validators.maxLength(10)]],
      paidCapital:['',Validators.required],
      assignedCapital: ['', Validators.required],
      totalNoOfShares:[''],
      shareValue:[''],
    })
  }
  saveAddress(){

  }
  savePersonalInfo(){

  }
  saveGeneralInfo(){

  }
}
