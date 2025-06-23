namespace CleanValidation.Core.Results
{
    public class SuccessResult : IResult
    {
        protected SuccessResult() { }
        
        public bool Success { get { return true; } }

        public static SuccessResult Create()
        {
            return new SuccessResult();
        }
    }

    public class SuccessResult<T> : SuccessResult, IResult<T>
    {
        protected SuccessResult(T? value)
        {
            Value = value;
        }

        public T? Value { get; }

        new public static SuccessResult<T> Create(T? value)
        {
            return new SuccessResult<T>(value);
        } 
    }
}
