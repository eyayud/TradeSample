using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CUSTOR.API.ExceptionFilter;
using CUSTOR.OTRLS.Core;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CUSTOR.OTRLS.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [ServiceFilter(typeof(ApiExceptionFilter))]
    [EnableCors("CorsPolicy")]
    public class ZoneController : ControllerBase
    {
        private readonly ZoneRepository zRepository;
        private readonly IHostingEnvironment host;
        public ZoneController(ZoneRepository rep, IHostingEnvironment host)
        {
            zRepository = rep;
            this.host = host;
        }
        [HttpGet("{lang}")]
        public async Task<List<ZoneViewModel>> GetZones(string lang)
        {
            return await zRepository.GetAllZones(lang);
        }
    }
}