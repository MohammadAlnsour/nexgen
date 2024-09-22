
namespace nexgen.Domain.Entities
{
    public class User : BaseDbEntity, IAggregateRoot
    {
        public int Id { get; private set; }
        public string Username { get; private set; }
        public string Password { get; private set; }
        public string Email { get; private set; }
        public bool IsActivated { get; private set; }
        public bool LoggedIn1stTime { get; private set; }
        public DateTime? LastLoginDate { get; private set; }
        public DateTime? ValidFromDate { get; private set; }
        public DateTime? ValidToDate { get; private set; }
        public string? SingleMachineToken { get; private set; }

        public User(string username, string password, string email, bool isActivated, bool firstTimeLogin, DateTime? lastLogindate, DateTime? userValidFrom, DateTime? userValidTo, string? singleMachineToken)
        {
            Username = username;
            Password = password;
            Email = email;
            IsActivated = isActivated;
            LastLoginDate = lastLogindate;
            ValidFromDate = userValidFrom;
            ValidToDate = userValidTo;
            SingleMachineToken = singleMachineToken;
            LoggedIn1stTime = firstTimeLogin;
        }
        public User(bool firstTimeLogin, DateTime? lastLogindate)
        {
            LoggedIn1stTime = firstTimeLogin;
            LastLoginDate = lastLogindate;
        }

        public User(string? singleMachineToken)
        {
            SingleMachineToken = singleMachineToken;
        }

    }
}
