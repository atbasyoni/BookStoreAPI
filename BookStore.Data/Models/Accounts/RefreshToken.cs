using Microsoft.EntityFrameworkCore;

namespace BookStore.Data.Models.Accounts
{
    [Owned]
    public class RefreshToken
    {
        public string Token { get; set; }
        public DateTime ExpiredOn { get; set; }
        public bool IsExpired => DateTime.UtcNow >= ExpiredOn;
        public DateTime CreatedOn { get; set; }
        public DateTime? RevokedOn { get; set; }
        public bool IsActive => RevokedOn is null || !IsExpired;

        public int UserId { get; set; }
        public User User { get; set; }
    }
}
