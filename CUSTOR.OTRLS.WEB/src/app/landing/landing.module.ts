import { LandingComponent } from './landing.component';
import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import { SharedModule } from 'src/@custor/modules/shared.module';
import { ActionsComponent } from './actions/actions.component';
import { CommonModule } from '@angular/common';
import { OurServicesComponent } from './our-services/our-services.component';
import {CustomerService} from './our-services/customer-services.service';
export const routes = [
   // { path: '', component: LandingComponent, pathMatch: 'full' }
    { path: '', component: LandingComponent, pathMatch: 'full' }
  ];
@NgModule({
    declarations: [
      LandingComponent,
      ActionsComponent,
      OurServicesComponent,  
      // ContentHeaderComponent
    ],
    imports: [
        RouterModule.forChild(routes),
        SharedModule,
        CommonModule
      ],
    providers: [
      CustomerService
      ]
  })
  export class LandingModule { }
  