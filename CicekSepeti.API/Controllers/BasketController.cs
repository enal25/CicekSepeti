using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CicekSepeti.Model.Entities;
using CicekSepeti.Model.Models;
using Microsoft.AspNetCore.Mvc;
using CicekSepeti.Business.Services.Abstract;
using Common.Constants;
using Common.Resources;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CicekSepeti.API.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class BasketController : Controller
    {
        IBasketService basketService;

        public BasketController(IBasketService basketService)
        {
            this.basketService = basketService;
        }

        [HttpPost("AddToBasket")]
        public async Task<ActionResult> Post([FromBody] BasketItem basketItem)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            string result = await basketService.AddToBasket(basketItem);

            if (result != ResourceHelper.ReadFromResource(CommonErrorCodes.OK))
                return BadRequest(new { error_description = result });

            return Ok();
        }
        
    }
}
