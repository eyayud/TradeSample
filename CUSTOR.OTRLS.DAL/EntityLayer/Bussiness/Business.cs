using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CUSTOR.OTRLS.Core
{
   public class Business
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        public string OwnerTIN { get; set; }

        public string TradeNameAmh { get; set; }

        public string TradeNameSort { get; set; }

        public string TradeNameSoundex { get; set; }

        public string TradesName { get; set; }

        public string TradeNameRegional { get; set; }

        public string TradeNameRegionalSort { get; set; }

        public string TradeNameRegionalSoundeX { get; set; }

        public DateTime ? DateRegistered { get; set; }

        public string LicenceNumber { get; set; }

        public decimal Capital { get; set; }

        public string SiteID { get; set; }

        public string CreatedBy { get; set; }

        public DateTime CreatedDate { get; set; }

        public string UpdatedBy { get; set; }

        public DateTime ? UpdatedDate { get; set; }
    }
}
