using Project_Credentials.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using WebService.Core.Interfaces;
using WebService.Domain.Common;
using WebService.Domain.DTOs;
using WebService.Domain.Interfaces;

namespace WebService.Core.Integrations
{
    public class UserService : IUserService
    {

        public readonly IUserRepository userRepository;
        public readonly IRolRepository rolRepository;

        public UserService(IUserRepository _userRepository, IRolRepository _rolRepository) { 
        
            userRepository = _userRepository;
            rolRepository =_rolRepository;
        }

        public async Task Delete(Guid userId)
        {
            await userRepository.Delete(userId);
        }

        public async Task Insert(UserRequestDto userData)
        {
            var rolId = await rolRepository.GetByName(Constants.UserRoleType);

            User user = new User()
            {
                Id = Guid.NewGuid(),
                Name = userData.Name,
                Email = userData.Email,
                Password = userData.Password,
                Status = true,
                RolId = rolId
            };

            await userRepository.Insert(user);
        }

        public async Task Update(UserDataDto userData)
        {
            await userRepository.Update(userData);
        }

        public async Task<User> UserValidation(string email, string password)
        {


            return await userRepository.UserValidation(email, password);
        }
    }
}
