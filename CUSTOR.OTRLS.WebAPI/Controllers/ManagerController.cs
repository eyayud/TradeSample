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
    public class ManagerController : ControllerBase
    {
        private readonly ManagerRepository mRepository;
        private readonly IHostingEnvironment host;
        public ManagerController(ManagerRepository rep, IHostingEnvironment host)
        {
            mRepository = rep;
            this.host = host;
        }

        [HttpGet("{id:int}")]
        public async Task<ManagerDTO> GetManagerById(int id)
        {
            return await mRepository.GetManager(id);
        }
        [HttpPost]
        public async Task<ManagerDTO> PostManager([FromBody] ManagerDTO managerDTO)
        {
            ManagerDTO mgr = null;

            try
            {
                mgr = await mRepository.SaveManager(managerDTO);
            }
            catch (Exception ex)
            {
                throw new ApiException(ex.Message);
            }
            if (!string.IsNullOrEmpty(managerDTO.PhotoData))
            {
                // Create photo file
                var photoPath = Path.Combine(host.WebRootPath, "photo");
                if (!Directory.Exists(photoPath))
                    Directory.CreateDirectory(photoPath);
                var fileName = "Mgr" + mgr.ManagerId.ToString() + ".jpg"; //put "Mgr" as constant in config file
                var filePath = Path.Combine(photoPath, fileName);

                using (FileStream fs = new FileStream(filePath, FileMode.Create))
                {
                    using (BinaryWriter bw = new BinaryWriter(fs))
                    {
                        byte[] data = Convert.FromBase64String(managerDTO.PhotoData);
                        bw.Write(data);
                        bw.Close();
                    }
                }

            }
            return mgr;
        }

        [HttpGet("GetManagerByCustomerId/{id}")]
        public async Task<List<ManagerListDTO>> GetManagerByCustomerId([FromRoute] int id)
        {
            return await mRepository.GetManagerByCustomerId(id);
  
        }
    }
}