namespace TextToVoice.Domain.Exceptions
{
    public class HttpReturnException : Exception
    {
        public int StatusCode { get; set; }
        public object Body { get; set; }

        public HttpReturnException(int statusCode, object body)
        {
            StatusCode = statusCode;
            Body = body;
        }
    }
}
