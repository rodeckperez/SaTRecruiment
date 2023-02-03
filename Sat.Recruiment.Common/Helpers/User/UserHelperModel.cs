using Sat.Recruiment.Common.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sat.Recruiment.Common.Helpers.User
{
    public class UserHelperModel
    {
        public string name { get; set; }

        public string email { get; set; }

        public string address { get; set; }

        public string phone { get; set; }

        public UserType userType { get; set; }

        public decimal money { get; set; }
    }
}
