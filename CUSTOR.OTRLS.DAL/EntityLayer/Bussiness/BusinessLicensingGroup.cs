using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CUSTOR.OTRLS.Core
{
   public class BusinessLicensingGroup
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int BusinessLicensingId { get; set; }

        public int BusinessId { get; set; }

        public int MajorDivision { get; set; }

        public int Division { get; set; }

        public int MajorGroup { get; set; }

        public int BGroup { get; set; }

        public int SubGroup { get; set; }
    }
}
