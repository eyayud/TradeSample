
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

    public class LegalStatusController : Controller
    {       

        private LegalStatusRepository LegalStatusRepo;
        private readonly IHostingEnvironment host;


        public LegalStatusController(LegalStatusRepository LegalStatusRepo, IHostingEnvironment host)
        {
            this.LegalStatusRepo = LegalStatusRepo;
            this.host = host;
        }


        /// <summary>
        /// This API will get all active legal status based on language.
        /// </summary>
        /// <remarks>This API will get all active legal status based on language.</remarks>
        /// <param name="lang"></param>

        [HttpGet("{lang}")]      
        public async Task<IEnumerable<LegalStatusDTO>> GetLegalStatuses(string lang)
        {           
            return await LegalStatusRepo.GetRecords(lang);
        }      
        
    }
}
