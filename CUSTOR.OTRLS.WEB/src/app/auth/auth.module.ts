import {NgModule} from '@angular/core';
import {CommonModule} from '@angular/common';
import {SharedModule} from 'src/@custor/modules/shared.module';
import {RegisterComponent} from './register/register.component'; 
import {ManagePasswordComponent} from './manage-password/manage.component';
import {LoginComponent} from './login/login.component';
import {LoginControlComponent} from './login/login-control.component';
import {ConfirmComponent} from './register/confirm.component';
import { RouterModule } from '@angular/router';
import {FormsModule, ReactiveFormsModule} from '@angular/forms';
import { TranslateModule, TranslateLoader } from '@ngx-translate/core';
import {AppTranslationService, TranslateLanguageLoader} from 'src/@custor/services/translation.service';

export const routes = [
    { path: '', redirectTo: 'login', pathMatch: 'full'},
    { path: 'login', component: LoginComponent},
    { path: 'register', component: RegisterComponent},
    { path: 'manage/:id', component: ManagePasswordComponent}
  ];
@NgModule({
  imports: [
    SharedModule,
    CommonModule,
    RouterModule.forChild(routes),
    FormsModule,
    ReactiveFormsModule,
    TranslateModule.forRoot({
      loader: {
        provide: TranslateLoader,
        useClass: TranslateLanguageLoader
      }
    }),
  ],
  declarations: [
      RegisterComponent,
      ManagePasswordComponent,
      LoginComponent,
      LoginControlComponent,
      ConfirmComponent
    ],
    providers: [
      AppTranslationService,
    ]
})
export class AuthenticationModule {
}
