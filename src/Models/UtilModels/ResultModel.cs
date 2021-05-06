namespace Models.UtilModels
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

        public bool Success { get; set; }
        public ErrorModel Error { get; set; }
        public TData Data { get; set; }
    }
}