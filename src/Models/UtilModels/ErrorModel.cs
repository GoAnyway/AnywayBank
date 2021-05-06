using System.Collections.Generic;

namespace Models.UtilModels
{
    public class ErrorModel
    {
        public ErrorModel(int code, string message)
        {
            Code = code;
            Message = message;
        }

        public ErrorModel(int code, IEnumerable<string> messages)
        {
            Code = code;
            Message = string.Join(", ", messages);
        }

        public int Code { get; set; }
        public string Message { get; set; }
    }
}