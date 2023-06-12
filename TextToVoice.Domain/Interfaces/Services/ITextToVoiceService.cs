using TextToVoice.Domain.Models;

namespace TextToVoice.Domain.Interfaces.Services
{
    public interface ITextToVoiceService
    {
        Task<ConversationResponseModel> AudioBase64(ConversationRequestModel request);
    }
}
