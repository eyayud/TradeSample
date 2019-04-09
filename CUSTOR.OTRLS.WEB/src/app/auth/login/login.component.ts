import {Component, ViewChild} from '@angular/core';

import {LoginControlComponent} from './login-control.component';
import { AppTranslationService } from 'src/@custor/services/translation.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})

export class LoginComponent {
  @ViewChild(LoginControlComponent)
  loginControl: LoginControlComponent;
  constructor(
    private translationService: AppTranslationService) {
    this.translationService.addLanguages(['en', 'et']);
    this.translationService.setDefaultLanguage('en');
  }

}
