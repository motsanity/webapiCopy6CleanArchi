using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using webapi.AppService.DTO.DTOUser;
using webapi.CQRS.Command.CommandUser;
using webapi.CQRS.Query.QueryUser;
using webapi.CQRS.ViewModels;
using webapi.WebAPI.Common;

namespace webapi.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : BaseController
    {
       

        public UserController(IMediator mediator, IMapper mapper) : base(mediator, mapper)
        {
        }

        [HttpPost]
        public async Task<IActionResult> AddUser([FromBody] AddUserDTO dto)
        {
            return await Handle<AddUserDTO, AddUserCommand, Guid>(dto); //error but answered
        }

        //added 1:47PM 1/24/2023
        [HttpPut]
        public async Task<IActionResult> UpdateUser([FromBody] UpdateUserDTO dto)
        {
            return await Handle<UpdateUserDTO, UpdateUserCommand, object>(dto); 
        }

        [HttpGet]
        [Route("GetUserById")]
        public async Task<IActionResult> GetUserById([FromQuery] GetUserByIdQuery query)
        {
            return await Handle<UserViewModel>(query);
        }




    }
}
