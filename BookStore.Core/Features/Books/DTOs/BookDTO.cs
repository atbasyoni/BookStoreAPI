namespace BookStore.Core.Features.Books.DTOs
{
    public record BookDTO(int Id, string Title, string Description, string ISBN, string Language, int Pages, decimal Price, DateTime PublicationDate);
}
