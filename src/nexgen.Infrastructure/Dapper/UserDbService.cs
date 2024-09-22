using Microsoft.Extensions.Configuration;
using nexgen.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;

namespace nexgen.Infrastructure.Dapper
{
    public class UserDbService : IUserDbService
    {
        private readonly IConfiguration _configuration;
        public UserDbService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<User> AuthUserByUsernameAndPassword(string username, string password)
        {
            var connectionString = _configuration.GetConnectionString("ReadConnection");

            try
            {
                using (var connection = new SqlConnection(connectionString))
                {
                    await connection.OpenAsync();

                    var parameters = new DynamicParameters();
                    parameters.Add("@username", username);
                    parameters.Add("@password", password);

                    var user = await connection.QueryFirstAsync<User>("SELECT [Id],[Username],[Email],[IsActivated],[LoggedIn1stTime],[Password],[LastLoginDate],[ValidFromDate],[ValidToDate],[SingleMachineToken],[CreatedBy],[CreatedDate],[LastModifiedDate] FROM [auth].[Users]  WHERE Username = @username and Password = @password",
                        new { parameters },
                        commandType: CommandType.Text);

                    return user;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
