import {Component, Input, OnDestroy, OnInit, Output, EventEmitter, ViewChild} from '@angular/core';
import {FormBuilder, FormGroup, Validators, NgForm} from '@angular/forms';
import {AuthService} from '../../../@custor/services/security/auth.service';
import {ToastrService, Toast} from 'ngx-toastr';
import {Utilities} from '../../../@custor/helpers/utilities';
import {UserLogin} from 'src/@custor/models/user-login.model';

@Component({
  selector: 'app-login-control',
  templateUrl: './login-control.component.html',
  styleUrls: ['./login-control.component.scss']
})
export class LoginControlComponent implements OnInit, OnDestroy {
  loginForm: FormGroup;

  isLoading = false;
  formResetToggle = true;
  loginStatusSubscription: any;

  @ViewChild('form')
  private form: NgForm;
 
  @Output()
  enterKeyPress = new EventEmitter();

  constructor(
    private toastr: ToastrService,
    private authService: AuthService,
    private formBuilder: FormBuilder
    ) {
    this.buildForm();

  }

  ngOnInit() {
    
    this.loginForm.setValue({
      userName: '',
      password: '',
      rememberMe: this.authService.rememberMe
    });
   }

  ngOnDestroy() {
    if (this.loginStatusSubscription) {
      this.loginStatusSubscription.unsubscribe();
    }
  }

  buildForm() {
    this.loginForm = this.formBuilder.group({
      userName: ['', Validators.required],
      password: ['', Validators.required],
      rememberMe: ''
    });
  }

  get userName() {
    return this.loginForm.get('userName');
  }

  get password() {
    return this.loginForm.get('password');
  }


  getUserLogin(): UserLogin {
    const formModel = this.loginForm.value;
    return new UserLogin(formModel.userName, formModel.password, formModel.rememberMe);
  }
  login() {

    
    if (!this.form.submitted) {
      this.form.onSubmit(null);
      return;
    }

    this.isLoading = true;

    this.authService.login(this.getUserLogin())
      .subscribe(
        user => {
          setTimeout(() => {
            this.isLoading = false;
            this.reset();


          }, 500);
        },
        error => {

          if (Utilities.checkNoNetwork(error)) {
            this.toastr.error(Utilities.noNetworkMessageCaption);
          } else {
            // tslint:disable-next-line:max-line-length
            const errorMessage = Utilities.findHttpResponseMessage('error_description', error) || Utilities.findHttpResponseMessage('error', error);

            if (errorMessage) {
              this.toastr.error(Utilities.noNetworkMessageCaption, 'Unable to login');
            } else {
              this.toastr.error(Utilities.getResponseBody(error), 'Unable to login');
            }
          }
          setTimeout(() => {
            this.isLoading = false;
          }, 500);
        });
  }

  reset() {
    this.formResetToggle = false;

    setTimeout(() => {
      this.formResetToggle = true;
    });
  }
  enterKeyDown() {
    this.enterKeyPress.emit();
  }

}
