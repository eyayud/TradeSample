export class ManagerDTO {
  constructor() {
  }
  public ManagerId: number;
  public Tin?: string;
  public Title?: number;
  public CustomerId?: any;
  public FirstName?: string;
  public FirstNameEng?: string;
  public FatherName?: string;
  public FatherNameEng?: string;
  public GrandName?: string;
  public GrandNameEng?: string;
  public Gender?: number;
  public Nationality?: number;
  public Origin?: number;
  public Remark?: string;
  public IsActive?: boolean;
  public IsDeleted?: boolean;
  public PhotoData?: string;
  public RegionId: string = null;
  public ZoneId: string = null;
  public WoredaId: string = null;
  public KebeleId: string = null;
  public HouseNo: string = null;
  public TeleNo: string = null;
  public Pobox: string = null;
  public Fax: string = null;
  public CellPhoneNo: string = null;
  public Email: string = null;
  public OtherAddress: string = null;
  public AddressId = 0;
  public UserName: string = null;
}

export class ManagerModel {
  constructor() {
  }

  public ManagerId: number;
  public Tin?: string;
  public Title?: number;
  public InvestorId?: any;
  public FirstName?: string;
  public FirstNameSort?: string;
  public FirstNameSoundx?: string;
  public FirstNameEng?: string;
  public FatherName?: string;
  public FatherNameSort?: string;
  public FatherNameSoundx?: string;
  public FatherNameEng?: string;
  public GrandName?: string;
  public GrandNameSort?: string;
  public GrandNameSoundx?: string;
  public GrandNameEng?: string;
  public DateOfBirth?: Date;
  public Gender?: number;
  public Nationality?: number;
  public Origin?: number;
  public Photo?: number[];
  public Remark?: string;
  public AddressId = 0;
  public IsActive?: boolean;
  public selected?: boolean;
  public IsDeleted?: boolean;
  public EventDatetime?: Date;
  public CreatedUserId?: number;
  public CreatedUserName?: string;
  public UpdatedEventDatetime?: Date;
  public UpdatedUserId?: number;
  public UpdatedUserName?: string;
   
  public RegionId: string = null;
  public ZoneId: string = null;
  public WoredaId: string = null;
  public KebeleId: string = null;
  public HouseNo: string = null;
  public TeleNo: string = null;
  public Pobox: string = null;
  public Fax: string = null;
  public CellPhoneNo: string = null;
  public Email: string = null;
  public OtherAddress: string = null;
  public PhotoData?: string;
  public UserName: string = null;
}

export class ManagerListDTO {
  constructor() {
  }
  public ManagerId: number;
  public FullName: string = null;
  public FullNameEng: string = null;
}
