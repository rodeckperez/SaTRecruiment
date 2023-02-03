using Sat.Recruiment.Common.Utils;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using Sat.Recruiment.Common.Models.Output.User;
using Sat.Recruiment.Common.Models.Input.User;
using System.Threading.Tasks;

namespace Sat.Recruiment.Workflows.Contracts.User
{
    public interface IUserWorkflow
    {
        Task<Response<UserOutputModel>> createUser(UserInputModel inputModel);
    }
}
