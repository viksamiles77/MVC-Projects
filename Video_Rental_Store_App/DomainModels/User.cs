﻿using DomainModels.Enums;

namespace DomainModels
{
    public class User : BaseEntity
    {
        public string FullName { get; set; }
        public int Age { get; set; }
        public string CardNumber { get; set; }
        public string UserName { get; set; }
        public DateTime CreatedOn { get; set; }
        public bool IsSubscriptionExpired { get; set; }
        public string SubscriptionType { get; set; } 
        public string Email { get; set; }
        public string Password { get; set; }
        public bool IsAdmin { get; set; }
    }
}
