import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl, FormBuilder, Validators } from '@angular/forms';
@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.scss']
})
export class RegisterComponent implements OnInit {
  //private form: NgForm;
  regForm: FormGroup;
  title : string ; 
  toppingList :string[]=  ['Extra cheese','Mushroom', 'Onion', 'Pepperoni', 'Sausage', 'Tomato'];
  
  constructor(private fb: FormBuilder) { 
    this.title ="Register Test Form"
    this.createForm();
  }

  ngOnInit() {

  }
  onSubmit(){
    var tempVar = this.regForm.value.Title;
    console.log(tempVar);
  }
  saveBusiness(){
     console.log("am here")
  }
  cancel(){

  }
  getFormControl(name: string) {
    return this.regForm.get(name);
  }
  isValid(name: string) {
    var e = this.getFormControl(name);
    return e && e.valid;
  }
  // returns TRUE if the FormControl has been changed
  isChanged(name: string) {
    var e = this.getFormControl(name);
    return e && (e.dirty || e.touched);
  }
  // returns TRUE if the FormControl is invalid after user changes
  hasError(name: string) {
    var e = this.getFormControl(name);
    return e && (e.dirty || e.touched) && !e.valid;
  }
  createForm(){
    this.regForm = this.fb.group({
      tinNumber: ['', [Validators.required , Validators.minLength(10),Validators.maxLength(10)]],
      assignedCapital: ['', Validators.required],
      paidCapital:['', Validators.required],
      businessType:['', Validators.required],
    });
  }
}
