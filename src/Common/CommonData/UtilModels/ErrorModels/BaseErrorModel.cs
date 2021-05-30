using System.Collections.Generic;
using CommonData.UtilModels.ErrorModels.Enums;

namespace CommonData.UtilModels.ErrorModels
{
    public abstract class BaseErrorModel
    {
        public int Code { get; set; }
        public string Message { get; set; }

        public static TError Create<TError>(int code, string message)
            where TError : BaseErrorModel, new() =>
            CreateInternal<TError>(code, string.Join(",", message));

        public static TError Create<TError>(ErrorCode code, string message)
            where TError : BaseErrorModel, new() =>
            CreateInternal<TError>((int) code, string.Join(",", message));

        public static TError Create<TError>(int code, IEnumerable<string> messages)
            where TError : BaseErrorModel, new() =>
            CreateInternal<TError>(code, string.Join(",", messages));

        public static TError Create<TError>(ErrorCode code, IEnumerable<string> messages)
            where TError : BaseErrorModel, new() =>
            CreateInternal<TError>((int) code, string.Join(",", messages));

        private static TError CreateInternal<TError>(int code, string message)
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

        protected abstract void Init();
    }
}