
using CUSTOR.API.ExceptionFilter;
using CUSTOR.OTRLS.Core;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CUSTOR.OTRLS.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [ServiceFilter(typeof(ApiExceptionFilter))]
    [EnableCors("CorsPolicy")]
   

    public class MajorDivisionController: Controller
    {       

        private MajorDivisionRepository MajorDivisionRepo;
        private readonly IHostingEnvironment host;


        public MajorDivisionController(MajorDivisionRepository MajorDivisionRepo, IHostingEnvironment host)
        {
            this.MajorDivisionRepo = MajorDivisionRepo;
            this.host = host;
        }

        /// <summary>
        /// Returns all Active Major divisons
        /// </summary>
        /// <param name="lang"></param>
        /// <returns></returns>
        [HttpGet("{lang}")]
        //[Authorize(Authorization.Policies.ViewAllInvestorsPolicy)]
        public async Task<IEnumerable<MajorDivisionDTO>> GetMajorDivisions(string lang)
        {           
            return await MajorDivisionRepo.GetRecords(lang);
        }      
        
    }
}
