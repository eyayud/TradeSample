import { NgModule } from '@angular/core';
import { SharedModule } from '../../../@custor/modules/shared.module';
import { RegisterComponent } from './register.component';
import { RouterModule } from '@angular/router';
import { CommonModule } from '@angular/common';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { RegisterTabComponent } from './register-tab/register-tab.component';
import { ManagersComponent } from './managers/managers.component';
import { TranslateModule, TranslateLoader } from '@ngx-translate/core';
import { TranslateLanguageLoader, AppTranslationService } from 'src/@custor/services/translation.service';
import { ConfigurationService } from 'src/@custor/services/configuration.service';
import { AccountService } from 'src/@custor/services/security/account.service';
import { AccountEndpoint } from 'src/@custor/services/security/account-endpoint.service';
import { EndpointFactory } from 'src/@custor/services/security/endpoint-factory.service';
import { LocalStoreManager } from 'src/@custor/services/storeManager.service';
import { AuthService } from 'src/@custor/services/security/auth.service';
import { LookUpService } from 'src/app/common/services/look-up.service';
import { AddressService } from 'src/app/common/services/address.service';
import { ManagerService } from '../customer/services/manager.service';
import { CompanyNameComponent } from './company-name/company-name.component';
export const routes = [
  { path: '', component: RegisterTabComponent },
  { path: 'new', component: RegisterComponent },
];


@NgModule({
  declarations: [RegisterComponent, RegisterTabComponent, ManagersComponent, CompanyNameComponent],
  exports: [RegisterComponent, RegisterTabComponent],
  imports: [
    FormsModule,
    ReactiveFormsModule,
    SharedModule,
    CommonModule,
    RouterModule.forChild(routes),
    TranslateModule.forRoot({
      loader: {
        provide: TranslateLoader,
        useClass: TranslateLanguageLoader
      }
    }),
  ],
  providers: [AppTranslationService, LookUpService, AddressService, ManagerService]

})


export class RegisterModule { }
