namespace BookStore.Data.Helpers
{
    public class JWT
    {
        public string ValidIssuer { get; set; }
        public string ValidAudiance { get; set; }
        public double DurationInMinutes { get; set; }
        public string Key { get; set; }
    }
}
