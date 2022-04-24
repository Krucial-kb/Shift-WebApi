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

        public UsersRepo(ShiftDbContext context)
        {
            _ctx = context;
        }

        public async Task<IEnumerable<Users>> GetAllAsync()
        {
            var players = await _ctx.Users.ToListAsync();

            var result = players.Select(ShiftDataMapper.MapperData);

            return result;
        }


        public async Task<Users> GetByIdAsync(int _userId)
        {
            var _user = await _ctx.Users.FirstOrDefaultAsync(u => u.Id == _userId);
            if (_user == null)
            {
                return null;
            }
            return ShiftDataMapper.MapperData(_user);
        }

        public void PostUserAsync(Users _user)
        {
            var mapUser = ShiftDataMapper.MapperDomain(_user);
            _ctx.Set<ShiftDataAccess.DbModels.User>().Add(mapUser);
        }

        public async Task<bool> UpdateAsync(Users updatedUser, int id)
        {
            var mappesUser = ShiftDataMapper.MapperDomain(updatedUser);
            /*_context.Entry(employee).State = EntityState.Modified;*/
            _ctx.Entry(mappesUser).State = EntityState.Modified;

            try
            {
                await SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (mappesUser == null)
                {
                    return false;
                    // employee not found
                }
                else
                {
                    throw;
                }
            }
            return true;
            // it worked, so return true
        }

        public void DeleteUser(Users _user)
        {
            var mappedUser = ShiftDataMapper.MapperDomain(_user);
            _ctx.Set<User>().Remove(mappedUser);
        }


        public async Task<int> SaveChangesAsync()
        {
            return await _ctx.SaveChangesAsync();
        }

        public async Task<IEnumerable<Users>> ToListAsync()
        {
            return await GetAllAsync();
        }

    }
}
