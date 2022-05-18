using ApartmentInventoryAPI.Models;
using System;
using System.Collections.Generic;

namespace ApartmentInventoryAPI.Data
{
    public class UserMethods : IUserCommands
    {
        public IEnumerable<User> GetAllActiveUsers()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<User> GetAllUsers()
        {
            throw new NotImplementedException();
        }

        public User GetUserById(int id)
        {
            throw new NotImplementedException();
        }

        public User GetUserByUserName(string username)
        {
            throw new NotImplementedException();
        }
    }
}