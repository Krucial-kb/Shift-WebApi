using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.Web.CodeGeneration;
using ShiftDataAccess.DbModels;
using ShiftDataAccess.Mapper;
using ShiftDataAccess.Repositories;
using ShiftDomain.DomainModels;
using ShiftDomain.Interfaces;

namespace ShiftApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly ShiftDbContext _ctx;
        private readonly IUsersContract _repo;

        public UsersController(ShiftDbContext context, IUsersContract Repository)
        {
            _ctx = context;
            _repo = Repository;
        }

        /// <summary>
        /// GET All
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(typeof(List<>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<IEnumerable<ShiftDomain.DomainModels.Users>>> GetUsers()
        {
            var allUsers = await _repo.GetAllAsync();
            IEnumerable<ShiftDataAccess.DbModels.User> resource = allUsers.Select(ShiftDataMapper.MapperDomain);

            return Ok(resource);
        }

        /// <summary>
        /// GET By Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(User), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<User>> GetUser(int id)
        {
            var userById = await _repo.GetByIdAsync(id);

            if (userById == null)
            {
                return NotFound();
            }

            return Ok(userById);
        }

        /// <summary>
        /// PUT
        /// </summary>
        /// <param name="id"></param>
        /// <param name="_user"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)] // success, nothing returned (works as intended, request fulfilled)
        [ProducesResponseType(StatusCodes.Status400BadRequest)] // from an update failing due to user error (id does not match any existing resource/database id for the entity)
        [ProducesResponseType(StatusCodes.Status404NotFound)] // from query of an id that does not exist
        [ProducesResponseType(StatusCodes.Status500InternalServerError)] // if something unexpectedly went wrong with the database or http request/response
        public async Task<IActionResult> PutUser(int id, Users _user)
        {
            if (id != _user.Id)
            {
                return BadRequest();
            }

            /*_context.Entry(employee).State = EntityState.Modified;*/
            if (!await _repo.UpdateAsync(_user, id))
            {
                return NotFound();
                // if false, then modifying state failed
            }
            else
            {
                return NoContent();
                // successful put
            }
        }

        /// <summary>
        /// POST
        /// </summary>
        /// <param name="id"></param>
        /// <param name="_user"></param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(typeof(User), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> PostUser(int id, Users _user)
        {
            _repo.PostUserAsync(_user);
            await _repo.SaveChangesAsync();

            return CreatedAtAction("GetUser", new { id = _user.Id}, _user);
        }

        /// <summary>
        /// DELETE
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)] // success, nothing returned (works as intended, request fulfilled)
        [ProducesResponseType(StatusCodes.Status404NotFound)] // from query of an id that does not exist
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> DeleteUser(int id)
        {
            var _deletedUser = await _repo.GetByIdAsync(id); // get this employee matching this id
                                                                   // with tracking there are id errors even with just one row in the database so using AsNoTracking instead
            if (_deletedUser == null)
            {
                return NotFound();
            }

            _repo.DeleteUser(_deletedUser);
            await _repo.SaveChangesAsync();

            return NoContent();
        }

    }
}
