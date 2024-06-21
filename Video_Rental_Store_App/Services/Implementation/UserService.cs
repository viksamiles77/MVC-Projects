using DataAccess.Interface;
using DomainModels;
using Services.Interfaces;

namespace Services.Implementation
{
    public class UserService : IUserService
    {
        private readonly IRepository<User> _userRepository;

        private List<User> users = new List<User>
        {
            new User { Id = 1, FullName = "Viktor Mileski", CardNumber = "1234567890" }
        };

        public User AuthenticateUser(string cardNumber)
        {
            return users.FirstOrDefault(u => u.CardNumber == cardNumber);
        }

        public void RegisterUser(User user)
        {
            _userRepository.Add(user);
        }

    }
}
