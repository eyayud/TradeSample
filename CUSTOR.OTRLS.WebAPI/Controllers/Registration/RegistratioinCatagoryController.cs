using System.Collections.Generic;
using System.Threading.Tasks;
using CUSTOR.API.ExceptionFilter;
using CUSTOR.OTRLS.Core;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;

namespace EIC.Investment.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [ServiceFilter(typeof(ApiExceptionFilter))]
    [EnableCors("CorsPolicy")]
    public class RegistrationCatagoryController : Controller
    {
        private readonly IHostingEnvironment host;
        private RegistrationCatagoryRepository regCatagoryRepo;

        public RegistrationCatagoryController(IHostingEnvironment host, RegistrationCatagoryRepository RegCatagoryRepo)
        {
            this.regCatagoryRepo = RegCatagoryRepo;
            this.host = host;
        }



        /// <summary>
        /// Returns list of activites from major divisions that a given registratioin participates
        /// </summary>
        /// <param name="Tin"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("{Tin}")]
        public async Task<IActionResult> GetRegistrationCatagoryController([FromRoute] string Tin)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var registrationcatagory = regCatagoryRepo.GetRegistrationCatagoryByTIN(Tin);
            if (registrationcatagory == null)
            {
                return NotFound();
            }
            return Ok(registrationcatagory);
        }

               
        //[HttpPost]
        //public async RegistrationCatagory PostRegistraionCatagory([FromBody] RegistrationCatagory registrationCatagory)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }
        //    return await regCatagoryRepo.SaveRegistrationCatagory(registrationCatagory);
        //}


            /// <summary>
            /// This function helps to delete registration catogory for a given Tin
            /// </summary>
            /// <param name="Tin"></param>
            /// <returns></returns>
        [HttpDelete("{Tin}")]
        public async Task<IActionResult> DeleteRegistration([FromRoute] string Tin)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var registration = regCatagoryRepo.DeleteRegistrationCatagory(Tin);
            if (registration == null)
            {
                return NotFound();
            }           
            return Ok(registration);
        }
    }
}