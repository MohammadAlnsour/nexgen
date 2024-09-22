using nexgen.Domain.Entities;
using nexgen.Infrastructure.Dapper;
using nexgen.Infrastructure.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nexgen.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly IUserDbService userDbService;

        public UserRepository(IUserDbService userDbService)
        {
            this.userDbService = userDbService;
        }
        public Task<bool> Delete(User entity)
        {
            throw new NotImplementedException();
        }

        public Task<User> Get(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<User>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Book>> GetPaged(int pageNumber, int pageSize)
        {
            throw new NotImplementedException();
        }

        public async Task<User> GetUserByUsernameAndPassword(string username, string password)
        {
            return await userDbService.AuthUserByUsernameAndPassword(username, password);
        }

        public Task<long> Insert(User entity)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Update(User entity)
        {
            throw new NotImplementedException();
        }
    }
}
