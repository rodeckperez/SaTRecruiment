using System;
using System.Dynamic;

using Microsoft.AspNetCore.Mvc;
using Moq;
using Sat.Recruiment.Common.Enums;
using Sat.Recruiment.Common.Models.Input.User;
using Sat.Recruiment.Services.Contracts.User;
using Sat.Recruiment.Workflows.Implementation.User;
using Sat.Recruitment.Api.Controllers;

using Xunit;

namespace Sat.Recruitment.Test
{
    //here we go to validate the workflows :) 
    [CollectionDefinition("Tests", DisableParallelization = true)]
    public class UnitTest1
    {
        [Fact]
        public void CheckIfTheInputModelIsInvalid()
        {
            var instance = this.CreateInstance();

            var result = instance.createUser(new UserInputModel { address = "", email = null, money = 0, name = "", phone = "", userType = UserType.Normal });

            Assert.True(result.Result.HasErrors);
        }

        [Fact]
        public void CheckIfTheUserIsCreated()
        {
            var instance = this.CreateInstance();

            var result = instance.createUser(new UserInputModel { address = "calle 123", email = "test", money = 0, name = "", phone = "", userType = UserType.Normal });

            Assert.False(result.Result.HasErrors);
        }

        private UserWorkflow CreateInstance(IUserService userService = null)
        {

            userService ??= new Mock<IUserService>().Object;
            return new UserWorkflow(userService);
        }
    }
}
