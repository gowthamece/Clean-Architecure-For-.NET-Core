using HotelBooking.Application.Feature.Hotels.Queries.GetHotelsList;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HotelBooking.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HotelsController : ControllerBase
    {
        private readonly IMediator _mediator;
        public HotelsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]

        public async Task<ActionResult<List<HotelsListVM>>> GetAllHotels()
        {
            var dtos = await _mediator.Send(new GetHotelsListQuery());
            return Ok(dtos);
        }
    }
}
