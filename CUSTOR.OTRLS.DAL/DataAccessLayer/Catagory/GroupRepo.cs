using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CUSTOR.OTRLS.Core
{
  public class GroupRepository
    {
        OTRLSDbContext context;
        public GroupRepository(OTRLSDbContext _context)
        {
            context = _context;
        }
        public async Task<List<GroupViewModel>> GetGroupByMajorGroupCode(int MajorGroupCode)
        {
            try
            {

                return await context.Group
                    .Where(md => md.Parent == MajorGroupCode)
                    .Select(md => new GroupViewModel()
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
