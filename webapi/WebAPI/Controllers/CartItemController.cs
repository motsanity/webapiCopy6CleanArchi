using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using webapi.AppService.DTO.DTOCartItem;
using webapi.CQRS.Command.CommandCartItem;
using webapi.CQRS.Query.QueryItem;
using webapi.CQRS.ViewModels;
using webapi.Infrastructure.Database.Entities;
using webapi.WebAPI.Common;
using UpdateCartItemDTO = webapi.AppService.DTO.DTOCartItem.UpdateCartItemDTO;

namespace webapi.WebAPI.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class CartItemController : BaseController
    {

        //added 5:02 1/24/2023
        public CartItemController(IMediator mediator, IMapper mapper) : base(mediator, mapper)
        {
        }

        [HttpPost("Add-Cart-Item")]
        public async Task<IActionResult> AddCartItem([FromBody] AddCartItemDTO dto)
        {
            return await Handle<AddCartItemDTO, AddCartItemCommand, Guid>(dto); 
        }

        
        [HttpPut("Update-Cart-Item")]
        public async Task<IActionResult> UpdateCartItem([FromBody] UpdateCartItemDTO dto)
        {
            return await Handle<UpdateCartItemDTO, UpdateCartItemCommand, object>(dto); 
        }

        [HttpGet("Get-All-Pending-Cart-Item")]
        public async Task<IActionResult> GetAllCartItems()
        {
            return await Handle<IEnumerable<CartItemViewModel>>(new GetAllCartItemsQuery());
        }

        [HttpDelete("Delete-Cart-Item")]
        public async Task<IActionResult> DeleteCartItem([FromQuery] DeleteCartItemCommand dto)
        {
                         //use UpdateCartItemDTO since they almost share the same method/properties
            return await Handle<UpdateCartItemDTO, DeleteCartItemCommand, object>(dto);
        }

    }
}
