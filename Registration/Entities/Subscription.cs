using System;

namespace Registration.Entities
{
    public class Subscription
    {
        public string UserId { get; set; }
        public SubscriptionType Type { get; set; }
        public DateTime StartedAt { get; set; }
        public DateTime EndsAt { get; set; }
    }

    public enum SubscriptionType
    {
        Basic,
        Premium
    }
}