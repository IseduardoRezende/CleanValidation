using CleanValidation.Core.Errors;

namespace CleanValidation.Core.Results
{
    public class ConflictResult : Result
    {
        private ConflictResult(IEnumerable<Error> errors) : base(success: false)
        {
            Errors = errors;
        }

        private ConflictResult(Error error) : this([error]) { }

        public IEnumerable<Error> Errors { get; }

        public static ConflictResult Create(IEnumerable<Error> errors)
        {
            return new ConflictResult(errors);
        }

        public static ConflictResult Create(Error error)
        {
            return new ConflictResult(error);
        }
    }

    public class ConflictResult<T> : Result<T>
    {
        private ConflictResult(IEnumerable<Error> errors) : base(default, success: false)
        {
            Errors = errors;
        }

        private ConflictResult(Error error) : this([error]) { }

        public IEnumerable<Error> Errors { get; }

        public static ConflictResult<T> Create(IEnumerable<Error> errors)
        {
            return new ConflictResult<T>(errors);
        }

        public static ConflictResult<T> Create(Error error)
        {
            return new ConflictResult<T>(error);
        }
    }
}
