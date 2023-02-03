using Sat.Recruiment.Common.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sat.Recruiment.Common.Models.Output.User
{
    public class UserOutputModel
    {
        public string name { get; set; }

        public UserType userType { get; set; }

        public string email { get; set; }
    }
}
