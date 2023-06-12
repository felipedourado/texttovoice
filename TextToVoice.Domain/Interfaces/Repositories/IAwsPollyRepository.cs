namespace TextToVoice.Domain.Interfaces.Repositories
{
    public interface IAwsPollyRepository
    {
        Task<byte[]> SynthesizeSpeech(string text);
    }
}
