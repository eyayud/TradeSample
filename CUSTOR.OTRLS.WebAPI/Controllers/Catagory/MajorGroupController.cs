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
    public class MajorGroupController : ControllerBase
    {
        private readonly MajorGroupRepository mgRepository;
        private readonly IHostingEnvironment host;
        public MajorGroupController(MajorGroupRepository rep, IHostingEnvironment host)
        {
            mgRepository = rep;
            this.host = host;
        }
        /// <summary>
        /// Get MajorGroup list By Division Id 
        /// </summary>
        /// <param name="lang"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{lang}/{id}")]
        public async Task<List<MajorGroupModel>> GetMajorGroup(string lang, int id)
        {
            return await mgRepository.GetMajorGroupByDivisionId(id);
        }
    }
}