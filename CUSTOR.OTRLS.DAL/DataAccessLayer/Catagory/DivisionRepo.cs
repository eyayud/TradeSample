using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CUSTOR.OTRLS.Core
{
   public class DivisionRepository
    {
        OTRLSDbContext context;
        public DivisionRepository(OTRLSDbContext _context)
        {
            context = _context;
        }
        public async Task<List<DivisionViewModel>> GetDivisionByMajorDivisionid(int MajorDivisionid)
        {
            try
            {

                return await context.Division
                    .Where(md => md.Parent == MajorDivisionid)
                    .Select(md => new DivisionViewModel()
                    {
                        Code = md.Code,
                        Description = md.Description
                    })
                    .ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
