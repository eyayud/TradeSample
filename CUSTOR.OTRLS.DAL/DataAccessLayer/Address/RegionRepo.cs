using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
 
using Microsoft.EntityFrameworkCore;

namespace CUSTOR.OTRLS.Core
{
    public class RegionRepository
    {
        OTRLSDbContext context;
        public RegionRepository(OTRLSDbContext _context)
        {
            context = _context;
        }
        public async Task<List<Region>> GetRegions()
        {
            return await context.Region.ToListAsync();
        }

        public async Task<List<RegionViewModel>> GetRegions(string lang)
        {

            return await context.Region
                .Select(r => new RegionViewModel
                {
                    RegionId = r.RegionId,
                    Description = (lang == "et") ? r.Description : r.DescriptionEnglish
                })
                .ToListAsync();

        }


    }
}