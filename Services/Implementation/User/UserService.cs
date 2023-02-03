using Microsoft.Extensions.Caching.Memory;
using Sat.Recruiment.Common.Enums;
using Sat.Recruiment.Common.Helpers.User;
using Sat.Recruiment.Common.Models.Input.User;
using Sat.Recruiment.Common.Models.Output.User;
using Sat.Recruiment.Services.Contracts.User;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Sat.Recruiment.Services.Implementation.User
{
    public class UserService : IUserService
    {
        protected IMemoryCache _memoryCache { get; }
        public UserService(IMemoryCache memoryCache)
        {
            this._memoryCache = memoryCache ?? throw new ArgumentNullException(nameof(memoryCache));
            this.getCurrentUsers();
        }

        public async Task<UserOutputModel> createUser(UserHelperModel inputModel)
        {
            UserOutputModel userOutputModelResponse = new UserOutputModel();
            try
            {
                var user = this._memoryCache.Get(inputModel.email);
                if (user == null)
                {
                    addUserCache(inputModel);                   
                    userOutputModelResponse.name = inputModel.name;
                    userOutputModelResponse.email = inputModel.email;
                    userOutputModelResponse.userType = inputModel.userType;
                }

                else {
                    var currentUser = JsonSerializer.Deserialize<UserHelperModel>(user.ToString())!;     
                    userOutputModelResponse.name = currentUser.name;
                    userOutputModelResponse.email = currentUser.email;
                    userOutputModelResponse.userType = currentUser.userType;
                }



                return userOutputModelResponse;

            }
            catch (Exception)
            {
                return null;
            }
        }

        private void addUserCache(UserHelperModel inputModel)
        {
            try
            {
                var jsonString = JsonSerializer.Serialize(inputModel);
                this._memoryCache.Set(inputModel.email, jsonString);               
            }
            catch (Exception)
            {
              
            }
        }

        private int getTimeSpan()
        {
            TimeSpan CurrentTime = DateTime.Now.TimeOfDay;
            return int.Parse(CurrentTime.Ticks.ToString());
        }

        private void getCurrentUsers()
        {
            var path = Directory.GetCurrentDirectory() + "/Files/Users.txt";

            FileStream fileStream = new FileStream(path, FileMode.Open);

            StreamReader reader = new StreamReader(fileStream);

            while (reader.Peek() >= 0)
            {
                var line = reader.ReadLineAsync().Result;
                var user = new UserHelperModel
                {
                    name = line.Split(',')[0].ToString(),
                    email = line.Split(',')[1].ToString(),
                    phone = line.Split(',')[2].ToString(),
                    address = line.Split(',')[3].ToString(),
                    userType = (UserType)Enum.Parse(typeof(UserType), line.Split(',')[4].ToString()),
                    money = int.Parse(line.Split(',')[5].ToString()),
                };
                addUserCache(user);
            }
            reader.Close();
        }
    }
}
