import { NgModule } from '@angular/core';
import { HttpClientModule } from '@angular/common/http';
import { ToastrModule } from 'ngx-toastr';
import { MainComponent } from './main.component';
import { SharedModule } from 'src/@custor/modules/shared.module';
import { RouterModule } from '@angular/router';
import { TranslateModule, TranslateLoader } from '@ngx-translate/core';
import {AppTranslationService, TranslateLanguageLoader} from 'src/@custor/services/translation.service';
import {ConfigurationService} from 'src/@custor/services/configuration.service';
import {EndpointFactory} from 'src/@custor/services/security/endpoint-factory.service';
import {AccountService} from 'src/@custor/services/security/account.service';
import {AccountEndpoint} from 'src/@custor/services/security/account-endpoint.service';
import { LocalStoreManager } from 'src/@custor/services/storeManager.service';
import { AuthService } from 'src/@custor/services/security/auth.service';
import {ProgressBarComponent} from '../../@custor/components/progress-bar/progress-bar.component';

export const routes = [
      {
            path: '',
            component: MainComponent, children: [
                { path: 'dashboard', loadChildren: './dashboard/dashboard.module#DashboardModule'},
                { path: 'customer', loadChildren: './customer/customer.module#CustomerModule'}
            ]
    }
  ];

 
@NgModule({
  declarations: [
    // GroupByPipe,
    MainComponent,
    ProgressBarComponent
   ],
  imports: [
    HttpClientModule,
    ToastrModule.forRoot(),
    SharedModule,
    RouterModule.forChild(routes),
    TranslateModule.forRoot({
        loader: {
          provide: TranslateLoader,
          useClass: TranslateLanguageLoader
        }
      }),
   ],
   providers: [
    AppTranslationService,
    ConfigurationService,
    AccountService,
    AccountEndpoint,
    EndpointFactory,
    LocalStoreManager, 
    AuthService
  ],
})
export class MainModule { }
