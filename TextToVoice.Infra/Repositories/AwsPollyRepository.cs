using Amazon.Polly;
using Amazon.Polly.Model;
using Amazon.Runtime;
using Microsoft.Extensions.Configuration;
using TextToVoice.Domain.Interfaces.Repositories;

namespace TextToVoice.Infra.Repositories
{
    public class AwsPollyRepository : IAwsPollyRepository
    {
        private readonly IConfiguration _configuration;

        public AwsPollyRepository(IConfiguration configuration) => _configuration = configuration;
        
        public async Task<byte[]> SynthesizeSpeech(string text)
        {
            var apiKey = _configuration.GetSection("AwsSettings:ApiKey").Value;
            var secretKey = _configuration.GetSection("AwsSettings:SecretKey").Value;

            var credentials = new BasicAWSCredentials(apiKey, secretKey);
            var client = new AmazonPollyClient(credentials, Amazon.RegionEndpoint.EUWest2);

            var synthesizeSpeechRequest = new SynthesizeSpeechRequest()
            {
                OutputFormat = OutputFormat.Mp3,
                VoiceId = VoiceId.Vitoria,
                Text = text,
                LanguageCode = "pt-BR"
            };

            var synthesizeSpeechResponse = await client.SynthesizeSpeechAsync(synthesizeSpeechRequest);

            return WriteSpeechToBase64(synthesizeSpeechResponse.AudioStream);
        }

        private byte[] WriteSpeechToBase64(Stream audioStream)
        {
            var memory = new MemoryStream();
            audioStream.CopyTo(memory);
            byte[] audioBase64 = memory.ToArray();

            return audioBase64;
        }
    }
}
