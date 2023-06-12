using Microsoft.AspNetCore.Mvc;
using TextToVoice.Domain.Exceptions;
using TextToVoice.Domain.Interfaces.Services;
using TextToVoice.Domain.Models;

namespace TextToVoice.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TextToVoiceController : ControllerBase
    {
        private readonly ITextToVoiceService _textToVoiceService;
        public TextToVoiceController(ITextToVoiceService textToVoiceService) => _textToVoiceService = textToVoiceService;

        [HttpPost("audioBase64")]
        [ProducesResponseType(typeof(ValidationErrorModel), StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(typeof(ValidationErrorModel), StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<ConversationResponseModel>> Conversation(ConversationRequestModel request)
        {
            try
            {
                var response = await _textToVoiceService.AudioBase64(request);

                return response;
            }
            catch (Exception)
            {
                throw;
            }

        }

        //[HttpPost("download-mp3")]
        //public IEnumerable<WeatherForecast> Get(ConversationRequestModel request)
        //{
           
        //}
    }
}
