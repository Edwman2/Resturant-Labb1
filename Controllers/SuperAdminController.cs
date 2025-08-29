using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Resturant_Labb1.DTOs.RequestDTOs;
using Resturant_Labb1.DTOs.ResponseDTOs;
using Resturant_Labb1.Services;
using Resturant_Labb1.Services.IServices;

namespace Resturant_Labb1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SuperAdminController : ControllerBase
    {
        private readonly ISuperAdminService _adminService;

        public SuperAdminController(ISuperAdminService adminService)
        {
            _adminService = adminService;
        }

        [HttpPost]
        public async Task<ActionResult<SuperAdminDTO>> RegisterAsync(RegisterSuperAdminDTO registerSuperAdminDTO)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var created = await _adminService.RegisterAsync(registerSuperAdminDTO);


            return Ok(created);
        }

        [HttpPost("Login")]
        public async Task<ActionResult> LoginAsync(LoginDTO loginDTO)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var success = await _adminService.LoginAsync(loginDTO);

            if(!success)
            {
                return Unauthorized(new { Message = "Invalid username och password" });
            }

            return Ok(new { message = "Login successful" });

        }

        

    }
}
