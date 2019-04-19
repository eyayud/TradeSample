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
    public class SubGroupController : ControllerBase
    {
        private readonly SubGroupRepository sgRepository;
        private readonly IHostingEnvironment host;
        public SubGroupController(SubGroupRepository rep, IHostingEnvironment host)
        {
            sgRepository = rep;
            this.host = host;
        }
        /// <summary>
        /// Get List Of SubGroup list By GroupId
        /// </summary>
        /// <param name="lang"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{lang}/{id}")]
        public async Task<List<SubGroupModel>> GetSubGroup(string lang, int id)
        {
            return await sgRepository.GetSubGroupByGroupid(id);
        }
    }
}