using nexgen.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nexgen.Infrastructure.Repositories.Interfaces
{
    public interface IUserRepository : IRepository<User>
    {
        Task<User> GetUserByUsernameAndPassword(string username, string password);
    }
}
