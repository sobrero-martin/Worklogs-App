using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Worklogs.DB.Data;
using Worklogs.DB.Data.Entities;
using Worklogs.Shared.DTO;

namespace Worklogs.Repository.Repository
{
    public class UserRepository : Repository<User>, IRepository<User>, IUserRepository
    {
        private readonly AppDbContext context;

        public UserRepository(AppDbContext context) : base(context)
        {
            this.context = context;
        }

        public async Task<int> Login(LoginDTO login)
        {
            var user = await context.Users.FirstOrDefaultAsync(x => x.Email == login.Email && x.PasswordHash == login.Password);
            if (user == null) return 0;
            return user.Id;
        }

        /*
        public async Task<User?> GetByEmail(string email)
        {
            return await context.Users.FirstOrDefaultAsync(x => x.Email == email);
        }
        */
    }
}
