using System.Net;
using System.Net.Sockets;
using CleanValidation.Core.Options;
using System.Text.RegularExpressions;

namespace CleanValidation.Core.Validators.Core
{
    internal partial class IpAddressValidator
    {
        [GeneratedRegex(@"^((25[0-5]|2[0-4]\d|1\d\d|[1-9]?\d)(\.|$)){4}$")]
        public static partial Regex StrictIpv4Regex();

        public static bool IsValid(
            string? ipAddress,
            IpAddressOptions options = IpAddressOptions.None)
        {
            if (!IPAddress.TryParse(ipAddress, out IPAddress? outIpAddress))
                return false;

            if ((options & IpAddressOptions.DisallowLeadingZerosInIpv4) != 0 &&
                outIpAddress.AddressFamily == AddressFamily.InterNetwork &&
                !StrictIpv4Regex().IsMatch(ipAddress))
            {
                return false;
            }

            if ((options & IpAddressOptions.DisallowIpv6) != 0 &&
                outIpAddress.AddressFamily == AddressFamily.InterNetworkV6)
            {
                return false;
            }

            if ((options & IpAddressOptions.DisallowLoopback) != 0 &&
                IPAddress.IsLoopback(outIpAddress))
            {
                return false;
            }

            return true;
        }
    }
}
