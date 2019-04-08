using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
 
using Microsoft.EntityFrameworkCore;

namespace CUSTOR.OTRLS.Core
{
    public class KebeleRepository
    {
        OTRLSDbContext context;
        public KebeleRepository(OTRLSDbContext _context)
        {
            context = _context;
        }

        public async Task<List<KebeleViewModel>> GetKebelesByWoredaId(string lang, string wrdId)
        {
            try
            {

                return await context.Kebele
                    .Where(wrd => wrd.WoredaId == wrdId)
                    .Select(k => new KebeleViewModel()
                    {
                        WoredaId = k.WoredaId,
                        KebeleId = k.KebeleId,
                        Description = (lang == "et") ? k.Description : k.DescriptionEnglish
                    })
                    .ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<List<KebeleViewModel>> GetAllKebeles(string lang)
        {
            try
            {
                return await context.Kebele
                    .Select(k => new KebeleViewModel

                    {
                        WoredaId = k.WoredaId,
                        KebeleId = k.KebeleId,
                        //DescriptionEnglish = k.DescriptionEnglish,
                        Description = (lang == "et") ? k.Description : k.DescriptionEnglish
                    })
                    .ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<List<KebeleViewModel>> GetAllKebelesBYWoredaId(string lang)
        {
            try
            {
                return await context.Kebele
                    .Select(k => new KebeleViewModel

                    {
                        WoredaId = k.WoredaId,
                        KebeleId = k.KebeleId,
                        Description = (lang == "et") ? k.Description : k.DescriptionEnglish
                    })
                    .ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<List<Kebele>> GetKebeles(object wrdId)
        {
            //KebeleLookup used to list required fields only.
            try
            {
                //IQueryable<Kebele> kebeles = context.Kebeles;
                //return await kebeles.ToListAsync();
                string id = wrdId.ToString();
                return await context.Kebele
                    .Where(wrd => wrd.WoredaId == id)
                    .Select(k => new Kebele()
                    {
                        WoredaId = k.WoredaId,
                        KebeleId = k.KebeleId,
                        DescriptionEnglish = k.DescriptionEnglish,
                        Description = k.Description
                    })
                    .ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<List<Kebele>> GetKebelesByWoredaId(object wrdId)
        {
            //KebeleLookup used to list required fields only.
            try
            {
                //IQueryable<Kebele> kebeles = context.Kebeles;
                //return await kebeles.ToListAsync();
                string id = wrdId.ToString();
                return await context.Kebele
                    .Where(wrd => wrd.WoredaId == id)
                    .Select(k => new Kebele()
                    {
                        WoredaId = k.WoredaId,
                        KebeleId = k.KebeleId,
                        DescriptionEnglish = k.DescriptionEnglish,
                        Description = k.Description
                    })
                    .Where(x => x.WoredaId == id).ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public Kebele GetKebele(object rId)
        {
            Kebele kebele = null;
            try
            {
                string id = rId.ToString();
                kebele = context.Kebele
                    .Include(r => r.Woreda)
                    .ThenInclude(z => z.Zone)
                    .Where(x => x.KebeleId == id).FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return kebele;
        }

        public async Task<List<Kebele>> GetKebeles(int page = 0, int pageSize = 15)
        {
            IQueryable<Kebele> kebele = context.Kebele
                .Include(r => r.Woreda)
                .OrderBy(zo => zo.KebeleId);
            if (page > 0)
            {
                kebele = kebele
                    .Skip((page - 1) * pageSize)
                    .Take(pageSize);
            }

            return await kebele.ToListAsync();
        }

        public async Task<List<Kebele>> GetKebelesByParent(string id, int page = 0, int pageSize = 15)
        {
            IQueryable<Kebele> kebele = context.Kebele
                .Where(r => r.WoredaId == id)
                .OrderBy(zo => zo.KebeleId);
            if (page > 0)
            {
                kebele = kebele
                    .Skip((page - 1) * pageSize)
                    .Take(pageSize);
            }

            return await kebele.ToListAsync();
        }
 
    }
}