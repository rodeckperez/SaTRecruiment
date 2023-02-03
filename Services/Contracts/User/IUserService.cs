using Sat.Recruiment.Common.Helpers.User;
using Sat.Recruiment.Common.Models.Input.User;
using Sat.Recruiment.Common.Models.Output.User;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Sat.Recruiment.Services.Contracts.User
{
    public interface IUserService
    {
        Task<UserOutputModel> createUser(UserHelperModel inputModel);
    }
}
