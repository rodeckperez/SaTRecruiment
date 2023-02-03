using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Sat.Recruiment.Common.Models.Input.User;
using Sat.Recruiment.Common.Models.Output.User;
using Sat.Recruiment.Common.Utils;
using Sat.Recruiment.Workflows.Contracts.User;
using Sat.Recruitment.Api.Infrastructure;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;

namespace Sat.Recruitment.Api.Controllers
{
    public class Result
    {
        public bool IsSuccess { get; set; }
        public string Errors { get; set; }
    }

    [ApiController]
    [Route("[controller]")]
    public partial class UsersController : ControllerBase
    {

        private readonly IUserWorkflow _userWorkflow = null;

        public UsersController(IUserWorkflow userWorkflow)
        {
            _userWorkflow = userWorkflow;
        }

        [HttpPost]
        [Route("/create-user")]
        public async Task<IActionResult> createUser(UserInputModel inputModel)
        {
            var response = await this._userWorkflow.createUser(inputModel);
            return ResponseActionResult.CreateActionResult(response);
        }

        //Validate errors
        private void ValidateErrors(string name, string email, string address, string phone, ref string errors)
        {
            if (name == null)
                //Validate if Name is null
                errors = "The name is required";
            if (email == null)
                //Validate if Email is null
                errors = errors + " The email is required";
            if (address == null)
                //Validate if Address is null
                errors = errors + " The address is required";
            if (phone == null)
                //Validate if Phone is null
                errors = errors + " The phone is required";
        }
    }
    public class User
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string UserType { get; set; }
        public decimal Money { get; set; }
    }
}
