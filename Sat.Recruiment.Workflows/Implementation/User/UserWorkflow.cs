using Sat.Recruiment.Common.Enums;
using Sat.Recruiment.Common.Helpers.User;
using Sat.Recruiment.Common.Models.Input.User;
using Sat.Recruiment.Common.Models.Output.User;
using Sat.Recruiment.Common.Utils;
using Sat.Recruiment.Services.Contracts.User;
using Sat.Recruiment.Workflows.Contracts.User;
using Sat.Recruiment.Workflows.Helpers;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Sat.Recruiment.Workflows.Implementation.User
{
    public class UserWorkflow : IUserWorkflow
    {
        protected IUserService _userService { get; }

        public UserWorkflow(IUserService userService)
        {
            this._userService = userService;
        }
        public async Task<Response<UserOutputModel>> createUser(UserInputModel inputModel)
        {
            var response = new Response<UserOutputModel>();

            try
            {
                if (!inputModel.IsValid())
                {
                    response.AddError("Invalid Input Model");
                    return response;
                }

                var user = await this._userService.createUser(new UserHelperModel
                {
                    money = getMoney(inputModel.userType, inputModel.money),
                    userType = inputModel.userType,
                    email = inputModel.email,
                    address = inputModel.address,
                    name = inputModel.name,
                    phone = inputModel.phone
                });
                response.Data = user;
                response.AddSuccess("Success");
            }
            catch (Exception)
            {
                WorkflowHelper.FailFlowExecution(response);
                //we can implement a error log :)
            }

            return response;
        }

        private decimal getMoney(UserType userType, int money)
        {
            decimal newMoney = 0;

            switch (userType)
            {
                case UserType.Normal:
                    if (money > 100)
                    {
                        var percentage = Convert.ToDecimal(0.12);
                        var gif = money * percentage;
                        newMoney = money + gif;
                    }

                    else if (money > 10)
                    {
                        var percentage = Convert.ToDecimal(0.8);
                        var gif = money * percentage;
                        newMoney = money + gif;
                    }

                    break;
                case UserType.SuperUser:
                    if (money > 100)
                    {
                        var percentage = Convert.ToDecimal(0.20);
                        var gif = money * percentage;
                        newMoney = money + gif;
                    }

                    break;
                case UserType.Premium:

                    if (money > 100)
                    {
                        var gif = money * 2;
                        newMoney = money + gif;
                    }
                    break;
                default:
                    break;
            }

            return newMoney;
        }

    }
}
