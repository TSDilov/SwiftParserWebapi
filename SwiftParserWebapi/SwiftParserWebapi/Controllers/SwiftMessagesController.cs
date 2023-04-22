using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
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
        [SwaggerOperation(
            Summary = "Swift MT799 parser",
            Description = "Parses files from Swift MT799.",
            OperationId = "AddMessage"
        )]
        public async Task<IActionResult> Post(IFormFile file)
        {
            var messageText = ReadText(file);
            this.logger.LogInformation($"Trying to parse message: {messageText}");
            try
            {
                await this.swiftParserService.ParseSwiftMessage(messageText);
            }
            catch(SwiftInvalidMessageException ex)
            {
                this.logger.LogError(ex, "Error in parsing file.");
                return BadRequest(ex.Message);
            }

            this.logger.LogInformation("Successful parse!");
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