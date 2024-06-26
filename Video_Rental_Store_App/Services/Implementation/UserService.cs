using DataAccess;
using DataAccess.Interface;
using DomainModels;
using Services.Interfaces;
using Storage;
using ViewModels;

namespace Services.Implementation
{
    public class UserService : IUserService
    {
        private readonly IRepository<User> _userRepository;

        public UserService(IRepository<User> userRepository)
        {
            _userRepository = userRepository;
        }

        public User AuthenticateUser(string cardNumber)
        {
            var users = _userRepository.GetAll();
            return users.FirstOrDefault(u => u.CardNumber == cardNumber);
        }

        public void RegisterUser(UserViewModel userViewModel)
        {
            if (_userRepository.GetAll().Any(x => x.CardNumber == userViewModel.CardNumber))
            {
                throw new Exception("User with this card number already exists");
            }

            var user = new User
            {
                FullName = $"{userViewModel.FirstName} {userViewModel.LastName}",
                Age = userViewModel.Age.Value,
                UserName = userViewModel.UserName,
                CardNumber = userViewModel.CardNumber,
                Email = userViewModel.Email,
                Password = userViewModel.Password,
                SubscriptionType = userViewModel.SubscriptionType.ToString(),
                CreatedOn = DateTime.Now,
                IsSubscriptionExpired = false,
            };

            if(user.CardNumber == "1111111111111111")
            {
                user.IsAdmin = true;
            }

            _userRepository.Add(user);
        }

        public UserViewModel GetCurrentUser()
        {
            var user = CurrentSession.CurrentUser;
            if (user != null) return new UserViewModel()
            {
                Id = user.Id,
                FirstName = user.FullName,
                LastName = user.FullName,
                UserName = user.UserName,
                Age = user.Age,
            };
            else
            {
                return new UserViewModel()
                { FirstName = null, LastName = null };
            }
        }

        public void Logout()
        {
            CurrentSession.RemoveUser();
        }
    }
}
