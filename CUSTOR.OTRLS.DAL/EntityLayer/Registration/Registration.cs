using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CUSTOR.OTRLS.Core
{
    public class Registration
    {
        public int ID { get; set; }
        public Guid MainGuid { get; set; }
        public Guid ParentGuid { get; set; }
        public string Tin { get; set; }
        public string RegNo { get; set; }
        public int LegalCondtion { get; set; }
        public string BusinessName { get; set; }
        public string BusinessNameAmh { get; set; }
        public string BusinessNameSort { get; set; }
        public string BusinessNameSoundX { get; set; }
        public string BusinessNameRegional { get; set; }
        public string BusinessNameRegionalSort { get; set; }
        public string BusinessNameRegionalSoundX { get; set; }
        public DateTime RegDate { get; set; }
        public int Status { get; set; }

        public bool IsPrivouslyRegistered { get; set; }
        public DateTime PreviousRegDate { get; set; }
        public string PrivousRegNumber { get; set; }
        public string MainCancilationReason { get; set; }
        public string FileNumber { get; set; }


        public decimal PaidUpCapital { get; set; }
        public decimal SignedCapital { get; set; }
        public decimal ApprovedCapital { get; set; }
        public decimal SingleShareAmount { get; set; }
        public bool IsSharedWithForeigner { get; set; }
        public decimal LocalPersonCapital { get; set; }
        public string GrantorName { get; set; }
        public string GrantorCountry { get; set; }
        public string GrantorMainAddress { get; set; }
        public string GrantorManagerName { get; set; }
        public string GrantorNameEng { get; set; }
        public string GrantorCountryEng { get; set; }
        public string GrantorMainAddressEng { get; set; }
        public string GrantorManagerNameEng { get; set; }
        public string BudgetYearCode { get; set; }
        //public ICollection<RegistrationCatagory> RegistrationCatagory { get; set; }
        [NotMapped]
        public string[] RegistrationCatagories { get; set; }


        public int TransferReason { get; set; }
        public string Remark { get; set; }
        public string TradeNameAmh { get; set; }
        public string TradeNameSort { get; set; }
        public string TradeNameSoundex { get; set; }
        public string TradesName { get; set; }
        public string TradeNameRegional { get; set; }
        public string TradeNameRegionalSort { get; set; }
        public string TradeNameRegionalSoundeX { get; set; }
        public DateTime DateRegistered { get; set; }
        public string TradeNameStatus { get; set; }
        public string PersonCanceldRegistration { get; set; }
        public DateTime CancilationDate { get; set; }


        public string Username { get; set; }
        public DateTime EventDateTime { get; set; }
        public string UpdatedUsername { get; set; }
        public DateTime UpdatedEventDatetime { get; set; }
        public string SiteID { get; set; }       
    }
}
