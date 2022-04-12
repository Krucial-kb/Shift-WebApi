using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using ShiftDataAccess.DbModels;
using ShiftDataAccess.Mapper;
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
        private readonly ShiftDbContext _ctx;
        /*private readonly ILogger _logger;*/

        public UsersRepo(ShiftDbContext context)
        {
            _ctx = context;
            /*_logger = logger;*/

        }

        public async Task<IEnumerable<Users>> GetUsers()
        {
            var players = await _ctx.Users.ToListAsync();

            var result = players.Select(ShiftDataMapper.MapperData);

            return result;
        }


        public async Task<Users> GetUserById(int _userId)
        {
            var _user = await _ctx.Users.FirstOrDefaultAsync(u => u.Id == _userId);
            if (_user == null)
            {
                /*_logger.LogInformation($"User with id {_userId} not found.");*/
                return null;
            }
            /*_logger.LogInformation($"Fetched user with id {_userId}.");*/
            return ShiftDataMapper.MapperData(_user);
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
