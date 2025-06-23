using CleanValidation.Core.Errors;

namespace CleanValidation.Core.Results
{
    public class NotFoundResult : IResult
    {
        protected NotFoundResult(IEnumerable<Error> errors)
        {
            Errors = errors;
        }

        protected NotFoundResult(Error error) : this([error]) { }

        public IEnumerable<Error> Errors { get; }

        public bool Success { get { return false; } }

        public static NotFoundResult Create(IEnumerable<Error> errors)
        {
            return new NotFoundResult(errors);
        }

        public static NotFoundResult Create(Error error)
        {
            return new NotFoundResult(error);
        }
    }

    public class NotFoundResult<T> : NotFoundResult, IResult<T>
    {
        protected NotFoundResult(IEnumerable<Error> errors) : base(errors) { }

        protected NotFoundResult(Error error) : base(error) { }

        public IEnumerable<Error> Errors { get; }

        public T? Value { get { return default; } }

        new public static NotFoundResult<T> Create(IEnumerable<Error> errors)
        {
            return new NotFoundResult<T>(errors);
        }

        new public static NotFoundResult<T> Create(Error error)
        {
            return new NotFoundResult<T>(error);
        }       
    }
}
