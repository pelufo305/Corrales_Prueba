using Microsoft.AspNetCore.Http;
using Siigo.Corrales.Domain.Exception;
using Xunit;

namespace Siigo.Corrales.Domain.Test.Exception
{
    public class UnauthorizedExceptionTest
    {
        [Fact]
        public void CreateExceptionTest()
        {
            var exception = new UnauthorizedException("unauthorized", "Unauthorized");
            //Asserts
            Assert.Equal(StatusCodes.Status401Unauthorized, exception.StatusCode);
            Assert.Equal("unauthorized", exception.Code);
        }
    }
}
