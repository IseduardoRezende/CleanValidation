using CleanValidation.Core.Errors;

namespace CleanValidation.Core.Results
{
    public class InvalidResult : IResult
    {
        protected InvalidResult(IEnumerable<Error> errors)
        {
            Errors = errors;
        }

        protected InvalidResult(Error error) : this([error]) { }

        public IEnumerable<Error> Errors { get; }

        public bool Success { get { return false; } }

        public static InvalidResult Create(IEnumerable<Error> errors)
        {
            return new InvalidResult(errors);
        }

        public static InvalidResult Create(Error error)
        {
            return new InvalidResult(error);
        }
    }

    public class InvalidResult<T> : InvalidResult, IResult<T>
    {
        protected InvalidResult(IEnumerable<Error> errors) : base(errors) { }

        protected InvalidResult(Error error) : base(error) { }

        public T? Value { get { return default; } }

        new public static InvalidResult<T> Create(IEnumerable<Error> errors)
        {
            return new InvalidResult<T>(errors);
        }

        new public static InvalidResult<T> Create(Error error)
        {
            return new InvalidResult<T>(error);
        }
    }
}
