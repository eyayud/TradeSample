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

    public class GroupController : ControllerBase
    {
        private readonly GroupRepository gRepository;
        private readonly IHostingEnvironment host;
        public GroupController(GroupRepository rep, IHostingEnvironment host)
        {
            gRepository = rep;
            this.host = host;
        }
        /// <summary>
        /// Get List Of Group by MajorGroupId 
        /// </summary>
        /// <param name="lang"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{lang}/{id}")]
        public async Task<List<GroupViewModel>> GetGroup(string lang, int id)
        {
            return await gRepository.GetGroupByMajorGroupCode(id);
        }
    }
}