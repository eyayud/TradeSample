using System;
using System.Collections.Generic;
using System.Text;

namespace CUSTOR.OTRLS.Core
{
   public static class BussinessHelper
    {
        public static Business GetBusiness(this BussinessDTO bussinessDTO)
        {
            try
            {
                return new Business
                {
                    OwnerTIN= bussinessDTO.OwnerTIN,
                    TradeNameAmh= bussinessDTO.TradeNameAmh,
                    TradesName= bussinessDTO.TradesName,
                    TradeNameRegional= bussinessDTO.TradeNameRegional,
                    Capital= bussinessDTO.Capital
                };
            }
            catch (Exception ex)
            {
                string s = ex.Message;
                return null;
            }

        }
        public static BusinessLicensingGroup GetLicensingGroup(this BussinessDTO bussinessDTO)
        {
            return new BusinessLicensingGroup
            {
                MajorDivision= bussinessDTO.MajorDivision,
                Division= bussinessDTO.Division,
                MajorGroup= bussinessDTO.MajorGroup,
                BGroup= bussinessDTO.Group,
                SubGroup= bussinessDTO.SubGroup
            };
        }
        public static BussinessDTO GetBussinessDTO(Business buss, BusinessLicensingGroup bussGroup)
        {
            return new BussinessDTO
            {
               
            };
        }
    }
}
