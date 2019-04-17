import {Component, OnInit} from '@angular/core';
import {AppTranslationService} from 'src/@custor/services/translation.service';
import {FormBuilder, FormGroup, Validators} from '@angular/forms';
import {BusinessApiService} from '../services/business.api.service';
import {ALPHABET_WITHSPACE_REGEX, ET_ALPHABET_WITHSPACE_REGEX, NUMERIC_WITHPERIOD_REGEX} from '../../../common/constants/consts';
import {ProgressBarService} from '../../../../@custor/components/progress-bar/service/progress-bar.service';
import {ManagerDTO} from '../models/manager.model';
import {ManagerService} from '../services/manager.service';
import {ToastrService} from 'ngx-toastr';
import {el} from '@angular/platform-browser/testing/src/browser_util';


@Component({
  selector: 'app-business-create',
  templateUrl: './business-create.component.html',
  styleUrls: ['./business-create.component.scss']
})

export class BusinessCreateComponent implements OnInit {

  // declare variable for dummy sectors
  dummySectorsData: any;
  sectorsList: any;
  subSectorsList = [];
  sectionsList = [];
  subSectionsList = [];
  classificationLenses = [];
  selectedClassificationLenses = [];

  licenseRegistrationForm: FormGroup;
  // declare manger for getting default company name
  manager: ManagerDTO;

  constructor(
    private translationService: AppTranslationService,
    private formBuilder: FormBuilder,
    private apiService: BusinessApiService,
    private managerService: ManagerService,
    private progressBarService: ProgressBarService,
    private toasterSevice: ToastrService
  ) {
    this.translationService.changeLanguage('et');

    // build the form
    this.initForm();

    // get manager by id
    // TODO: get id from local storage for now we are using hard coded Id
    this.getManager('1');

    // get list of sectors
    this.getSectors();

  }


  ngOnInit() {
  }

  initForm() {
    this.licenseRegistrationForm = this.formBuilder.group({
      companyNameAmharic: ['', [Validators.required, Validators.minLength(3), Validators.pattern(ET_ALPHABET_WITHSPACE_REGEX)]],
      companyNameEnglish: ['', [Validators.required, Validators.minLength(3), Validators.pattern(ALPHABET_WITHSPACE_REGEX)]],
      companyNameRegional: ['', [Validators.required, Validators.minLength(3)]],
      signedCapital: ['', [Validators.required, Validators.minLength(2), Validators.pattern(NUMERIC_WITHPERIOD_REGEX)]],
      sector: ['', Validators.required],
      subSectors: ['', Validators.required],
      sections: ['', Validators.required],
      subSections: ['', Validators.required],
      classificationLens: ['', Validators.required]
    });
  }

  getManager(id) {
    this.progressBarService.triggerProgressBar(true);
    this.managerService
      .getManager(id)
      .subscribe(res => {
          this.manager = res;
          console.log(res);
          // patch form controls related with company default values
          this.updateCompanyNameFormControls();
          this.progressBarService.triggerProgressBar(false);
        },
        error => {
          this.toasterSevice.error(error);
          this.progressBarService.triggerProgressBar(false);
        });


  }

  updateCompanyNameFormControls() {
    // concatenate and assign first name and last name
    const fullAmharicName = this.manager.FirstName + ' ' + this.manager.FatherName;
    const fullEnglishName = this.manager.FirstNameEng + ' ' + this.manager.FatherNameEng;

    this.licenseRegistrationForm.patchValue({companyNameAmharic: fullAmharicName});
    this.licenseRegistrationForm.patchValue({companyNameEnglish: fullEnglishName});
  }

  // setter methods for license registration form controllers


  // getter methods for license registration form controllers

  get companyNameAmharic() {
    return this.licenseRegistrationForm.get('companyNameAmharic');
  }

  get companyNameEnglish() {
    return this.licenseRegistrationForm.get('companyNameEnglish');
  }

  get companyNameRegional() {
    return this.licenseRegistrationForm.get('companyNameRegional');
  }

  get signedCapital() {
    return this.licenseRegistrationForm.get('signedCapital');
  }

  get sector() {
    return this.licenseRegistrationForm.get('sector');
  }

  get subSectors() {
    return this.licenseRegistrationForm.get('subSectors');
  }

