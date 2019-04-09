import { Injectable } from '@angular/core';

export class CustomerServiceData {
    public Id: number;
    public Desc: string;
    public Title: string;
}  
export const CUSTOMER_SERVICE: any[] =
[
    {
      ServiceId: '1', Title: 'አዲስ የንግድ ምዝገባ', TitleEnglish: 'Commercial Registration',
      Desc: 'All customers should have commercial registration certificate before they can request any other service.'
    },
    {
      ServiceId: '2', Title: 'አዲስ ንግድ ፈቃድ', TitleEnglish: 'New Trade License',
      Desc: 'Customers can use our online service to get new trade license for each business activity they intend to engage in.'
    },
    {
      ServiceId: '3', Title: 'የንግድ ፈቃድ  እድሳት', TitleEnglish: 'Renewal of Trade License',
      Desc: 'Customers can renew their Trade License every year using our online service application.'  
    },
    {
      ServiceId: '4', Title: 'የድርጅት ስም ማጣርያ', TitleEnglish: 'Business Name Clearance ',
      Desc: 'Use this service to check that the company name you intend to establish is not taken up by other customers'
    },
    {
      ServiceId: '5', Title: 'የንግድ ስም ማጣርያ', TitleEnglish: 'Trade Name Clearance',
      Desc: 'Customers can search our Trade Name database to enusre that the Trade Name they intend to register is not taken up by other cuatomers.'
    },
    
  ];

@Injectable()
export class CustomerService {

  constructor() { }

  getServiceList() {
    return CUSTOMER_SERVICE;
  }
}
