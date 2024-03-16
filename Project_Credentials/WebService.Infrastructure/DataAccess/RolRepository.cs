using Microsoft.EntityFrameworkCore;
using Project_Credentials.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebService.Domain;
using WebService.Domain.DTOs;
using WebService.Domain.Interfaces;
using WebService.Infrastructure.ContextDb;

namespace WebService.Infrastructure.DataAccess
{
    public class RolRepository : IRolRepository
    {
        private readonly Project_CredentialsContext context;

        public RolRepository(Project_CredentialsContext _context)
        {
            context = _context;
        }


        public async Task<Guid> GetByName(string type)
        {
  
                return await context.Roles
                    .Where(u => u.Name == type)
                    .Select(x => x.Id)
                    .FirstOrDefaultAsync();

        
        }
    }
}
