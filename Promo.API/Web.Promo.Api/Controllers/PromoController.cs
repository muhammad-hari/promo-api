using Microsoft.AspNetCore.Mvc;
using Web.Promo.Application.Commands;
using Web.Promo.Application.Queries;
using Web.Promo.Domain.Model;

namespace Web.Promo.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PromoController : ControllerBase
    {
        private readonly IPromoQuery promoQuery;
        private readonly IPromoCommand promoCommand;

        public PromoController(IPromoQuery promoQuery, IPromoCommand promoCommand)
        {
            this.promoQuery = promoQuery;
            this.promoCommand = promoCommand;   
        }

        [HttpGet]
        //[Authorize]
        public IActionResult GetPromos(DateTime? starDate = null, DateTime? endDate = null, string orderBy = "desc")
        {
            var query = promoQuery.GetByRange(starDate, endDate, orderBy);
            if (!query.Success)
                return BadRequest(query);

            return Ok(query);
        }

        [HttpGet, Route("{id}")]
        //[Authorize]
        public IActionResult GetPromoByID(int? id)
        {
            var query = promoQuery.GetByID(id);
            if (!query.Success)
                return BadRequest(query);

            return Ok(query);
        }

        [HttpPost]
        //[Authorize]
        public async Task<IActionResult> AddPromo([FromBody] PromosModel promo)
        {
            var command = await promoCommand.CreateAsync(promo);
            if (!command.Success)
                return BadRequest(command);

            return Ok(command);
        }

        [HttpPut]
        //[Authorize]
        public async Task<IActionResult> UpdatePromo([FromBody] PromosModel promo)
        {
            var command = await promoCommand.UpdateAsync(promo);
            if (!command.Success)
                return BadRequest(command);

            return Ok(command);
        }

        [HttpDelete, Route("{promoId}/username/{username}")]
        //[Authorize]
        public async Task<IActionResult> DeletePromo(int promoId, string username)
        {
            var command = await promoCommand.DeleteAsync(promoId, username);
            if (!command.Success)
                return BadRequest(command);

            return Ok(command);
        }
    }
}