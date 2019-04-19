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
    public class BusinessController : ControllerBase
    {
        private readonly BusinessRepository bRepository;
        private readonly IHostingEnvironment host;
        public BusinessController(BusinessRepository rep, IHostingEnvironment host)
        {
            bRepository = rep;
            this.host = host;
        }


        [HttpPost]
        public async Task<BussinessDTO> PostBussiness([FromBody] BussinessDTO bussinessDTO)
        {
            BussinessDTO buss = null;

            try
            {
                buss = await bRepository.SaveBussiness(bussinessDTO);
                return buss;
            }
            catch (Exception ex)
            {
                throw new ApiException(ex.Message);
            }
        }

        [HttpGet("GetCommerialRegistration/{tin}")]
        public async Task<BussinessDTO> GetCommerialRegistration(string tin)
        {
            var k = await bRepository.GetCommerialRegistration(tin); 
            return await bRepository.GetCommerialRegistration(tin);

        }

       
    }
}