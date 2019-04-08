using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CUSTOR.OTRLS.Core
{
    public class LookupRepository
    {
        OTRLSDbContext context;
        public LookupRepository(OTRLSDbContext _context)
        {
            context = _context;
        }
        public async Task<List<Lookup>> GetAllLookup()
        {

            IQueryable<Lookup> lookups = context.Lookup
                                            .OrderBy(l => l.English);

            return await lookups.ToListAsync();

        }

       

        public async Task<List<Lookup>> GetLookupByParent(int id, int page = 0, int pageSize = 15)
        {
            IQueryable<Lookup> lookups = context.Lookup
                .Where(sp => sp.LookUpTypeId == id)
                .OrderBy(sp => sp.English);
            if (page > 0)
            {
                lookups = lookups
                    .Skip((page - 1) * pageSize)
                    .Take(pageSize);
            }

            return await lookups.ToListAsync();
        }

       
        public async Task<List<LookupDTO>> GetAllLookupByLang(string lang)
        {

            return await context.Lookup
                .Select(l => new LookupDTO

                {
                    LookupId = l.LookupId,
                    LookUpTypeId = l.LookUpTypeId,
                    Description = (lang == "et") ? l.Amharic : l.English
                })
                .ToListAsync();

        }
        public async Task<List<LookupDTO>> GetLookups(string lang, int parentId)
        {

            return await context.Lookup
                .Select(l => new LookupDTO

                {
                    LookupId = l.LookupId,
                    LookUpTypeId = l.LookUpTypeId,
                    Description = (lang == "et") ? l.Amharic : l.English
                })
                .Where(look => look.LookUpTypeId == parentId)
                .ToListAsync();

        }
        public  async Task<Lookup> GetLookup(object LookupId)
        {
            Lookup lookups = null;

            int id = (int)LookupId;
            lookups = await context.Lookup
                .Where(look => look.LookupId == id).FirstOrDefaultAsync();

            return lookups;
        }


        public async Task<ICollection<Lookup>> GetRecordByParent(object LookupId)
        {
            ICollection<Lookup> lookups = null;

            int id = (int)LookupId;
            lookups = await context.Lookup
                .Where(look => look.LookUpTypeId == id).ToListAsync();

            return lookups;
        }

        public async Task<bool> DeleteLookup(int id)
        {
            var Lookup = await context.Lookup
                .FirstOrDefaultAsync(lookup => lookup.LookupId == id);
            if (Lookup == null)
            {
                throw new Exception("Lookup does not exist");
             }

            context.Lookup.Remove(Lookup);
            return true;
        }
    }
}
