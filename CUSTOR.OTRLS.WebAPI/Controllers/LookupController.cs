using System;
using System.Collections.Generic;
using System.IO;
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
    public class LookupController : ControllerBase
    {
        private readonly LookupRepository lRepository;
        private readonly IHostingEnvironment host;
        public LookupController(LookupRepository rep, IHostingEnvironment host)
        {
            lRepository = rep;
            this.host = host;
        }
        [HttpGet("{lang}/{id}")]
        public async Task<List<LookupDTO>> Getlookup(string lang, int id)
        {
            return await lRepository.GetLookups(lang, id);
        }
    }
}