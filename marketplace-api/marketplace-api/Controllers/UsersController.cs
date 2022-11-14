using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using marketplace_api.Data;
using marketplace_api.Models.Entity;
using marketplace_api.Services;
using NuGet.Protocol;
using System.Diagnostics;

namespace marketplace_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        private readonly UserService _userService;
        public UsersController(UserService userService) => _userService = userService;

        // GET: api/Users
        [HttpGet]
        [Produces("application/json")]
        public async Task<ActionResult<IEnumerable<User>>> GetAllUsers()
        {
            var  users = await  _userService.GetAllUsers();
            return Ok(users);
        }

        // GET: api/Users/5
        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetUser(int id)
        {
            var user = await _userService.GetUser(id);
            if (user == null)
            {
                return NotFound();
            }
            return user;
        }

        [HttpPost("login")]
        public async Task<ActionResult<User>> GetUser(string email, string password)
        {
            
            var user = await _userService.GetUser(email,password);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }


        // POST: api/Users
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [Produces("application/json")]
        public async Task<ActionResult<User>> PostUser(string name, string email,long phone, long membership,string password)
        {
            try
            {
                
                Debug.WriteLine("\n\n\n\n\n\n\n" + "ANTAD" + "\n\n\n\\n\n\n");
                //if (validation) { }
                User user = new User()
                {
                    Name = name,
                    Email = email,
                    PhoneNumber = phone,
                    MembershipNumber = membership,
                    Password = password
                };
                _context.Users.Add(user);
                //User user =new User(name,email,phone,membership,password)
             
                //User newUser = await _userService.CreateUser(user); 
                //_context.Users.Add(user);
                await _context.SaveChangesAsync();
                return CreatedAtAction("GetUser", new { id = user.Id }, user);
            }
            catch (Exception)
            {
                return NotFound();
            }
        }

        // DELETE: api/Users/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            var user = await _userService.GetUser(id);
            if (user == null)
            {
                return NotFound();
            }
            await _userService.DeleteUser(user);
            return NoContent();
        }

    }
}
