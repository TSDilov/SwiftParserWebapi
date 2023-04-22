using Microsoft.AspNetCore.Mvc;
using SwiftParserServices;
using SwiftParserServices.Exceptions;
using System.Text;

namespace SwiftParserWebapi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SwiftMessagesController : ControllerBase
    {
        private readonly ILogger<SwiftMessagesController> logger;
        private readonly ISwiftParserService swiftParserService;

        public SwiftMessagesController(ILogger<SwiftMessagesController> logger, ISwiftParserService swiftParserService)
        {
            this.logger = logger;
            this.swiftParserService = swiftParserService;
        }

        [HttpPost]
        public async Task<IActionResult> Post(IFormFile file)
        {
            var messageText = ReadText(file);
            try
            {
                await this.swiftParserService.ParseSwiftMessage(messageText);
            }
            catch(SwiftInvalidMessageException ex)
            {
                return BadRequest(ex.Message);
            }

            return Ok();
        }

        private static string ReadText(IFormFile file)
        {
            using (var streamReader = new StreamReader(file.OpenReadStream(), Encoding.UTF8))
            {
                return streamReader.ReadToEnd();
            }
        }
    }
}