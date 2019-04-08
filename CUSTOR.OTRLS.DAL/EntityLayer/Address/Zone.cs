using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CUSTOR.OTRLS.Core
{
    public partial class Zone
    {
        public Zone()
        {
            Address = new HashSet<Address>();
            Woreda = new HashSet<Woreda>();
        }

        public string ZoneId { get; set; }
        public string RegionId { get; set; }
        public string Description { get; set; }
        public string DescriptionEnglish { get; set; }
        public bool? IsActive { get; set; }
        public bool? IsDeleted { get; set; }
        public string CreatedUserId { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedUserId { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string UpdatedBy { get; set; }

        public virtual Region Region { get; set; }
        public virtual ICollection<Address> Address { get; set; }
        public virtual ICollection<Woreda> Woreda { get; set; }
    }
    public partial class ZoneViewModel
    {
        public ZoneViewModel()
        {
        }

        [Key]
        public string ZoneId { get; set; }

        public string RegionId { get; set; }
        public string Description { get; set; }
        //public string DescriptionEnglish { get; set; }
    }
}
