using nexgen.Domain.Entities;
using nexgen.Domain.Factories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nexgen.Domain.Factories
{
    public class UserFactory : IUserFactory
    {
        public User CreateUser(string username, string password, string email, bool isActivated, bool firstTimeLogin, DateTime? lastLogindate, DateTime? userValidFrom, DateTime? userValidTo, string? singleMachineToken)
        {
            return new User(username, password, email, isActivated, firstTimeLogin, lastLogindate, userValidFrom, userValidTo, singleMachineToken);
        }



    }
}
