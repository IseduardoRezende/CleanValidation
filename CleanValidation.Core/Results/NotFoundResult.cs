using CleanValidation.Core.Errors;

namespace CleanValidation.Core.Results
{
    public class NotFoundResult : Result
    {
        private NotFoundResult(IEnumerable<Error> errors) : base(success: false)
        {
            Errors = errors;
        }

        private NotFoundResult(Error error) : this([error]) { }

        public IEnumerable<Error> Errors { get; }

        public static NotFoundResult Create(IEnumerable<Error> errors)
        {
            return new NotFoundResult(errors);
        }

        public static NotFoundResult Create(Error error)
        {
            return new NotFoundResult(error);
        }
    }

    public class NotFoundResult<T> : Result<T>
    {
        private NotFoundResult(IEnumerable<Error> errors) : base(default, success: false)
        {
            Errors = errors;
        }

        private NotFoundResult(Error error) : this([error]) { }

        public IEnumerable<Error> Errors { get; }

        public static NotFoundResult<T> Create(IEnumerable<Error> errors)
        {
            return new NotFoundResult<T>(errors);
        }

        public static NotFoundResult<T> Create(Error error)
        {
            return new NotFoundResult<T>(error);
        }       
    }
}