  get sections() {
    return this.licenseRegistrationForm.get('sections');
  }

  get subSections() {
    return this.licenseRegistrationForm.get('subSections');
  }

  // end of getter methods

  getSectors() {
    this.progressBarService.triggerProgressBar(true);
    // get dummy sectors

    this.dummySectorsData = this.apiService.getJSON().subscribe(res => {
      this.dummySectorsData = res;
      this.sectorsList = this.dummySectorsData.sector;
    });

    // this.apiService.getSectors().subscribe(res => {
    //   console.log(res);
    //   // patch response to sector form controller
    //   this.licenseRegistrationForm.patchValue({sector: res});
    //   this.progressBarService.triggerProgressBar(false);
    // }, error => {
    //   console.error(error);
    //   this.progressBarService.triggerProgressBar(false);
    // });


  }

  getSubSectors(sector) {

    this.dummySectorsData.subSectors.forEach(subSector => {
      if (subSector.id === sector.value) {
        // empty array to avoid element repetitions
        this.subSectorsList = [];

        // add element to list
        this.subSectorsList.push(subSector);

      }
    });


    // this.apiService.getSubSectors(id).subscribe(res => {
    //   console.log(res);
    //
    //   // patch response to sub sector form controller
    //   this.licenseRegistrationForm.patchValue({subSectors: res});
    //   this.progressBarService.triggerProgressBar(false);
    // }, error => {
    //   console.error(error);
    //   this.progressBarService.triggerProgressBar(false);
    // });
  }

  getSections(subSector) {


    this.dummySectorsData.sections.forEach(section => {
      if (section.subSectorId === subSector.value) {
        // empty array to avoid element repetitions
        this.sectionsList = [];

        // add element to list
        this.sectionsList.push(section);

      }
    });

    // this.apiService.getSectionList(id).subscribe(res => {
    //   console.log(res);
    //   // patch response to sub secttion form controller
    //   this.licenseRegistrationForm.patchValue({sections: res});
    //   this.progressBarService.triggerProgressBar(false);
    // }, error => {
    //   console.error(error);
    //   this.progressBarService.triggerProgressBar(false);
    // });
  }

  getSubSections(section) {
    this.dummySectorsData.subSections.forEach(subSection => {

      if (subSection.sectionId === section.value) {
        // empty array to avoid element repetitions
        this.subSectionsList = [];

        // add element to list
        this.subSectionsList.push(subSection);

      }
    });

    // this.apiService.getSubSectorList(id).subscribe(res => {
    //   console.log(res);
    //   // patch response to sub section form controller
    //   this.licenseRegistrationForm.patchValue({subSections: res});
    //   this.progressBarService.triggerProgressBar(false);
    // }, error => {
    //   console.error(error);
    //   this.progressBarService.triggerProgressBar(false);
    // });
  }


  getClassificationLens(subSection) {

    console.log(subSection.value);
    this.dummySectorsData.classificationLens.forEach(classification => {
      if (classification.subSectionId === subSection.value) {
        // empty array to avoid element repetitions
        this.classificationLenses = [];

        // // add element to list
        this.classificationLenses.push(classification);
      }
    });


    // this.apiService.getSubSectorList(id).subscribe(res => {
    //   console.log(res);
    //   // patch response to sub section form controller
    //   this.licenseRegistrationForm.patchValue({subSections: res});
    //   this.progressBarService.triggerProgressBar(false);
    // }, error => {
    //   console.error(error);
    //   this.progressBarService.triggerProgressBar(false);
    // });
  }

  selectClassification(classification) {
    if (this.selectedClassificationLenses.length > 0) {
      this.selectedClassificationLenses.filter((value, index, arr) => {
        if (value === classification.id) {
          return arr.splice(index, 1);
        } else {
          return arr.push(classification.id);
        }
      });
    } else {
      this.selectedClassificationLenses.push(classification.id);
    }
    this.licenseRegistrationForm.patchValue({classificationLens: this.selectedClassificationLenses});


  }

  onSubmit(application) {
    this.progressBarService.triggerProgressBar(true);
    console.log(application);
    this.apiService.saveApplication(application).subscribe(res => {
      this.progressBarService.triggerProgressBar(false);
    });
  }


}

