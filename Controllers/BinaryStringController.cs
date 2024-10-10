using dan_storbaek_server.Domains;
using dan_storbaek_server.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace dan_storbaek_server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BinaryStringController : ControllerBase
    {
        private readonly IBinaryStringService _binaryStringService;
        public BinaryStringController(IBinaryStringService binaryStringService)
        {
            _binaryStringService = binaryStringService;
        }
        [HttpPost("[action]")]
        public IActionResult AnalyzeBinaryString([FromBody] BinaryStringModel model )
        {
            BinaryStringStatus status = _binaryStringService.Analyze(model.BinaryString);
            return Ok(status);
        }
    }
}
