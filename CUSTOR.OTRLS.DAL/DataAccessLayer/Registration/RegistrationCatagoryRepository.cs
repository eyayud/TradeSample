using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace CUSTOR.OTRLS.Core
{
    public class RegistrationCatagoryRepository 
    {
        OTRLSDbContext context;
        public RegistrationCatagoryRepository(OTRLSDbContext _context)
        {
            context = _context;
        }

       
        public async Task<List<RegistrationCatagory>> GetRegistrationCatagoryByTIN(string Tin)
        {
            List<RegistrationCatagory> registrationCatagory = null;
            try
            {
               
                registrationCatagory = await context.RegistrationCatagory
                  .Where(reg => reg.Tin == Tin)
                                .ToListAsync();
            }
            catch (InvalidOperationException)
            {
                throw new Exception("Couldn't load Registration - invalid TIn specified.");
            }
            catch (Exception ex)
            {
                string s = ex.Message;
                throw new Exception(ex.InnerException.ToString());
            }
            return registrationCatagory;
        }


        public async Task<RegistrationCatagory> SaveRegistrationCatagory(RegistrationCatagory postedRegistrationCatagory)
        {
            context.RegistrationCatagory.Add(postedRegistrationCatagory);
            await context.SaveChangesAsync();
            return postedRegistrationCatagory;
        }


        public async Task<bool> DeleteRegistrationCatagory(string Tin)
        {
            var registrationCatagory = await context.RegistrationCatagory
                .FirstOrDefaultAsync(reg => reg.Tin == Tin);
            if (registrationCatagory != null)
            {
                context.RegistrationCatagory.Remove(registrationCatagory);
            }
            return true;
        }

    }
}