using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace CUSTOR.OTRLS.Core
{
    public class LookUpTypeRepository
    {
        OTRLSDbContext context;
        public LookUpTypeRepository(OTRLSDbContext _context)
        {
            context = _context;
        }
        public async Task<List<LookUpType>> GetAllLookUpTypes()
        {

            IQueryable<LookUpType> lookups = context.LookUpType
                                            .OrderBy(l => l.English);

            return await lookups.ToListAsync();

        }
       
        public async Task<List<LookUpType>> GetLookups(int page = 0, int pageSize = 15)
        {
            IQueryable<LookUpType> lookups = context.LookUpType
                                            .OrderBy(Lookups => Lookups.English);
            if (page > 0)
            {
                lookups = lookups
                .Skip((page - 1) * pageSize)
                .Take(pageSize);
            }
            return await lookups.ToListAsync();
        }
        public async Task<List<LookUpType>> GetAllLookupsByLang(string lang)
        {

            return await context.LookUpType
                .Select(l => new LookUpType
                {
                    LookUpTypeId = l.LookUpTypeId,
                    Description = (lang == "et") ? l.Description : l.English
                })
                .ToListAsync();

        }
        public async Task<LookUpType> GetLookUpType(object LookupId)
        {
            LookUpType lookup = null;
          
                int id = (int)LookupId;
                lookup = await context.LookUpType
                               .Where(lookups => lookups.LookUpTypeId == id).FirstOrDefaultAsync();
           
            return lookup;
        }

        public async Task<bool> DeleteLookup(int id)
        {
            var Lookup = await context.LookUpType
                .FirstOrDefaultAsync(lookup => lookup.LookUpTypeId == id);
            if (Lookup == null)
            {
                throw new Exception("Lookup does not exist");
            }
            context.LookUpType.Remove(Lookup);
            return true;
        }

    }
}
