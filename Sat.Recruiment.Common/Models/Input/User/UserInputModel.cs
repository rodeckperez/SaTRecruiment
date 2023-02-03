using Sat.Recruiment.Common.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sat.Recruiment.Common.Models.Input.User
{
    public class UserInputModel
    {
        public string name { get; set; }

        public string email { get; set; }

        public string address { get; set; }

        public string phone { get; set; }

        public UserType userType { get; set; }

        public int money { get; set; }

        public bool IsValid()
        {
            return name != null && email != null && userType != 0;
        }
    }
}