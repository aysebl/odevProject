using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Odev.Core.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Odev.Controllers
{
    public abstract class BaseController<T> : ControllerBase
    {
        protected IActionResult APIResponse(ServiceResponse response)
        {
            switch (response.Code)
            {
                case StatusCodes.Status200OK:
                    return Ok(response);
                case StatusCodes.Status400BadRequest:
                    return BadRequest(new { response.Message });
                case StatusCodes.Status401Unauthorized:
                    return Unauthorized(new { response.Message });
                case StatusCodes.Status403Forbidden:
                    return StatusCode(StatusCodes.Status403Forbidden, new { response.Message });
                case StatusCodes.Status404NotFound:
                    return NotFound(new { response.Message });
                default:
                    return StatusCode(StatusCodes.Status500InternalServerError, new { response.Errors, response.Message });
            }
        }

    }
}
