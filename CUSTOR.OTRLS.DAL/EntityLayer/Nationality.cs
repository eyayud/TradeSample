using System;
using System.Collections.Generic;

namespace CUSTOR.OTRLS.Core
{
    public partial class Nationality
    {
        public int Id { get; set; }
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
    }
}
