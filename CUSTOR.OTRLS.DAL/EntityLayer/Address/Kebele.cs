using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CUSTOR.OTRLS.Core
{
    public partial class Kebele
    {
        public Kebele()
        {
            Address = new HashSet<Address>();
        }

        public string KebeleId { get; set; }
        public string WoredaId { get; set; }
        public string Description { get; set; }
        public string DescriptionEnglish { get; set; }
        public bool? IsActive { get; set; }
        public bool IsDeleted { get; set; }
        public string CreatedUserId { get; set; }
        public DateTime CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedUserId { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string UpdatedBy { get; set; }

        public virtual Woreda Woreda { get; set; }
        public virtual ICollection<Address> Address { get; set; }
    }
    public partial class KebeleViewModel
    {
        public KebeleViewModel()
        {
        }

        [Key]
        public string KebeleId { get; set; }

        public string WoredaId { get; set; }
        public string Description { get; set; }
        //public string DescriptionEnglish { get; set; }
    }
}
