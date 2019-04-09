import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { AppComponent } from './app.component';
import {BrowserAnimationsModule} from '@angular/platform-browser/animations';
import { HttpClientModule } from '@angular/common/http';
import { ToastrModule } from 'ngx-toastr';

import { TranslateModule, TranslateLoader } from '@ngx-translate/core';
import {AppTranslationService, TranslateLanguageLoader} from 'src/@custor/services/translation.service';
import {ConfigurationService} from 'src/@custor/services/configuration.service';
import {EndpointFactory} from 'src/@custor/services/security/endpoint-factory.service';
import {AccountService} from 'src/@custor/services/security/account.service';
import {AccountEndpoint} from 'src/@custor/services/security/account-endpoint.service';
import { LocalStoreManager } from 'src/@custor/services/storeManager.service';
import { AuthService } from 'src/@custor/services/security/auth.service';

import { GroupByPipe } from 'src/@custor/pipes/group-by.pipe';
import { routing } from './app.routing';
 
@NgModule({
  declarations: [
    AppComponent,
    GroupByPipe,
   ],
  imports: [
    BrowserModule,
    HttpClientModule,
    BrowserAnimationsModule,
    TranslateModule.forRoot({
      loader: {
        provide: TranslateLoader,
        useClass: TranslateLanguageLoader
      }
    }),
    ToastrModule.forRoot(),
    routing,
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
  bootstrap: [AppComponent]
})
export class AppModule { }
export function getBaseUrl() {
  return document.getElementsByTagName('base')[0].href;
}
