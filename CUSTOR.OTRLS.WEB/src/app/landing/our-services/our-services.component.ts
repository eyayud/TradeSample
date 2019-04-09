import { Component, OnInit } from '@angular/core';
import { CustomerService, CustomerServiceData } from './customer-services.service';
import { Router } from '@angular/router';
@Component({
  selector: 'app-our-services',
  templateUrl: './our-services.component.html',
  styleUrls: ['./our-services.component.scss']
})
export class OurServicesComponent implements OnInit {
  services: CustomerServiceData[] = [];
  constructor(private customerService: CustomerService,  private router: Router) {}

  ngOnInit() {
    this.getServices('am');
  }
 getServices(currentLang) {
    let service: CustomerServiceData = new CustomerServiceData();
    this.customerService.getServiceList().forEach(ser => {
      service = {
        Id: ser.ServiceId.toString(),
        Title: (currentLang === 'et' ? ser.Title : ser.TitleEnglish),
        Desc: ser.Desc
      };
      this.services.push(service);
    });
  }

  goServiceDetail(title: string, id: any) {
    // localStorage.setItem('title', title);
    this.router.navigate(['/requirement/' + id]);
  }
}
