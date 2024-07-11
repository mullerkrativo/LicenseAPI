using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Reliance.Core.Interfaces;
using Reliance.Model;

namespace RelianceLicenseApp.Area.Admin.Controllers
{
    [ApiController]
    [ApiVersion("1.0")]
    [Area("Admin")]
    [Route("api/[controller]/{v:apiVersion}/")]
    public class SuperUserController : ControllerBase
    {
        private ISuperUserService _superUserService;
        public SuperUserController(ISuperUserService superUserService)
        {
            _superUserService = superUserService;
        }
        [AllowAnonymous]
        [HttpGet("GetAllLicense")]
        public IActionResult GetAllLicense()
        {
            try
            {
                var AllLicense = _superUserService.GetAllLicense();
                return Ok(AllLicense);
            }
            catch (Exception)
            {
                throw;
            }
        }
        [AllowAnonymous]
        [HttpPost("CreateLicense")]
        public IActionResult CreateLicense(Licensetable model)
        {
            try
            {
                var createlicensekey = _superUserService.CreateLicense(model);
                return Ok(createlicensekey);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
