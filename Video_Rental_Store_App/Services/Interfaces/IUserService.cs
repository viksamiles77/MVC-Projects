using DomainModels;

namespace Services.Interfaces
{
    public interface IUserService
    {
        public User AuthenticateUser(string cardNumber);
    }
}
