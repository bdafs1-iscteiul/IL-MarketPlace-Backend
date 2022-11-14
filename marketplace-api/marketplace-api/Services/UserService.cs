using marketplace_api.Data;
using marketplace_api.Models.Entity;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace marketplace_api.Services
{
    public class UserService
    {
        private readonly ApplicationDbContext _context;

        public UserService(ApplicationDbContext context)
        {
            _context = context;
        }

        //this should be changed to get users based on a certain condition(age/etc)
        public async Task<IEnumerable<User>> GetAllUsers()
        {
            List<User> i=await _context.Users.ToListAsync();
            return i;
        }

        public async Task<User> GetUser(int id)
        {

            var user = await _context.Users.FindAsync(id);
            return user;
        }

        public async Task<User> GetUser(string email,string password)
        {
            var query = from usr in _context.Users
                        where usr.Email == email
                        where usr.Password == password
                        select usr;
            //_context.Users.Any(e => e.Id == id); something like this?
            var user = query.FirstOrDefault<User>();
            return user;
        }

        public async Task DeleteUser(User user)
        {
            _context.Users.Remove(user);
            await _context.SaveChangesAsync();
        }

        public async Task<User> CreateUser(string name, string email, long phone, long membership, string password)
        {
            User user = new User()
            {
                Name = name,
                Email = email,
                PhoneNumber = phone,
                MembershipNumber = membership,
                Password = password
            };
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            return user;
        }

        private bool UserExists(int id)
        {
            return _context.Users.Any(e => e.Id == id);
        }
    }
}
