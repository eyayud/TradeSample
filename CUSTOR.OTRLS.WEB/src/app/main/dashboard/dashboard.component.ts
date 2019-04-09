import { Component, OnInit } from '@angular/core';
import {AppTranslationService} from 'src/@custor/services/translation.service';
  
@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html',
  styleUrls: ['./dashboard.component.scss']
})
export class DashboardComponent implements OnInit {

  constructor(private translationService: AppTranslationService) { 
    this.translationService.addLanguages(['en', 'et']);
    this.translationService.setDefaultLanguage('en');
  }

  ngOnInit() {
  }

}
