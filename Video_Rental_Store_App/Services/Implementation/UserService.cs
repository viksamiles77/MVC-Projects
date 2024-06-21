using DomainModels;
using Services.Interfaces;

namespace Services.Implementation
{
    public class UserService : IUserService
    {
        public User AuthenticateUser(string cardNumber)
        {
            var users = new List<User>
        {
            new User { Id = 1, FullName = "Viktor Mileski", CardNumber = "1234567890" }
        };
            return users.FirstOrDefault(u => u.CardNumber == cardNumber);
        }
    }
}
