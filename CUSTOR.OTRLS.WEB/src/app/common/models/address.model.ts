import { Injectable } from '@angular/core';

@Injectable()
export class Region {
    public RegionId: string;
    public Description: string;
    public DescriptionEnglish: string;

    constructor(RegionId?: string, Description?: string, DescriptionEnglish?: string) {
      this.RegionId = RegionId;
      this.Description = Description;
      this.DescriptionEnglish = DescriptionEnglish;
    }
  }

@Injectable()
export class Zone {
    public ZoneId: string;
    public isNew: boolean;
    public RegionId: string;
    public Description: string;
    public DescriptionEnglish: string;
    public Region?: Region;

    constructor(ZoneId?: string, RegionId?: string, Description?: string, DescriptionEnglish?: string, RegionName?: Region) {
      this.ZoneId = ZoneId;
      this.RegionId = RegionId;
      this.Description = Description;
      this.DescriptionEnglish = DescriptionEnglish;
      this.Region = RegionName;
    }
  }

export class Woreda {
    public RegionId: string;
    public ZoneId: string;
    public WoredaId: string;
    public isNew: boolean;
    public Description: string;
    public DescriptionEnglish: string;
    public Region: Region;
    public Zone: Zone;

    constructor(RegionId?: string, ZoneId?: string, WoredaId?: string, Description?: string,
                DescriptionEnglish?: string, RegionName?: Region, ZoneName?: Zone) {
      this.RegionId = RegionId;
      this.ZoneId = ZoneId;
      this.WoredaId = WoredaId;
      this.Description = Description;
      this.DescriptionEnglish = DescriptionEnglish;
      this.Region = RegionName;
      this.Zone = ZoneName;
    }
  }

@Injectable()
export class Kebele {
    public RegionId: string;
    public ZoneId: string;
    public KebeleId: string;
    public WoredaId: string;
    public Description: string;
    public DescriptionEnglish: string;
    public Region: Region;
    public Zone: Zone;
    public Woreda: Woreda;
    public isNew: boolean;

    constructor(RegionId?: string, ZoneId?: string, KebeleId?: string, WoredaId?: string,
                Description?: string, DescriptionEnglish?: string, RegionName?: Region, ZoneName?: Zone, WoredaName?: Woreda) {
      this.RegionId = RegionId;
      this.ZoneId = ZoneId;
      this.KebeleId = KebeleId;
      this.WoredaId = WoredaId;
      this.Description = Description;
      this.DescriptionEnglish = DescriptionEnglish;
      this.Region = RegionName;
      this.Zone = ZoneName;
      this.Woreda = WoredaName;
    }
  }

