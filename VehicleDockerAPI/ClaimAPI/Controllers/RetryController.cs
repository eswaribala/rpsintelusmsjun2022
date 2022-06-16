using ClaimAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ClaimAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RetryController : ControllerBase
    {
        private readonly IInvokeService _invokeService;

        public RetryController(IInvokeService invokeService)
        {
            _invokeService = invokeService;

        }
        [HttpGet]
        public async Task<IActionResult> Get(CancellationToken cancellationToken)
        {
            var result = await _invokeService.DoSomething(cancellationToken);
            return Ok(result);
        }
    }
}
