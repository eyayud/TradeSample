import {Component, Input, OnInit, ViewChild} from '@angular/core';
import {ActivatedRoute, Router} from '@angular/router';
import {Subscription} from 'rxjs';

import {ALPHABET_WITHSPACE_REGEX, GENDERS, LEGAL_STATUSES} from '../../../common/constants/consts';
import {ToastrService} from 'ngx-toastr';
import {FormBuilder, FormControl, FormGroup, NgForm, Validators} from '@angular/forms';
import {ConfigurationService} from 'src/@custor/services/configuration.service';
import {Gender, LegalStatus, Lookup} from '../../../common/models/lookup.model';
import {LookUpService} from '../../../common/services/look-up.service';
import {AddressService} from '../../../common/services/address.service';

import {Utilities} from 'src/@custor/helpers/utilities';
import {ManagerDTO} from '../models/manager.model';
import {ManagerService} from '../services/manager.service';
import {AppTranslationService} from 'src/@custor/services/translation.service';

import {determineId} from 'src/@custor/helpers/compare';
import { Region, Zone, Woreda, Kebele } from 'src/app/common/models/address.model';

@Component({
  selector: 'app-manager',
  templateUrl: './manager.component.html',
  styleUrls: ['./manager.component.scss']
})
export class ManagerComponent implements OnInit {


  @ViewChild('form')

  managerSub: Subscription;
  private form: NgForm;
  title: string;
  isNewManager = false;
  manager: ManagerDTO;

  lookups: Lookup[] = [];
  regions: Region[] = [];
  zones: Zone[] = [];
  filteredZones: Zone[] = [];
  woredas: Woreda[] = [];
  filteredWoredas: Woreda[] = [];
  kebeles: Kebele[] = [];
  filteredKebeles: Kebele[] = [];

  managerForm: FormGroup;
  loadingIndicator: boolean;
  genders: Gender[] = [];
  legalStatuses: LegalStatus[] = [];
  currentLang = 'en';


  public titleList: Lookup[];
  public imageSrc: any;
  public countryList: Lookup[];
  public imgPhoto = '';
  public imgBase64 = '';
  public imgInput: string;
  managerId: number;
  customerId: number;
  AllowCascading = true;
  @Input() errors: string[] = [];


  constructor(private activatedRoute: ActivatedRoute,
              private router: Router,
              private lookUpService: LookUpService,
              private addressService: AddressService,
              private managerService: ManagerService,
              private configService: ConfigurationService,
              private translationService: AppTranslationService,
              private toastr: ToastrService,
              private fb: FormBuilder) {

   
    this.currentLang = this.configService.language;
     
    // create an empty object from the manager model
    this.manager = {} as ManagerDTO;
    // initialize the form
    this.initForm();
  }


  ngOnInit() {
    
    const id = this.activatedRoute.snapshot.params.id;

    this.initStaticData(this.currentLang);
    this.fillAddressLookups();
    this.imgBase64 = '';
    if (id < 1) {
      this.isNewManager = true;
      this.managerId = 0;
      this.title = 'Create a new manager';
      this.imgPhoto = '';
      return;
    }
    if (id) {
      this.isNewManager = false;
      this.getManager(id);
    }

  }


  getManager(id) {
    this.loadingIndicator = true;
    this.managerSub = this.managerService
      .getManager(id)
      .subscribe(result => {
          this.manager = result;
          if (result == null) {
            this.isNewManager = true;
          } else {
            this.isNewManager = false;
            this.updateForm();
            this.managerId = id;
            this.imgPhoto = this.configService.baseUrl + 'photo/Mgr' + this.manager.ManagerId + '.jpg'; // to-do put the path in config
          }

        },
        error => this.toastr.error(error));
    this.loadingIndicator = false;
  }


  fillAddressLookups() {
    const countryLookupType = 8;
    const titleLookupType = 89;
    // to-do
    // bring all in one go
    // caching
    this.getRegions();
    this.getAllZones();
    this.getAllWoredas();
    this.getTitles(titleLookupType);
    this.getCountries(countryLookupType);
  }

