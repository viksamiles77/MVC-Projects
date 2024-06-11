﻿namespace DomainModels
{
    public class User
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public int Age { get; set; }
        public string CardNumber { get; set; }
        public DateTime CreatedOn { get; set; }
        public bool IsSubscriptionExpired { get; set; }
        public string SubscriptionType { get; set; }
    }
}