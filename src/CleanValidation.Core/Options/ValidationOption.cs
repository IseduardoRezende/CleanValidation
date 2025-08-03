namespace CleanValidation.Core.Options
{
    /// <summary>
    /// The validation option available to configure the behavior of 
    /// <see cref="Guards.Guard"/> validations.
    /// </summary>
    public enum ValidationOption
    {
        /// <summary>
        /// Represents whether the <see cref="Guards.Guard"/> validations should continue execution 
        /// even if an <see cref="Errors.Error"/> occurs.
        /// </summary>
        /// <remarks>
        /// The operation will proceed despite
        /// encountering errors. This can be useful to accumulate errors. 
        /// </remarks>
        ContinueOnFailure,

        /// <summary>
        /// Represents whether the <see cref="Guards.Guard"/> validations should stop execution 
        /// when an <see cref="Errors.Error"/> occurs.
        /// </summary>
        /// <remarks>
        /// The operation will stop when encountering an error. 
        /// This can be useful to not accumulate errors. 
        /// </remarks>
        FailFirst
    }
}
