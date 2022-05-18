using System;

namespace ApartmentInventoryAPI.Models
{
    public class User
    {
        public int id { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public int isActive { get; set; }
        public DateTime expired_time { get; set; }
    }
}