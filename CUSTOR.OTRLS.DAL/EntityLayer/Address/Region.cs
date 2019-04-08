using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CUSTOR.OTRLS.Core
{
    public partial class Region
    {
        public Region()
        {
            Address = new HashSet<Address>();
            Zone = new HashSet<Zone>();
        }

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

        public virtual ICollection<Address> Address { get; set; }
        public virtual ICollection<Zone> Zone { get; set; }
    }
    public partial class RegionViewModel
    {
        public RegionViewModel()
        {
        }

        [Key]
        public string RegionId { get; set; }

        public string Description { get; set; }
    }
}
