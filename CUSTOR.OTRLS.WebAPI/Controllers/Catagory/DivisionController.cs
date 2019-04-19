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

    public class DivisionController : ControllerBase
    {
        private readonly DivisionRepository dRepository;
        private readonly IHostingEnvironment host;
        public DivisionController(DivisionRepository rep, IHostingEnvironment host)
        {
            dRepository = rep;
            this.host = host;
        }
        /// <summary>
        /// Get List Of Division By MajorDivisionid
        /// </summary>
        /// <param name="lang"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{lang}/{id}")]
        public async Task<List<DivisionViewModel>> GetDivision(string lang,int id)
        {
            return await dRepository.GetDivisionByMajorDivisionid(id);
        }
    }
}
