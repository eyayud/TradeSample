import { Component } from '@angular/core';
import { AppTranslationService } from 'src/@custor/services/translation.service';
import {ConfigurationService} from 'src/@custor/services/configuration.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent {
  title = 'otrls';
  constructor(private translationService: AppTranslationService,
              private configService: ConfigurationService) {
      translationService.addLanguages(['en', 'et']);
      this.configService.language = 'et';
      
  }
}
