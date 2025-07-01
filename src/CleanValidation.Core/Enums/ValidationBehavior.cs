namespace CleanValidation.Core.Enums
{
    /// <summary>
    /// Determines how guard clauses proceeds when error occour.
    /// </summary>
    public enum ValidationBehavior
    {
        /// <summary>
        /// If one guard clause fails, the validation continues to the next clause.
        /// </summary>
        Continue,
        /// <summary>
        /// If a guard clause fails, the validation process 
        /// stops. This can be useful for "fail fast" scenarios.
        /// </summary>
        Stop
    }
}
