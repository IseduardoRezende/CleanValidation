namespace CleanValidation.Core.Results
{
    public class SuccessResult : Result
    {
        private SuccessResult() : base(success: true) { }

        public static SuccessResult Create()
        {
            return new SuccessResult();
        }
    }

    public class SuccessResult<T> : Result<T>
    {
        private SuccessResult(T? value) : base(value, success: true) { }

        public static SuccessResult<T> Create(T? value)
        {
            return new SuccessResult<T>(value);
        } 
    }
}
