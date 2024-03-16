using Project_Credentials.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebService.Domain.DTOs;

namespace WebService.Domain.Interfaces
{
    public interface IRolRepository
    { 
        public Task<Guid> GetByName(string name);
       
    }
}
