using System;
using System.Collections.Generic;

namespace CUSTOR.OTRLS.Core
{
    public partial class Address
    {
        public int AddressId { get; set; }
        public int ParentId { get; set; }
        public int AddressType { get; set; }
        public bool IsMainOffice { get; set; }
        public string SpecificAreaName { get; set; }
        public string RegionId { get; set; }
        public string TownId { get; set; }
        public string ZoneId { get; set; }
        public string WoredaId { get; set; }
        public string KebeleId { get; set; }
        public string HouseNo { get; set; }
        public string TeleNo { get; set; }
        public string Pobox { get; set; }
        public string Fax { get; set; }
        public string CellPhoneNo { get; set; }
        public string Email { get; set; }
        public string OtherAddress { get; set; }
        public string Remark { get; set; }
        public bool? IsActive { get; set; }
        public bool? IsDeleted { get; set; }
        public Guid? ObjectId { get; set; }
        public int? IndustrialParkId { get; set; }
        public bool? IsIndustrialPark { get; set; }
        public string CreatedUserId { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedUserId { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string UpdatedBy { get; set; }

        public virtual Kebele Kebele { get; set; }
        public virtual Region Region { get; set; }
        public virtual Woreda Woreda { get; set; }
        public virtual Zone Zone { get; set; }
    }
}
