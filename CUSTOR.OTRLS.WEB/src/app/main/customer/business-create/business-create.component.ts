import { Component, OnInit } from '@angular/core';
import { AppTranslationService } from 'src/@custor/services/translation.service';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { BusinessApiService } from '../services/business.api.service';

@Component({
  selector: 'app-business-create',
  templateUrl: './business-create.component.html',
  styleUrls: ['./business-create.component.scss']
})
export class BusinessCreateComponent implements OnInit {

  licenseRegistrationForm:FormGroup;
  constructor(
    private translationService: AppTranslationService,
    private formBuilder: FormBuilder,
    private apiService:BusinessApiService
    ) {
    this.translationService.changeLanguage('et');

    //build the form
    this.licenseRegistrationForm = this.formBuilder.group({
      'companyNameAmharic':['',[Validators.required,Validators.minLength(4)]],
      'companyNameEnglish':['',[Validators.required,Validators.minLength(4)]],
      'companyNameRegional':['',[Validators.required,Validators.minLength(4)]],
      'signedCapital':['',Validators.required],
      'sector':['',Validators.required],
      'subSectors':['',Validators.required],
      'sections':['',Validators.required],
      'subSections':['',Validators.required]
    });


    //get list of sectors
    this.getSectors();
    
   }

   
  ngOnInit() {
  }

  getSectors(){
    this.apiService.getSectors().subscribe(res=>{
      console.log(res);
       //patch response to sector form controller
    this.licenseRegistrationForm.patchValue({'sector':res});
    })
   

  }

  getSubsectors(id){
    this.apiService.getSubSectors(id).subscribe(res=>{
      console.log(res);
       //patch response to sub sector form controller
    this.licenseRegistrationForm.patchValue({'subSectors':res});
    })
  }

  getSections(id){
    this.apiService.getSectionList(id).subscribe(res=>{
      console.log(res);
       //patch response to sub secttion form controller
    this.licenseRegistrationForm.patchValue({'sections':res});
    })
  }

  getSubSections(id){
    this.apiService.getSubSectorList(id).subscribe(res=>{
      console.log(res);
       //patch response to sub section form controller
    this.licenseRegistrationForm.patchValue({'subSections':res});
    })
  }

  onSubmit(application){
    console.log(application);
    this.apiService.saveApplication(application).subscribe(res=>{
      console.log(application)
    })
  }



}
