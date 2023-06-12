namespace TextToVoice.Domain.Exceptions
{
    public class ValidationErrorModel
    {
        public string Mensagem { get; set; }
        public DateTime Data { get; set; }

        public ValidationErrorModel(string mensagem, DateTime data)
        {
            Mensagem = mensagem;
            Data = data;
        }

        public ValidationErrorModel(string mensagem)
        {
            Mensagem = mensagem;
            Data = DateTime.Now;
        }

        public ValidationErrorModel()
        {
        }

        public static IList<ValidationErrorModel> MountErrorList(string message)
        {
            return new List<ValidationErrorModel>
            {
                new ValidationErrorModel(message)
            };
        }

        public static IList<ValidationErrorModel> MountErrorList(List<string> messages)
        {
            var list = new List<ValidationErrorModel>();
            messages.ForEach(x => list.Add(new ValidationErrorModel(x)));
            return list;
        }

        public static string MountStringError(HttpReturnException ex)
        {
            var errors = (List<ValidationErrorModel>)ex.Body;
            var errorStr = errors.Select(err => err.Mensagem).Aggregate((i, j) => i + " | " + j);
            return errorStr;
        }
    }
}
