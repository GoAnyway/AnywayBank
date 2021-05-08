﻿namespace Models.UtilModels
{
    public class ResultModel<TData>
    {
        public ResultModel(bool success)
        {
            Success = success;
        }

        public ResultModel(bool success, ErrorModel error)
        {
            Success = success;
            Error = error;
        }

        public ResultModel(bool success, TData data)
        {
            Success = success;
            Data = data;
        }

        public bool Success { get; set; }
        public ErrorModel Error { get; set; }
        public TData Data { get; set; }

        public static ResultModel<TData> Ok(TData data) =>
            new ResultModel<TData>(true, data);

        public static ResultModel<TData> BadResult(int code, string message) =>
            new ResultModel<TData>(false, new ErrorModel(code, message));

        public static ResultModel<TData> Copy<T>(ResultModel<T> result) =>
            new ResultModel<TData>(result.Success, result.Error);
    }
}