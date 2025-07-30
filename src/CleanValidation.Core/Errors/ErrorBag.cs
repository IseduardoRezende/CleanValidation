using CleanValidation.Core.Exceptions;

namespace CleanValidation.Core.Errors
{
    public class ErrorBag
    {
        private readonly List<Error> _errors = [];

        public void Add(Error error)
        {
            CleanValidationException.ThrowIfNull(error);

            _errors.Add(error);
        }

        public int Count { get { return _errors.Count; } }

        public List<Error> Errors { get { return _errors; } }
    }
}
