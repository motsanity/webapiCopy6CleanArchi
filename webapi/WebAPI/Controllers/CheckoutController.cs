using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using webapi.AppService.DTO.DTOCheckout;
using webapi.CQRS.Command.CommandCheckout;
using webapi.WebAPI.Common;

namespace webapi.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CheckoutOrder : BaseController
    {

        //added 5:02 1/24/2023
        public CheckoutOrder(IMediator mediator, IMapper mapper) : base(mediator, mapper)
        {
        }

        [HttpPost]
        public async Task<IActionResult> CheckoutOrders([FromBody] CheckoutOrderDTO dto)
        {
            return await Handle<CheckoutOrderDTO, CheckoutOrderCommand, Guid>(dto);
        }

    }
}
