using DomainModels;

namespace Storage
{
    public static class CurrentSession
    {
        public static User? CurrentUser { get; set; }
        public static void Set(User user)
        {
            CurrentUser = user;
        }
        public static void RemoveUser()
        {
            CurrentUser = null;
        }

    }
}
