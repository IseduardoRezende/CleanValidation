using CleanValidation.Core.Errors;

namespace CleanValidation.Core.Results
{
    public class ProblemResult : IResult
    {
        protected ProblemResult(IEnumerable<Error> errors)
        {
            Errors = errors;
        }

        protected ProblemResult(Error error) : this([error]) { }

        public IEnumerable<Error> Errors { get; }

        public bool Success { get { return false; } }

        public static ProblemResult Create(IEnumerable<Error> errors)
        {
            return new ProblemResult(errors);
        }

        public static ProblemResult Create(Error error)
        {
            return new ProblemResult(error);
        }
    }

    public class ProblemResult<T> : ProblemResult, IResult<T>
    {
        protected ProblemResult(IEnumerable<Error> errors) : base(errors) { }

        protected ProblemResult(Error error) : base(error) { }

        public IEnumerable<Error> Errors { get; }

        public T? Value { get { return default; } }

        new public static ProblemResult<T> Create(IEnumerable<Error> errors)
        {
            return new ProblemResult<T>(errors);
        }

        new public static ProblemResult<T> Create(Error error)
        {
            return new ProblemResult<T>(error);
        }
    }
}
