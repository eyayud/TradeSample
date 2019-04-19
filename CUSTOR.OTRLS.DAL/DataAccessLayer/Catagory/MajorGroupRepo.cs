using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CUSTOR.OTRLS.Core
{
  public class MajorGroupRepository
    {
        OTRLSDbContext context;
        public MajorGroupRepository(OTRLSDbContext _context)
        {
            context = _context;
        }
        public async Task<List<MajorGroupModel>> GetMajorGroupByDivisionId(int DivisionId)
        {
            try
            {

                return await context.MajorGroup
                    .Where(md => md.Parent == DivisionId)
                    .Select(md => new MajorGroupModel()
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
