import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';

@Component({
  selector: 'app-company-name',
  templateUrl: './company-name.component.html',
  styleUrls: ['./company-name.component.scss']
})
export class CompanyNameComponent implements OnInit {

  companyForm: FormGroup;
  title: string;
  toppingList: string[] = ['Extra cheese', 'Mushroom', 'Onion', 'Pepperoni', 'Sausage', 'Tomato'];
  constructor(private fb: FormBuilder) {
    this.title = "Register Test Form"
    this.createForm();
  }

  ngOnInit() {
  }
  onSubmit() {
    // var tempVar = this.companyForm.value.Title;
    // console.log(tempVar);
  }
  createForm() {
    this.companyForm = this.fb.group({
      companyNameOptionOne: ['', Validators.required],
      companyNameOptionTwo: ['', Validators.required],
      companyNameOptionThree: ['', Validators.required],
      companyNameOptionOneAm: ['', Validators.required],
      companyNameOptionTwoAm: ['', Validators.required],
      companyNameOptionThreeAm: ['', Validators.required],
    });
  }
}
