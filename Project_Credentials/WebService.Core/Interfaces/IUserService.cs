using Project_Credentials.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebService.Domain.DTOs;

namespace WebService.Core.Interfaces
{
    public interface IUserService
    {
        public Task Delete(Guid userId);
        public  Task Insert(UserRequestDto userData);
        public Task Update(UserDataDto userData);
        public Task<User> UserValidation(string email, string password);   
    }
}
