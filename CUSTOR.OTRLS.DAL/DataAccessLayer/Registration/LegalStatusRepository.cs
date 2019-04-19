using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace CUSTOR.OTRLS.Core
{
    public class LegalStatusRepository
    {
        OTRLSDbContext context;
        public LegalStatusRepository(OTRLSDbContext _context)
        {
            context = _context;
        }

        public async Task<List<LegalStatusDTO>> GetRecords(string lang)
        {
            try
            {
                return await context.LegalStatus
               .Select(l => new LegalStatusDTO
               {
                   Code = l.Code,
                   Description = (lang == "et") ? l.LegalStatusNameAmh : l.LegalStatusNameEng
               })
               .ToListAsync();
            }
            catch (InvalidOperationException)
            {
                throw new Exception("Couldn't load Legal Status");
            }
            catch (Exception ex)
            {
                string s = ex.Message;
                throw new Exception(ex.InnerException.ToString());
            }
        }

    }
}
