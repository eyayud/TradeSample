using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CUSTOR.OTRLS.Core
{
    public class BusinessRepository
    {
        OTRLSDbContext context;
        public BusinessRepository(OTRLSDbContext _context)
        {
            context = _context;
        }
        /// <summary>
        /// Get Registered Bussiness by BussinessId
        /// </summary>
        /// <param name="BussinessId"></param>
        /// <returns></returns>
        public async Task<Business> GetBussiness(int BussinessId)
        {
            try
            {
                Business bussiness = null;

                int id = BussinessId;
                bussiness = await context.Business
                    .FirstOrDefaultAsync(bs => bs.ID == id);

                return bussiness;
            }
            catch (Exception ex)
            {
                string s = ex.Message;
                throw new Exception(ex.InnerException.ToString());
            }

        }
        /// <summary>
        /// Save Bussines
        /// </summary>
        /// <param name="postedBussiness"></param>
        /// <returns></returns>
        public async Task<BussinessDTO> SaveBussiness(BussinessDTO postedBussiness)
        {
            bool isUpdate = (postedBussiness.BussinessId > 0); // New or Update?
            // map DTO to manager entity 
            Business buss = BussinessHelper.GetBusiness(postedBussiness);
            buss.CreatedDate = DateTime.Now;
            buss.SiteID = "";
            buss.LicenceNumber = "";
            buss.CreatedBy = "";

            // We should always use transaction for operations involving two or more entities
            using (var transaction = await context.Database.BeginTransactionAsync())
            {
                try
                {
                    // first save manager entity
                    if (isUpdate)
                    {
                        buss.ID = postedBussiness.BussinessId;
                        context.Business.Update(buss);
                        context.SaveChanges();

                    }
                    else
                    {
                        context.Business.Add(buss);
                        context.SaveChanges();
                    }
                    // then save  BusinessLicens entity
                    BusinessLicensingGroup BusinessLicense = BussinessHelper.GetLicensingGroup(postedBussiness);
                    BusinessLicense.BusinessId = buss.ID;

                    if (isUpdate)
                    {
                        BusinessLicense.BusinessId = postedBussiness.BussinessId;
                        context.BusinessLicensingGroup.Update(BusinessLicense);
                        context.SaveChanges();
                    }
                    else
                    {
                        BusinessLicense.BusinessLicensingId = 0;
                        context.BusinessLicensingGroup.Add(BusinessLicense);
                        context.SaveChanges();
                    }
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    throw new Exception(ex.Message);
                }

                transaction.Commit();
                postedBussiness.BussinessId = buss.ID; //used for image filename
                return postedBussiness;
            }
        }
        //public async Task<List<BussinessDTO>> GetCommerialRegistration(string Tin)
        //{
        //    try
        //    {

        //        return await context.Business
        //            .Where(buss => buss.OwnerTIN == Tin)
        //            .Select(buss => new BussinessDTO()
        //            {
        //                TradeNameAmh = buss.TradeNameAmh,
        //                TradesName = buss.TradesName,
        //                TradeNameRegional = buss.TradeNameRegional,
        //                Capital = buss.Capital,
        //                OwnerTIN = buss.OwnerTIN,
        //            })
        //            .ToListAsync();
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new Exception(ex.Message);
        //    }
        //}
        /// <summary>
        /// Get record from Commertial Registration for bussiness By tin
        /// </summary>
        /// <param name="Tin"></param>
        /// <returns></returns>
        public async Task<BussinessDTO> GetCommerialRegistration(string Tin)
        {
            try
            {

                return  new BussinessDTO()
                    {
                        TradeNameAmh = "እያዩ",
                        TradesName = "Eyayu",
                        TradeNameRegional = "እያዩ",
                        Capital = 2000,
                        OwnerTIN = Tin,
                    };
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
