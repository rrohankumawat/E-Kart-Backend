using EKart.Application.Commands.UserCommands;
using EKart.Core.DTOs;
using EKart.Core.Generics;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using static EKart.Application.Queries.ProductQueries.ProductQueries;

namespace E_Kart_Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController(IMediator mediator) : ControllerBase
    {
        [HttpPost("pagination-by-pageno")]
        public async Task<IActionResult> PaginationByPageNumber(int pagenumber, int pagesize)
        {
            Stopwatch sw = Stopwatch.StartNew();

            var result = await mediator.Send(new GetProductByPaginationQuery(pagenumber, pagesize));
            sw.Stop();
            try
            {
                return Ok(new { Time=sw.ElapsedMilliseconds, Result = result});
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        [HttpPost("pagination-by-cursor")]
        public async Task<IActionResult> PaginationByCursor(int lastId, int pagesize)
        {
            Stopwatch sw = Stopwatch.StartNew();
            var result = await mediator.Send(new GetProductByCursorQuery(lastId, pagesize));
            sw.Stop();
            try
            {
                return Ok(new {TimeDuration = sw.ElapsedMilliseconds,Result = result});
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
