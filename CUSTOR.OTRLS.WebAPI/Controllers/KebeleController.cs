using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CUSTOR.API.ExceptionFilter;
using CUSTOR.OTRLS.Core;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;

namespace CUSTOR.OTRLS.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [ServiceFilter(typeof(ApiExceptionFilter))]
    [EnableCors("CorsPolicy")]
    public class KebeleController : ControllerBase
    {
        private readonly KebeleRepository kRepository;
        private readonly IHostingEnvironment host;
        public KebeleController(KebeleRepository rep, IHostingEnvironment host)
        {
            kRepository = rep;
            this.host = host;
        }
        [HttpGet("{lang}")]
        public async Task<List<KebeleViewModel>> GetKebeles(string lang)
        {
            return await kRepository.GetAllKebeles(lang);
        }

        [HttpGet("{lang}/{id}")]
        public async Task<List<KebeleViewModel>> GetKebelesById(string lang, string id)
        {
            return await kRepository.GetKebelesByWoredaId(lang, id);
        }
    }
}