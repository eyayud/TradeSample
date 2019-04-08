using System;
using System.Collections.Generic;

namespace CUSTOR.OTRLS.Core
{
    public partial class LookUpType
    {
        public LookUpType()
        {
            Lookup = new HashSet<Lookup>();
        }

        public int LookUpTypeId { get; set; }
        public string English { get; set; }
        public string Amharic { get; set; }
        public string Tigrigna { get; set; }
        public string AfanOromo { get; set; }
        public string Afar { get; set; }
        public string Somali { get; set; }
        public string Description { get; set; }
        public short? IsActive { get; set; }
        public short? IsDeleted { get; set; }
        public string CreatedUserId { get; set; }
        public DateTime CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedUserId { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string UpdatedBy { get; set; }

        public virtual ICollection<Lookup> Lookup { get; set; }
    }
}
