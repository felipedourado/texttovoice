using Microsoft.AspNetCore.Http;
using TextToVoice.Domain.Exceptions;
using TextToVoice.Domain.Interfaces.Repositories;
using TextToVoice.Domain.Interfaces.Services;
using TextToVoice.Domain.Models;

namespace TextToVoice.Service.Services
{
    public class TextToVoiceService : ITextToVoiceService
    {
        private readonly IAwsPollyRepository _awsPollyRepository;
        public TextToVoiceService(IAwsPollyRepository awsPollyRepository) => _awsPollyRepository= awsPollyRepository;
        
        public async Task<ConversationResponseModel> AudioBase64(ConversationRequestModel request)
        {

            if (string.IsNullOrEmpty(request.Message))
                throw new HttpReturnException(StatusCodes.Status400BadRequest, ValidationErrorModel.MountErrorList("Texto inválido!"));

            var result = await _awsPollyRepository.SynthesizeSpeech(request.Message);

            return new ConversationResponseModel
            {
                AudioBase64 = result
            };
        }

    }
}
