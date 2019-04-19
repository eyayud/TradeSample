using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CUSTOR.API.ExceptionFilter;
using CUSTOR.OTRLS.Core;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;

namespace CUSTOR.OTRLS.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [ServiceFilter(typeof(ApiExceptionFilter))]
    [EnableCors("CorsPolicy")]

    public class RegistrationController : Controller
    {
        private readonly IHostingEnvironment host;
        private RegistrationRepository RegistrationRepo;
        private RegistrationCatagoryRepository regCatagoryRepo;
        /// <summary>
        /// This API helps to manuplate main registration
        /// </summary>
        /// <param name="host"></param>
        /// <param name="registrationRepo"></param>
        /// <param name="RegCatagoryRepo"></param>
        public RegistrationController(IHostingEnvironment host, RegistrationRepository registrationRepo, RegistrationCatagoryRepository RegCatagoryRepo)
        {
            this.host = host;
            RegistrationRepo = registrationRepo;
            regCatagoryRepo = RegCatagoryRepo;
        }

        /// <summary>
        /// /// Gets registration by ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id:int}")]
        public async Task<Registration> GetRegistration(int id)
        {
            return await RegistrationRepo.GetRecord(id);
        }

        /// <summary>
        /// Gets registration by tin
        /// expectes 10 digit Tin number as a parameter
        /// </summary>
        /// <param name="Tin"></param>
        /// <returns></returns>
        [HttpGet("GetRegistrationByTin/{Tin}")]
        public async Task<IEnumerable<Registration>> GetRegistrationByTIN(string Tin)
        {
            return await RegistrationRepo.GetRecordByTIN(Tin);
        }

        /// <summary>
        /// Saves Registration 
        /// </summary>
        /// <param name="postedRegistration"></param>
        /// <returns></returns>

        [HttpPost]
        public async Task<Registration> SaveRegistration([FromBody] Registration postedRegistration)
        {
            return await RegistrationRepo.SaveRegistration(postedRegistration);
        }


        /// <summary>
        /// Updates registration
        /// </summary>
        /// <param name="editedRegistration"></param>
        /// <returns></returns>
        [HttpPut]
        public async Task<Registration> UpdateRegistration([FromBody] Registration editedRegistration)
        {
            return await RegistrationRepo.UpdateRegistration(editedRegistration);
        }


        /// <summary>
        /// This API uses to remove registration
        /// </summary>
        /// <param name="Tin"></param>
        /// <returns></returns>
        [HttpDelete("{id:int}")]
        public async Task<bool> DeleteRegistration(string Tin)
        {
            return await RegistrationRepo.DeleteRegistration(Tin);
        }
    }
}