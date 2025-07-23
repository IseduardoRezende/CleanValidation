using CleanValidation.Core.Exceptions;

namespace CleanValidation.Core.Errors
{
    public class ErrorBag
    {
        private readonly List<Error> _errors = [];

        public void Add(Error error)
        {
            if (error is null)
                throw new CleanValidationException($"{nameof(error)} can't be null.");

            _errors.Add(error);
        }

        public int Count { get { return _errors.Count; } }

        public List<Error> Errors { get { return _errors; } }
    }
}
