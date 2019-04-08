using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;

namespace CUSTOR.OTRLS.Core
{
    public class ZoneRepository  
    {
        OTRLSDbContext context;
        public ZoneRepository(OTRLSDbContext _context)
        {
            context = _context;
        }
        public async Task<List<Zone>> GetZones(object rId)
        {
            string id = rId.ToString();
            IQueryable<Zone> zones = context.Zone;
            int i = zones.Where(x => x.RegionId == id).Count();
            return await zones.Where(x => x.RegionId == id).ToListAsync();
        }

        public async Task<List<Zone>> GetZones(int page = 0, int pageSize = 15)
        {
            IQueryable<Zone> zones = context.Zone
                .Include(r => r.Region)
                .OrderBy(zo => zo.ZoneId);
            if (page > 0)
            {
                zones = zones
                    .Skip((page - 1) * pageSize)
                    .Take(pageSize);
            }

            return await zones.ToListAsync();
        }

        public async Task<List<Zone>> GetZonesByParent(string id, int page = 0, int pageSize = 15)
        {
            IQueryable<Zone> zones = context.Zone
                //.Include(r => r.Region)
                .Where(zo => zo.RegionId == id)
                .OrderBy(zo => zo.DescriptionEnglish);
            if (page > 0)
            {
                zones = zones
                    .Skip((page - 1) * pageSize)
                    .Take(pageSize);
            }

            return await zones.ToListAsync();
        }

        public Zone GetZone(object rId)
        {
            Zone zone = null;

            string id = rId.ToString();
            zone = context.Zone
                .Include(r => r.Region)
                .Where(x => x.ZoneId == id).FirstOrDefault();

            return zone;
        }

       

        public async Task<List<ZoneViewModel>> GetAllZones(string lang)
        {
            return await context.Zone
            .Select(z => new ZoneViewModel

            {
                ZoneId = z.ZoneId,
                RegionId = z.RegionId,
                Description = (lang == "et") ? z.Description : z.DescriptionEnglish
            })
            .ToListAsync();
          
        }
    }
}