using DomainModels;

namespace DataAccess
{
    public class CurrentSession
    {
        public static User CurrentUser;
        public static void Set(User user)
        { CurrentUser = user; }
        public static void RemoveUser()
        { CurrentUser = null; }
    }
}
