using CleanValidation.Core.Guards;
using CleanValidation.Core.Options;
using CleanValidation.Core.Results;

namespace CleanValidation.Core.Tests.Guards
{
    public class Guard_ExternalTest
    {
        [Fact]
        public void AgainstInvalidUri_InvalidUri_ReturnsInvalidResult()
        {
            string uri = "httpsXXX:XX/|||/youtu.be\\/k";

            Guard guard = Guard.Create().AgainstInvalidUri(uri);

            IResult result = guard.GetResult();

            Assert.NotNull(result);
            Assert.False(result.Success);
            Assert.IsType<InvalidResult>(result);
        }

        [Fact]
        public void AgainstInvalidUri_ValidUri_ReturnsSuccessResult()
        {
            string uri = "https://youtu.be/m_4jEZGKsO8?list=PLAbYWcQD84aPKkap3SFNiCeqf6g2VzCvk";

            Guard guard = Guard.Create().AgainstInvalidUri(uri);

            IResult result = guard.GetResult();

            Assert.NotNull(result);
            Assert.True(result.Success);
            Assert.IsType<SuccessResult>(result);
        }

        [Fact]
        public void AgainstInvalidUri_NullUri_ReturnsInvalidResult()
        {
            string? uri = null;

            Guard guard = Guard.Create().AgainstInvalidUri(uri);

            IResult result = guard.GetResult();

            Assert.NotNull(result);
            Assert.False(result.Success);
            Assert.IsType<InvalidResult>(result);
        }

        [Theory]
        [InlineData("127.-0.0.1", false, IpAddressOptions.None)]
        [InlineData("192.168.01.1", false, IpAddressOptions.DisallowLeadingZerosInIpv4)]
        [InlineData("192.168.1.256", false, IpAddressOptions.None)]
        public void AgainstInvalidIpAddress_InvalidIpAddress_ReturnsInvalidResult(
            string ipAddress, 
            bool expectedResult,
            IpAddressOptions options)
        {
            Guard guard = Guard.Create().AgainstInvalidIpAddress(ipAddress, options);

            IResult result = guard.GetResult();

            Assert.NotNull(result);
            Assert.Equal(expectedResult, result.Success);
            Assert.IsType<InvalidResult>(result);
        }

        [Theory]
        [InlineData("10.0.0.5", true)]
        [InlineData("192.168.1.1", true)]
        [InlineData("172.16.0.254", true)]
        [InlineData("202.202.202.202", true)]
        [InlineData("2001:db8:3c4d:15::1", true)]
        [InlineData("2607:f8b0:4004:80d::200e", true)]
        [InlineData("2001:0db8:85a3:0000:0000:8a2e:0370:7334", true)]
        public void AgainstInvalidIpAddress_ValidIpAddress_ReturnsSuccessResult(string ipAddress, bool expectedResult)
        {
            Guard guard = Guard.Create().AgainstInvalidIpAddress(ipAddress);

            IResult result = guard.GetResult();

            Assert.NotNull(result);
            Assert.Equal(expectedResult, result.Success);
            Assert.IsType<SuccessResult>(result);
        }        

        [Fact]
        public void AgainstInvalidIpAddress_NullIpAddress_ReturnsInvalidResult()
        {
            string? ipAddress = null;

            Guard guard = Guard.Create().AgainstInvalidIpAddress(ipAddress);

            IResult result = guard.GetResult();

            Assert.NotNull(result);
            Assert.False(result.Success);
            Assert.IsType<InvalidResult>(result);
        }

        [Fact]
        public void AgainstHtml_ContainsHtml_ReturnsInvalidResult()
        {
            string value = "Hi Friend <p>Hello World!</p>";

            Guard guard = Guard.Create().AgainstHtml(value);

            IResult result = guard.GetResult();

            Assert.NotNull(result);
            Assert.False(result.Success);
            Assert.IsType<InvalidResult>(result);
        }

        [Fact]
        public void AgainstHtml_NotContainsHtml_ReturnsSuccessResult()
        {
            string value = "Hello World!";

            Guard guard = Guard.Create().AgainstHtml(value);

            IResult result = guard.GetResult();

            Assert.NotNull(result);
            Assert.True(result.Success);
            Assert.IsType<SuccessResult>(result);
        }

        [Fact]
        public void AgainstHtml_NullValue_ReturnsInvalidResult()
        {
            string? value = null;

            Guard guard = Guard.Create().AgainstHtml(value);

            IResult result = guard.GetResult();

            Assert.NotNull(result);
            Assert.False(result.Success);
            Assert.IsType<InvalidResult>(result);
        }

        [Fact]
        public void AgainstUnmatchRegex_Unmatch_ReturnsInvalidResult()
        {
            string value = "12345678910";
            string pattern = "^[0-9]{3}.[0-9]{3}.[0-9]{3}-[0-9]{2}";           

            Guard guard = Guard.Create().AgainstUnmatchRegex(value, pattern);

            IResult result = guard.GetResult();

            Assert.NotNull(result);
            Assert.False(result.Success);
            Assert.IsType<InvalidResult>(result);
        }

        [Fact]
        public void AgainstUnmatchRegex_Match_ReturnsSuccessResult()
        {
            string value = "081.817.690-31";
            string pattern = "^[0-9]{3}.[0-9]{3}.[0-9]{3}-[0-9]{2}";

            Guard guard = Guard.Create().AgainstUnmatchRegex(value, pattern);

            IResult result = guard.GetResult();

            Assert.NotNull(result);
            Assert.True(result.Success);
            Assert.IsType<SuccessResult>(result);
        }

        [Fact]
        public void AgainstUnmatchRegex_NullValue_ReturnsInvalidResult()
        {
            string? value = null;

            Guard guard = Guard.Create().AgainstUnmatchRegex(value, "^[0-9]+$");

            IResult result = guard.GetResult();

            Assert.NotNull(result);
            Assert.False(result.Success);
            Assert.IsType<InvalidResult>(result);
        }

        [Fact]
        public void AgainstInvalidJson_InvalidJson_ReturnsInvalidResult()
        {
            string json = "Hi\nHow Are\n You\n?";
            
            Guard guard = Guard.Create().AgainstInvalidJson<User>(json);

            IResult result = guard.GetResult();

            Assert.NotNull(result);
            Assert.False(result.Success);
            Assert.IsType<InvalidResult>(result);
        }

        [Fact]
        public void AgainstInvalidJson_ValidJson_ReturnsSuccessResult()
        {
            string json = "{\r\n  \"name\": \"John Doe\",\r\n  \"age\": 30,\r\n  \"description\": \"Young boy\"\r\n }";

            Guard guard = Guard.Create().AgainstInvalidJson<User>(json);

            IResult result = guard.GetResult();

            Assert.NotNull(result);
            Assert.True(result.Success);
            Assert.IsType<SuccessResult>(result);
        }

        [Fact]
        public void AgainstInvalidJson_NullValue_ReturnsInvalidResult()
        {
            string? json = null;

            Guard guard = Guard.Create().AgainstInvalidJson<User>(json);

            IResult result = guard.GetResult();

            Assert.NotNull(result);
            Assert.False(result.Success);
            Assert.IsType<InvalidResult>(result);
        }
    }
}
