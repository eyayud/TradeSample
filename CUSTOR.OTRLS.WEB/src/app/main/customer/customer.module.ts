import {NgModule} from '@angular/core';
import {FormsModule, ReactiveFormsModule} from '@angular/forms';
import {RouterModule} from '@angular/router';
import {SharedModule} from '../../../@custor/modules/shared.module';
import {FlexLayoutModule} from '@angular/flex-layout';
import {CommonModule} from '@angular/common';
import {TranslateModule, TranslateLoader} from '@ngx-translate/core';
import {AppTranslationService, TranslateLanguageLoader} from 'src/@custor/services/translation.service';
import {ManagerComponent} from './manager/manager.component';
import {ManagerListComponent} from './manager-list/manager-list.component';
import {BusinessComponent} from './business/business.component';
import {BusinessListComponent} from './business-list/business-list.component';
import {LookUpService} from '../../common/services/look-up.service';
import {AddressService} from '../../common/services/address.service';
import {ManagerService} from './services/manager.service';
import {ProfileComponent} from './profile/profile.component';
import {BusinessCreateComponent} from './business-create/business-create.component';
import {BusinessApiService} from './services/business.api.service';

export const routes = [
  {path: '', redirectTo: 'manager-list', pathMatch: 'full'},
  {path: 'manager-list', component: ManagerListComponent},
  {path: 'manager/:id', component: ManagerComponent},
  {path: 'createBusinessLicense', component: BusinessCreateComponent},
  {path: 'business', component: BusinessComponent},
  {path: 'profile', component: ProfileComponent},
  {path: 'createBusinessLicense', component: BusinessCreateComponent}
];

@NgModule({
  declarations: [
    ManagerComponent,
    ManagerListComponent,
    BusinessComponent,
    BusinessListComponent,
    ProfileComponent,
    BusinessCreateComponent
  ],
  imports: [
    RouterModule.forChild(routes),
    SharedModule,
    CommonModule,
    FlexLayoutModule,
    FormsModule,
    ReactiveFormsModule,
    TranslateModule.forRoot({
      loader: {
        provide: TranslateLoader,
        useClass: TranslateLanguageLoader
      }
    }),
  ],
  providers: [AppTranslationService, LookUpService, AddressService, ManagerService, BusinessApiService]

})
export class CustomerModule {
}
