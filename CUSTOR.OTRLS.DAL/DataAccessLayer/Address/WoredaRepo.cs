using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
 
using Microsoft.EntityFrameworkCore;

namespace CUSTOR.OTRLS.Core
{
    public class WoredaRepository
    {
        OTRLSDbContext context;
        public WoredaRepository(OTRLSDbContext _context)
        {
            context = _context;
        }
 
        public async Task<List<WoredaViewModel>> GetAllWoredas(string lang)
        {
           
            return await context.Woreda
                .Select(w => new WoredaViewModel

                {
                    ZoneId = w.ZoneId,
                    WoredaId = w.WoredaId,
                    //DescriptionEnglish = w.DescriptionEnglish,
                    Description = (lang == "et") ? w.Description : w.DescriptionEnglish
                })
                .ToListAsync();
           
        }

        public async Task<List<Woreda>> GetWoredas(int page = 0, int pageSize = 15)
        {
            IQueryable<Woreda> woreda = context.Woreda
                .Include(z => z.Zone)
                .OrderBy(zo => zo.WoredaId);
            if (page > 0)
            {
                woreda = woreda
                    .Skip((page - 1) * pageSize)
                    .Take(pageSize);
            }

            return await woreda.ToListAsync();
        }

        public async Task<List<Woreda>> GetWoredasByParent(string id,int page = 0, int pageSize = 15)
        {
            IQueryable<Woreda> woreda = context.Woreda
                .Where(zo => zo.ZoneId == id)
                .OrderBy(zo => zo.DescriptionEnglish);
            if (page > 0)
            {
                woreda = woreda
                    .Skip((page - 1) * pageSize)
                    .Take(pageSize);
            }

            return await woreda.ToListAsync();
        }

        public async Task<List<Woreda>> GetWoredas(object zId)
        {
             
            //IQueryable<Woreda> woredas = context.Woredas;
            //return await woredas.ToListAsync();
            string id = zId.ToString();
            return await context.Woreda
                .Where(zn => zn.ZoneId == id)
                .Select(w => new Woreda()
                {
                    ZoneId = w.ZoneId,
                    WoredaId = w.WoredaId,
                    DescriptionEnglish = w.DescriptionEnglish,
                    Description = w.Description
                })
                .ToListAsync();
        }

        public Woreda GetWoreda(object rId)
        {
            Woreda woreda = null;
           
            string id = rId.ToString();
            woreda = context.Woreda
                .Include(r => r.Zone)
                .Include(r => r.Kebele)
                .Where(x => x.WoredaId == id).FirstOrDefault();
           
            return woreda;
        }

        public async Task<List<Woreda>> GetAllWoredas()
        {
             
            IQueryable<Woreda> woredas = context.Woreda;
            int i = woredas.Count();
            return await woredas.ToListAsync();
            
        }
 
    }
}