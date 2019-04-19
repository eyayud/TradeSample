using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CUSTOR.OTRLS.Core
{
  public class SubGroupRepository
    {
        OTRLSDbContext context;
        public SubGroupRepository(OTRLSDbContext _context)
        {
            context = _context;
        }
        public async Task<List<SubGroupModel>> GetSubGroupByGroupid(int Groupid)
        {
            try
            {

                return await context.SubGroup
                    .Where(md => md.Parent == Groupid)
                    .Select(md => new SubGroupModel()
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