  private getCountries(id: any) {
    this.lookUpService.getLookupByParentId(this.currentLang, id).subscribe(result => {
      console.log(result);
      this.countryList = result;
      });
  }

  getTitles(id: any) {
    this.lookUpService.getLookupByParentId(this.currentLang, id).subscribe(result => {

      this.titleList = result;
    });

  }

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
            this.filterRegion(this.manager.RegionId);
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
            this.filterZone(this.manager.ZoneId);
          }
        },
        error => this.toastr.error(error));
  }

  // very expensive!
  getAllKebeles() {
    this.addressService.getAllKebelesByLang(this.currentLang)
      .subscribe(result => {
          this.kebeles = result;
          if (this.kebeles) {
            this.filterWoreda(this.manager.WoredaId);
          }
        },
        error => this.toastr.error(error));
  }

  initForm() {
    this.managerForm = this.fb.group({

      cFirstNameEng: ['', [Validators.compose([Validators.required, Validators.minLength(2),
        Validators.pattern(ALPHABET_WITHSPACE_REGEX)])]],
      cFatherNameEng: ['', [Validators.compose([Validators.required, Validators.minLength(2),
        Validators.pattern(ALPHABET_WITHSPACE_REGEX)])]],
      cGrandNameEng: [''],
      cFirstName: [''],
      cFatherName: [''],
      cGrandName: [''],
      cNationality: ['1'], // Ethiopian
      cGender: ['1'],
      Title: [''],
      Origin: [false],
      address: new FormGroup({
        ParentId: new FormControl(),
        RegionId: new FormControl(),
        ZoneId: new FormControl(),
        WoredaId: new FormControl(),
        KebeleId: new FormControl(),
        OtherAddress: new FormControl(),
        CellPhoneNo: new FormControl(),
        // SpecificAreaName: new FormControl(),
        HouseNo: new FormControl(),
        TeleNo: new FormControl(),
        Fax: new FormControl(),
        Pobox: new FormControl(),
        Email: new FormControl(),
        Remark: new FormControl()
      })

    });
  }

  updateForm() {

    this.managerForm.patchValue({
      cFirstName: this.manager.FirstName || '',
      cFatherName: this.manager.FatherName || '',
      cGrandName: this.manager.GrandName || '',
      cFirstNameEng: this.manager.FirstNameEng || '',
      cFatherNameEng: this.manager.FatherNameEng || '',
      cGrandNameEng: this.manager.GrandNameEng || '',
      cNationality: this.manager.Nationality == null ? '' : this.manager.Nationality.toString(),
      cGender: this.manager.Gender == null ? '' : this.manager.Gender.toString(),
      cTin: this.manager.Tin || '',
      cIsEthiopianOrigin: this.manager.Origin,
      Title: this.manager.Title || '',
    });

    this.AllowCascading = false;
    // Set dropdown values
    setTimeout(() => {
      if (this.manager.ZoneId != null) {
        this.filteredWoredas = this.woredas.filter((item) => item.ZoneId === this.manager.ZoneId);
      }
    }, 100);
    setTimeout(() => {
      if (this.manager.RegionId != null) {
        this.filteredZones = this.zones.filter((item) => item.RegionId === this.manager.RegionId);
      }
    }, 100);
    setTimeout(() => {
      if (this.manager.WoredaId != null) {
        this.getKebeleByWoredaId(this.manager.WoredaId);
      }
    }, 100);

    this.managerForm.get('address').patchValue({
      RegionId: this.manager.RegionId == null ? '' : this.manager.RegionId.toString(),
      ZoneId: this.manager.ZoneId == null ? '' : this.manager.ZoneId.toString(),
      WoredaId: this.manager.WoredaId == null ? '' : this.manager.WoredaId.toString(),
      KebeleId: this.manager.KebeleId == null ? '' : this.manager.KebeleId.toString(),
      HouseNo: this.manager.HouseNo || '',
      TeleNo: this.manager.TeleNo || '',
      Pobox: this.manager.Pobox || '',
      Fax: this.manager.Fax || '',
      CellPhoneNo: this.manager.CellPhoneNo || '',
      Email: this.manager.Email || '',
      OtherAddress: this.manager.OtherAddress || ''
    });
    this.isNewManager = false;
    this.imgBase64 = ''; // image file should not be recreated if not file is picked
    this.AllowCascading = true;
  }


  public onSubmit() {

    if (!this.managerForm.valid) {
      // // console.log('error!!');
      return;
    }
    // console.log(this.imgBase64);
    if (this.imgBase64 === '' && this.managerId === 0) {
      this.toastr.error('Please add photograph of the Manager');
      return;
    }
    this.loadingIndicator = true;
    console.log(this.getEditedManager());
    return this.managerService.saveManager(this.getEditedManager())
      .subscribe((manager: ManagerDTO) => {
          this.saveCompleted(manager);
         },
        err => this.handleError(err)
      );
  }

  private saveCompleted(manager?: ManagerDTO) {
    if (manager) {
      this.manager = manager;
    }
    this.isNewManager = false;
    this.loadingIndicator = false;
    this.toastr.success('Record saved successfully!');
    this.router.navigate(['/main/customer/manager-list']);
  }

  private handleError(error) {

    this.loadingIndicator = false;
    const errList = Utilities.getHttpResponseMessage(error);
    if (error.status === 400) { // bad request (validation)
      this.errors = errList;
      this.toastr.error('Please fix the listed errors', 'Error');
    } else {
      this.errors = [];
      this.toastr.error(error.status + ':' + errList[0].toString(), 'Error');
    }
  }

  private getEditedManager(): ManagerDTO {
    const formModel = this.managerForm.value;
    const add = this.managerForm.get('address').value;
    this.customerId = 1; // hard coded for now
    return {
      ManagerId: this.isNewManager ? 0 : this.manager.ManagerId,
      CustomerId: this.customerId,
      FirstName: formModel.cFirstName,
      FatherName: formModel.cFatherName,
      GrandName: formModel.cGrandName,
      FirstNameEng: formModel.cFirstNameEng,
      FatherNameEng: formModel.cFatherNameEng,
      GrandNameEng: formModel.cGrandNameEng,
      Nationality: formModel.cNationality,
      Gender: formModel.cGender,
      Origin: formModel.cIsEthiopianOrigin,
      IsActive: true,
      IsDeleted: false,
      Title: formModel.Title,
      PhotoData: this.imgBase64,
      RegionId: add.RegionId,
      ZoneId: add.ZoneId,
      WoredaId: add.WoredaId,
      KebeleId: add.KebeleId,
      HouseNo: add.HouseNo,
      TeleNo: add.TeleNo,
      Pobox: add.Pobox,
      Fax: add.Fax,
      CellPhoneNo: add.CellPhoneNo,
      Email: add.Email,
      OtherAddress: add.OtherAddress,
      AddressId: this.isNewManager ? 0 : this.manager.AddressId,
      UserName: 'Abebe'
    };
  }

  initStaticData(currentLang) {
    let gender: Gender = new Gender();
    GENDERS.forEach(pair => {
      gender = {Id: pair.Id.toString(), Desc: (currentLang === 'et' ? pair.Description : pair.DescriptionEnglish)};
      this.genders.push(gender);
      // console.log(pair);
    });
    let legalS: LegalStatus = new LegalStatus();
    LEGAL_STATUSES.forEach(pair => {
      legalS = {Id: pair.Id.toString(), Desc: (currentLang === 'et' ? pair.Description : pair.DescriptionEnglish)};
      this.legalStatuses.push(legalS);
    });

  }

  getKebeleByWoredaId(woredaId: any) {
    this.addressService.getKebelesByWoreda(this.configService.language, woredaId)
      .subscribe(result => {
        // this.kebeles = result;
        this.filteredKebeles = result;
      });
  }

  filterRegion(regionCode: string) {
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

  compareIds(id1: any, id2: any): boolean {
    const a1 = determineId(id1);
    const a2 = determineId(id2);
    return a1 === a2;
  }

  onBack() {
    this.router.navigate(['manager/list']);
  }

  get firstName() {
    return this.managerForm.get('cFirstName');
  }

  get fatherName() {
    return this.managerForm.get('cFatherName');
  }

  get Title() {
    return this.managerForm.get('Title');
  }

  get grandName() {
    return this.managerForm.get('cGrandName');
  }

  get firstNameEng() {
    return this.managerForm.get('cFirstNameEng');
  }

  get fatherNameEng() {
    return this.managerForm.get('cFatherNameEng');
  }

  get grandNameEng() {
    return this.managerForm.get('cGrandNameEng');
  }

  get nationality() {
    return this.managerForm.get('cNationality');
  }

  get gender() {
    return this.managerForm.get('cGender');
  }

  // get isDiaspora() {
  //   return this.managerForm.get('cIsDiaspora');
  // }

  get Origin() {
    return this.managerForm.get('cIsEthiopianOrigin');
  }

  get region() {
    return this.managerForm.get('RegionId');
  }

  get zone() {
    return this.managerForm.get('ZoneId');
  }

  get woreda() {
    return this.managerForm.get('WoredaId');
  }

  get kebele() {
    return this.managerForm.get('KebeleId');
  }

  get houseNumber() {
    return this.managerForm.get('HouseNo');
  }

  get phoneDirect() {
    return this.managerForm.get('PhoneDirect');
  }

  get CellPhoneNo() {
    return this.managerForm.get('CellPhoneNo');
  }

  get fax() {
    return this.managerForm.get('Fax');
  }

  get pobox() {
    return this.managerForm.get('POBox');
  }

  get legalStatus() {
    return this.managerForm.get('cLegalStatus');
  }

  get tradeName() {
    return this.managerForm.get('cTradeName');
  }

  get tradeNameEng() {
    return this.managerForm.get('cTradeNameEng');
  }

  get regDate() {
    return this.managerForm.get('cRegDate');
  }

  get regNumber() {
    return this.managerForm.get('cRegNumber');
  }

  get tin() {
    return this.managerForm.get('cTin');
  }

  get otherAddress() {
    return this.managerForm.get('OtherAddress');
  }

  get companyName() {
    return this.managerForm.get('cCompanyName');
  }

  get companyNameEng() {
    return this.managerForm.get('cCompanyNameEng');
  }

  get nationalityCompany() {
    return this.managerForm.get('cNationalityCompany');
  }

  get email() {
    return this.managerForm.get('Email');
  }

  get houseNo() {
    return this.managerForm.get('HouseNo');
  }

  // another getter for easy access to form fields
  get ct() {
    return this.managerForm.controls;
  }

  // use it as 'ct.controlName.errors.required'

  get floatLabels(): string {
    return 'auto';
  }

// Photo Management
  ngAfterViewInit(): void {
    // this.fillAddressLookups();
  }

  fileChange(input) {
    const pattern = /image-*/;
    if (!input.files[0].type.match(pattern)) {
      this.toastr.error('The selected file is not valid image file');
      return;
    }
    const reader = new FileReader();
    this.readFile(input.files[0], reader, (result) => {
      // Create an img element and add the image file data to it
      const img = document.createElement('img');
      img.src = result;
      this.resizeImage(img, 150, 150, (resizedImage) => {
        this.imgPhoto = resizedImage;
      });
    });
  }

  readFile(file, reader, callback) {
    reader.onload = () => {
      callback(reader.result);
    };
    reader.readAsDataURL(file);
  }

  resizeImage(img, maxWidth: number, maxHeight: number, callback) {
    return img.onload = () => {
      let width = img.width;
      let height = img.height;
      // Maintain aspect ratio
      if (width > height) {
        if (width > maxWidth) {
          height *= maxWidth / width;
          width = maxWidth;
        }
      } else {
        if (height > maxHeight) {
          width *= maxHeight / height;
          height = maxHeight;
        }
      }
      // create a canvas object
      const canvas = document.createElement('canvas');
      canvas.width = width;
      canvas.height = height;
      const ctx = canvas.getContext('2d');
      ctx.drawImage(img, 0, 0, width, height);
      const dataUrl = canvas.toDataURL('image/jpeg');
      // // console.log(dataUrl);
      this.imgBase64 = dataUrl.split(',')[1];
      callback(dataUrl, img.src.length, dataUrl.length);
    };
  }
}
