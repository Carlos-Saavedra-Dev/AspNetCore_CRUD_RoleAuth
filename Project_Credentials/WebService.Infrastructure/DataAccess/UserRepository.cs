using Microsoft.EntityFrameworkCore;
using Project_Credentials.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebService.Domain.DTOs;
using WebService.Domain.Interfaces;
using WebService.Infrastructure.ContextDb;

namespace WebService.Infrastructure.DataAccess
{
    public class UserRepository : IUserRepository
    {
        private readonly Project_CredentialsContext context;

        public UserRepository (Project_CredentialsContext _context)
        {
            context = _context;
        }

        public async Task Delete(Guid userId)
        {
            try
            { 
            
                var user = await context.Users.FindAsync(userId);

                if (user != null)
                {
                    user.Status = false;
                    await context.SaveChangesAsync();
                }
            
            }catch(Exception ex)
            {

                Console.WriteLine(ex.Message);
            }

        }

        public async Task Insert(User user)
        {
            context.Users.Add(user);
            await context.SaveChangesAsync();
        }

        public async  Task Update(UserDataDto userData)
        {
            var user = await context.Users.FindAsync(userData.Id);

            if (user != null)
            {
                user.Email = string.IsNullOrEmpty(userData.Email) ? user.Email : userData.Email;
                user.Name = string.IsNullOrEmpty(userData.Name) ? user.Name : userData.Name;
                user.Password = string.IsNullOrEmpty(userData.Password) ? user.Password : userData.Password;

                await context.SaveChangesAsync();
            }

        }

        public async Task<User> UserValidation(string email, string password)
        {
            try
            {
                return await context.Users
                    .Where(u => (u.Email == email && u.Password == password) && u.Status == true)
                    .Include(u => u.Rol)
                    .FirstOrDefaultAsync();

            }catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }
    }
}
