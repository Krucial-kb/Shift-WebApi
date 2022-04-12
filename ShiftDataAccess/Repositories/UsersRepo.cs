using Microsoft.AspNetCore.Mvc;
using ShiftDomain.DomainModels;
using ShiftDomain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShiftDataAccess.Repositories
{
    public class UsersRepo : IUsersContract
    {

        public Task<ActionResult<IEnumerable<Users>>> GetUsers()
        {
            throw new NotImplementedException();
        }


        public Task<ActionResult<Users>> GetUser(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ActionResult<Users>> PostUser(Users user)
        {
            throw new NotImplementedException();
        }

        public Task<IActionResult> PutUser(int id, Users user)
        {
            throw new NotImplementedException();
        }

        public Task<IActionResult> DeleteUser(int id)
        {
            throw new NotImplementedException();
        }


        public Task<bool> UserExists(int id)
        {
            throw new NotImplementedException();
        }
    }
}
