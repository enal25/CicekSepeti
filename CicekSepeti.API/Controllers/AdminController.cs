using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CicekSepeti.Business.Services.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace CicekSepeti.API.Controllers
{
    [Route("api/[controller]")]
    public class AdminController : Controller
    {
        IAdminService adminService;

        public AdminController(IAdminService adminService)
        {
            this.adminService = adminService;
        }

        [HttpGet("{AddInitProducts}")]
        public async Task<ActionResult> Get()
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await adminService.AddInitProducts();

            if (!result)
            {
                return BadRequest(new { error_description = "an error occured on insert product." });
            }


            return Ok();
        }

    }
}
