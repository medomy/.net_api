using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FirstApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ErrorsController : ControllerBase
    {
        [Route("/error-development")]
        public IActionResult DevelopmentException([FromServices] IHostEnvironment hostEnvironment)
        {
            if (!hostEnvironment.IsDevelopment())
            {
                return NotFound();
            }
            var exceptionHandlerFeature = HttpContext.Features.Get<IExceptionHandlerFeature>()!;
            return Problem(detail: exceptionHandlerFeature.Error.StackTrace, title: exceptionHandlerFeature.Error.Message);
        }
        [Route("/error")]
        public IActionResult ErrorNotDevelopment() {
            return Problem();
        }

        // when calling this route you get the exception
        [HttpGet("throw")]
        public IActionResult About() { 
            throw new Exception("Sample Exception");
        }
    }
}
