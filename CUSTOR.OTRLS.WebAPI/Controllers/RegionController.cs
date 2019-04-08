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
    public class RegionController : ControllerBase
    {
        private readonly RegionRepository rRepository;
        private readonly IHostingEnvironment host;
        public RegionController(RegionRepository rep, IHostingEnvironment host)
        {
            rRepository = rep;
            this.host = host;
        }
        [HttpGet("{lang}")]
        public async Task<List<RegionViewModel>> GetRegions(string lang)
        {
            return await rRepository.GetRegions(lang);
        }
    }
}