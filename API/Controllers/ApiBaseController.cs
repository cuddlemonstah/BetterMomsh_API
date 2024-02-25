using API.Extension;
using Application.Common.RequestResponse;
using Application.Common.Utilities;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApiBaseController : ControllerBase
    {
        private ISender _mediator = null!;
        protected ISender Mediator => _mediator ??= HttpContext.RequestServices.GetRequiredService<ISender>();

        protected ActionResult HandleResult<T>(Result<T> result) {
            if (result == null) {
                return NotFound();
            }
            if (result.IsSuccess && result.Value != null) {
                return Ok(result.Value);
            }
            if (result.IsSuccess && result.Value == null) {
                return NotFound();
            }
            if (result.Error != null) {
                return BadRequest(result.Error);
            }
            return BadRequest(result.Error);
        }

        protected ActionResult HandlePageResult<T>(Result<PagedList<T>> result) {
            if (result == null) return NotFound();

            if (result.IsSuccess && result.Value != null)
            {
                Response.AddPaginationHeader(result.Value.CurrentPage,
                    result.Value.PageSize,
                    result.Value.TotalCount,
                    result.Value.TotalPages
                    );

                return Ok(result.Value);
            }

            if (result.IsSuccess && result.Value == null)
                return NotFound();

            return BadRequest(result.Error);
        }
    }
}
