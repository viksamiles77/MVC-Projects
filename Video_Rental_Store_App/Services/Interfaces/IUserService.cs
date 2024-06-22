using DomainModels;
using ViewModels;

namespace Services.Interfaces
{
    public interface IUserService
    {
        public User AuthenticateUser(string cardNumber);
        public void RegisterUser(UserViewModel userViewModel);
    }
}
