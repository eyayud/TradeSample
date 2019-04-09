// import { MaterialModule } from '../../@custor/modules/material.module';
import { DashboardComponent } from './dashboard.component';
import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import { SharedModule } from '../../../@custor/modules/shared.module';
import { FlexLayoutModule } from '@angular/flex-layout';
import { CommonModule } from '@angular/common';
import { TranslateModule, TranslateLoader } from '@ngx-translate/core';
import {AppTranslationService, TranslateLanguageLoader} from 'src/@custor/services/translation.service';

export const routes = [
    { path: '', component: DashboardComponent, pathMatch: 'full' }
  ];
@NgModule({
    declarations: [
  
      
      DashboardComponent,
      
      // MainComponent
    ],
    imports: [
        RouterModule.forChild(routes),
        SharedModule,
        CommonModule,
        FlexLayoutModule,
        TranslateModule.forRoot({
          loader: {
            provide: TranslateLoader,
            useClass: TranslateLanguageLoader
          }
        }),
        
      ],
      providers: [AppTranslationService]
   
  })
  export class DashboardModule { }
  