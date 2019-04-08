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
    public class WoredaController : ControllerBase
    {
        private readonly WoredaRepository wRepository;
        private readonly IHostingEnvironment host;
        public WoredaController(WoredaRepository rep, IHostingEnvironment host)
        {
            wRepository = rep;
            this.host = host;
        }
        [HttpGet("{lang}")]
        public async Task<List<WoredaViewModel>> GetWoredas(string lang)
        {
            return await wRepository.GetAllWoredas(lang);
        }
       
    }
}