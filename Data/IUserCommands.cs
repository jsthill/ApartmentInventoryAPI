using ApartmentInventoryAPI.Models;
using System.Collections.Generic;

namespace ApartmentInventoryAPI.Data
{
    public interface IUserCommands
    {
        IEnumerable<User> GetAllUsers();
        User GetUserById(int id);
        User GetUserByUserName(string username);
        IEnumerable<User> GetAllActiveUsers();

    }
}
