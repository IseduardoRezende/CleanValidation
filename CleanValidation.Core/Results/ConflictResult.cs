using CleanValidation.Core.Errors;

namespace CleanValidation.Core.Results
{
    public class ConflictResult : IResult
    {
        protected ConflictResult(IEnumerable<Error> errors)
        {
            Errors = errors;
        }

        protected ConflictResult(Error error) : this([error]) { }

        public IEnumerable<Error> Errors { get; }

        public bool Success { get { return false; } }

        public static ConflictResult Create(IEnumerable<Error> errors)
        {
            return new ConflictResult(errors);
        }

        public static ConflictResult Create(Error error)
        {
            return new ConflictResult(error);
        }
    }

    public class ConflictResult<T> : ConflictResult, IResult<T>
    {
        protected ConflictResult(IEnumerable<Error> errors) : base(errors) { }

        protected ConflictResult(Error error) : base(error) { }

        public T? Value { get { return default; } }

        new public static ConflictResult<T> Create(IEnumerable<Error> errors)
        {
            return new ConflictResult<T>(errors);
        }

        new public static ConflictResult<T> Create(Error error)
        {
            return new ConflictResult<T>(error);
        }
    }
}
