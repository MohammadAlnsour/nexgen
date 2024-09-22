using nexgen.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nexgen.Infrastructure.Dapper
{
    public interface IUserDbService
    {
        public Task<User> AuthUserByUsernameAndPassword(string username, string password);
    }
}
