using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebService.Domain.DTOs
{
    public class UserLoginRquestDto
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }

    public class UserDataDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }

    public class UserRequestDto
    {

        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
