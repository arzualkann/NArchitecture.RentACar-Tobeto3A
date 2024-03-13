using Application.Features.Brands.Dtos;
using Application.Features.Brands.Queries.GetById;
using Application.Features.Brands.Queries.Getlist;
using Application.Features.Cars.Commands.Create;
using Application.Features.Cars.Commands.Delete;
using Application.Features.Cars.Commands.Update;
using Application.Features.Cars.Queries.GetById;
using Application.Features.Cars.Queries.GetList;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarsController : BaseController
    {
        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAllAsync()
        {
            return Ok(await Mediator.Send(new GetAllCarQuery()));
        }
        [HttpGet("GetById")]
        public async Task<IActionResult> GetByIdAsync([FromQuery] GetByIdCarQuery query)
        {
            return Ok(await Mediator.Send(query));
        }
        [HttpPost("Add")]
        public async Task<IActionResult>AddAsync([FromBody] CreateCarCommand command)
        {
            return Created("", await Mediator.Send(command));
        }
        [HttpDelete("Delete")]
        public async Task<IActionResult> DeleteAsync([FromBody] DeleteCarCommand command)
        {
            return Ok(await Mediator.Send(command));
        }
        [HttpPut("Update")]
        public async Task<IActionResult> UpdateAsync([FromBody]UpdateCarCommand command)
        {
            return Ok(await Mediator.Send(command));
        }
    }
}
