using Microsoft.Extensions.Caching.Memory;
using Moq;
using Sat.Recruiment.Services.Implementation.User;
using System;
using Xunit;

namespace Sat.Recruiment.Services.Test
{
    public class UserServiceTest
    {
        [Fact]
        public void ThrowExceptionIfDependenciesAreNull()
        {
            Assert.Throws<ArgumentNullException>(() => new UserService(null));
        }

        [Fact]
        public void InstanciateSuccessfully()
        {
            var cacheMemory = new Mock<IMemoryCache>();
            var service = new UserService(cacheMemory.Object);
            Assert.NotNull(service);
        }
    }
}
