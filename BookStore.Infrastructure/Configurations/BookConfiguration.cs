using BookStore.Data.Models.Products.Books;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookStore.Infrastructure.Configurations
{
    public class BookConfiguration : IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> builder)
        {
            /*
             [Required(ErrorMessage = "Title is required.")]
             [MaxLength(200)]
             [MaxLength(500)]
             [MaxLength(13)]
             [RegularExpression(@"^\d{10}(\d{3})?$", ErrorMessage = "Invalid ISBN format.")]
             [MaxLength(2)]
             [Range(1, int.MaxValue, ErrorMessage = "The number of pages must be greater than zero.")]
             [Range(0.0, double.MaxValue, ErrorMessage = "Price must be a non-negative value.")]
             [Range(0, int.MaxValue, ErrorMessage = "Quantity must be a non-negative value.")]
             [Range(0, int.MaxValue, ErrorMessage = "Sold units must be a non-negative value.")]
             */

            builder.Property(b => b.Title)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(b => b.ISBN)
                .IsRequired()
                .HasMaxLength(13);
        }
    }
}
