namespace BookStore.Data.Models.Helpers
{
    public class BaseModel
    {
        public int Id { get; set; }

        public bool IsDeleted { get; set; } = false;

        public DateTime CreationDate { get; set; } = DateTime.UtcNow;

        public DateTime? ModifiedDate { get; set; }
    }
}
