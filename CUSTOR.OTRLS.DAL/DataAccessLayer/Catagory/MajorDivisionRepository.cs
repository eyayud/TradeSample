using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace CUSTOR.OTRLS.Core
{
    public class MajorDivisionRepository
    {
        OTRLSDbContext context;
        public MajorDivisionRepository(OTRLSDbContext _context)
        {
            context = _context;
        }
        public async Task<List<MajorDivisionDTO>> GetRecords(string lang)
        {
            try
            {
                return await context.MajorDivision
                 .Select(m => new MajorDivisionDTO
                 {
                     Code = m.Code,
                     Description = (lang == "et") ? m.Description : m.EnglishDescription
                 })
                 .ToListAsync();
            }
            catch (InvalidOperationException)
            {
                throw new Exception("Couldn't load MajorDivisions");
            }
            catch (Exception ex)
            {
                string s = ex.Message;
                throw new Exception(ex.InnerException.ToString());
            }
        }

    }
}
