using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace CUSTOR.OTRLS.Core
{
    public class RegistrationRepository
    {
        OTRLSDbContext context;
        public RegistrationRepository(OTRLSDbContext _context)
        {
            context = _context;
        }

        public async Task<Registration> GetRecord(object registrationID)
        {
            Registration registration = null;
            try
            {
                registration = await context.Registration
                  .Include(p => p.RegistrationCatagories)
                                .FirstOrDefaultAsync(reg => reg.ID == Convert.ToInt32(registrationID));
            }
            catch (InvalidOperationException)
            {
                throw new Exception("Couldn't load Registration - invalid Registration id specified.");
            }
            catch (Exception ex)
            {
                string s = ex.Message;
                throw new Exception(ex.InnerException.ToString());
            }
            return registration;
        }
        

        public async Task<List<Registration>> GetRecordByTIN(object Tin)
        {
            List<Registration> registration = null;
            try
            {
                string id = (string)Tin;
                registration = await context.Registration
                  .Where(reg => reg.Tin == id)
                                .ToListAsync();
            }
            catch (InvalidOperationException)
            {
                throw new Exception("Couldn't load Registration - invalid Registration id specified.");
            }
            catch (Exception ex)
            {
                string s = ex.Message;
                throw new Exception(ex.InnerException.ToString());
            }
            return registration;
        }
               


        public async Task<Registration> SaveRegistration(Registration postedRegistration)
        {
            RegistrationCatagoryRepository objRegCatagory = new RegistrationCatagoryRepository(context);
            //postedRegistration.TradeNameSort = objGeez.GetSortValueU(postedRegistration.TradeNameAmh);
            //postedRegistration.TradeNameRegionalSort = objGeez.GetSortValueU(postedRegistration.TradeNameRegional);
            //postedRegistration.BusinessNameSort = objGeez.GetSortValueU(postedRegistration.BusinessNameAmh);
            //postedRegistration.BusinessNameRegionalSort = objGeez.GetSortValueU(postedRegistration.BusinessNameRegional);

            postedRegistration.DateRegistered = DateTime.Now;
            postedRegistration.CancilationDate = DateTime.Now;
            postedRegistration.EventDateTime = DateTime.Now;
            postedRegistration.PreviousRegDate = DateTime.Now;
            postedRegistration.RegDate = DateTime.Now;
            postedRegistration.UpdatedEventDatetime = DateTime.Now;
            using (var transaction = context.Database.BeginTransaction())
            {
                try
                {
                   
                    context.Registration.Add(postedRegistration);
                    context.SaveChanges();

                    await objRegCatagory.DeleteRegistrationCatagory(postedRegistration.Tin);
                    foreach (var catagory in postedRegistration.RegistrationCatagories)
                    {
                        RegistrationCatagory regCatagory = new RegistrationCatagory();
                        regCatagory.Tin = postedRegistration.Tin;
                        regCatagory.MajorCatagoryCode = catagory;
                        regCatagory.MainGuid = Guid.NewGuid();
                        context.RegistrationCatagory.Add(regCatagory);
                        context.SaveChanges();
                    }
                    transaction.Commit();
                    return postedRegistration;
                }

                catch (Exception ex)
                {
                    transaction.Rollback();
                    string s = ex.Message;
                    throw new Exception(ex.Message);
                }
            }
        }


        public async Task<Registration> UpdateRegistration(Registration editedRegistration)
        {
            RegistrationCatagoryRepository objRegCatagory = new RegistrationCatagoryRepository(context);
            //editedRegistration.TradeNameSort = objGeez.GetSortValueU(editedRegistration.TradeNameAmh);
            //editedRegistration.TradeNameRegionalSort = objGeez.GetSortValueU(editedRegistration.TradeNameRegional);
            //editedRegistration.BusinessNameSort = objGeez.GetSortValueU(editedRegistration.BusinessNameAmh);
            //editedRegistration.BusinessNameRegionalSort = objGeez.GetSortValueU(editedRegistration.BusinessNameRegional);

            editedRegistration.DateRegistered = DateTime.Now;
            editedRegistration.CancilationDate = DateTime.Now;
            editedRegistration.EventDateTime = DateTime.Now;
            editedRegistration.PreviousRegDate = DateTime.Now;
            editedRegistration.RegDate = DateTime.Now;
            editedRegistration.UpdatedEventDatetime = DateTime.Now;

            using (var transaction = context.Database.BeginTransaction())
            {
                try
                {
                    context.Entry(editedRegistration).State = EntityState.Modified;
                    context.Add(editedRegistration);
                    context.SaveChanges();

                    await objRegCatagory.DeleteRegistrationCatagory(editedRegistration.Tin);
                    foreach (var catagory in editedRegistration.RegistrationCatagories)
                    {
                        RegistrationCatagory regCatagory = new RegistrationCatagory();
                        regCatagory.Tin = editedRegistration.Tin;
                        regCatagory.MajorCatagoryCode = catagory;
                        regCatagory.MainGuid = Guid.NewGuid();
                        context.RegistrationCatagory.Add(regCatagory);
                        context.SaveChanges();
                    }
                    transaction.Commit();
                    return editedRegistration;
                }

                catch (Exception ex)
                {
                    transaction.Rollback();
                    string s = ex.Message;
                    throw new Exception(ex.Message);
                }
            }
        }

        public async Task<bool> DeleteRegistration(string Tin)
        {
            var registration = await context.Registration
                .FirstOrDefaultAsync(reg => reg.Tin == Tin);
            if (registration == null)
            {
                throw new Exception("Registration does not exist");
            }
            context.Registration.Remove(registration);
            return true;
        }

        protected bool OnValidate(Registration entity)
        {
            //if (entity == null)
            //{
            //    ValidationErrors.Add("No record was provided");
            //    return false;
            //}
            //if (string.IsNullOrEmpty(entity.BusinessNameAmh))
            //    ValidationErrors.Add("Please enter business Name for Registration", "BusinessNameAmh");
            //if (string.IsNullOrEmpty(entity.BusinessName))
            //    ValidationErrors.Add("Please enter business Name for Registration", "BusinessName");
            //if (string.IsNullOrEmpty(entity.BusinessName))
            //    entity.BusinessNameRegional = entity.BusinessNameAmh;

            //else if (string.IsNullOrEmpty(entity.BusinessNameAmh) || entity.BusinessName.Length < 2)
            //    ValidationErrors.Add("First Name must be at least 2 charcters long");
            //return ValidationErrors.Count < 1;
            return true;
        }
    }
}