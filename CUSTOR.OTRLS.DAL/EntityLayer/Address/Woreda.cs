using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CUSTOR.OTRLS.Core
{
    public partial class Woreda
    {
        public Woreda()
        {
            Address = new HashSet<Address>();
            Kebele = new HashSet<Kebele>();
        }

        public string WoredaId { get; set; }
        public string ZoneId { get; set; }
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

        public virtual Zone Zone { get; set; }
        public virtual ICollection<Address> Address { get; set; }
        public virtual ICollection<Kebele> Kebele { get; set; }
    }
    public partial class WoredaViewModel
    {
        public WoredaViewModel()
        {
        }

        [Key]
        public string WoredaId { get; set; }

        public string ZoneId { get; set; }
        public string Description { get; set; }
        //public string DescriptionEnglish { get; set; }
    }
}
