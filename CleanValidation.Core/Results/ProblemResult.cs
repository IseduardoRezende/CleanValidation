using CleanValidation.Core.Errors;

namespace CleanValidation.Core.Results
{
    public class ProblemResult : Result
    {
        private ProblemResult(IEnumerable<Error> errors) : base(success: false)
        {
            Errors = errors;
        }

        private ProblemResult(Error error) : this([error]) { }

        public IEnumerable<Error> Errors { get; }

        public static ProblemResult Create(IEnumerable<Error> errors)
        {
            return new ProblemResult(errors);
        }

        public static ProblemResult Create(Error error)
        {
            return new ProblemResult(error);
        }
    }

    public class ProblemResult<T> : Result<T>
    {
        private ProblemResult(IEnumerable<Error> errors) : base(default, success: false)
        {
            Errors = errors;
        }

        private ProblemResult(Error error) : this([error]) { }

        public IEnumerable<Error> Errors { get; }

        public static ProblemResult<T> Create(IEnumerable<Error> errors)
        {
            return new ProblemResult<T>(errors);
        }

        public static ProblemResult<T> Create(Error error)
        {
            return new ProblemResult<T>(error);
        }
    }
}
