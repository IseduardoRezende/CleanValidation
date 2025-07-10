namespace CleanValidation.Core.Options
{
    [Flags]
    public enum IpAddressOptions
    {
        None = 0,
        DisallowLeadingZerosInIpv4 = 1,
        DisallowIpv6 = 2,
        DisallowLoopback = 4
    }
}
