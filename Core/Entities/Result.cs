namespace Core.Entities
{
    public class Result
    {
        public object MyResult { get; set; }
        public bool IsSuccess { get; set; }
        public string ExceptionMessage { get; set; }
        public string SuccessMessage { get; set; }

        public static Result Ok(object result)
        {
            return new Result { MyResult = result, IsSuccess = true };
        }

        public static Result Ok(string message)
        {
            return new Result { MyResult = null, IsSuccess = true, SuccessMessage = message };
        }

        public static Result Error(string message)
        {
            return new Result { MyResult = null, IsSuccess = false, ExceptionMessage = message };
        }
    }
}
