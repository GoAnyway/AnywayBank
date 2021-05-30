using System.Collections.Generic;

namespace Data.Models.UtilModels.ErrorModels
{
    public abstract class BaseErrorModel
    {
        public int Code { get; set; }
        public string Message { get; set; }

        public static TError Create<TError>(int code, string message)
            where TError : BaseErrorModel, new()
        {
            var error = new TError
            {
                Code = code,
                Message = message
            };
            error.Init();
            return error;
        }

        public static TError Create<TError>(int code, IEnumerable<string> messages)
            where TError : BaseErrorModel, new()
        {
            var error = new TError
            {
                Code = code,
                Message = string.Join(",", messages)
            };
            error.Init();
            return error;
        }

        protected abstract void Init();
    }
}