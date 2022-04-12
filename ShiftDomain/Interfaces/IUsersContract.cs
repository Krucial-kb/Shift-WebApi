using Microsoft.AspNetCore.Mvc;
using ShiftDomain.DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShiftDomain.Interfaces
{
    public interface IUsersContract
    {
        Task<IEnumerable<Users>> GetUsers();
        Task<Users> GetUserById(int id);
        Task<IActionResult> PutUser(int id, Users user);
        Task<ActionResult<Users>> PostUser(Users user);
        Task<IActionResult> DeleteUser(int id);
        Task<bool> UserExists(int id);
    }
}
