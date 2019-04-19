using System;
using System.Collections.Generic;
using System.Text;

namespace CUSTOR.OTRLS.Core
{
   public class BussinessDTO
    {
        public int BussinessId { get; set; }
        public string OwnerTIN { get; set; }

        public string TradeNameAmh { get; set; }

        public string TradesName { get; set; }

        public string TradeNameRegional { get; set; }

        public decimal Capital { get; set; }

        public int  MajorDivision { get; set; }

        public int Division { get; set; }

        public int MajorGroup { get; set; }
        public int Group { get; set; }
        public int SubGroup { get; set; }
    }
}
