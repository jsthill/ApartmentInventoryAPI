using System.Collections.Generic;
using System.Web.Http;

namespace ApartmentInventoryAPI.Controllers
{
    public class UsersController : ApiController
    {
        // GET: api/Users
        public IEnumerable<string> Get()
        {
            return new string[] { "John", "Doe" };
        }

        // GET: api/Users/5
        public string Get(int id)
        {
            return "Peter Willis";
        }

        // POST: api/Users
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/Users/5
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/Users/5
        public void Delete(int id)
        {
        }
    }
}
