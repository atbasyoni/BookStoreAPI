namespace BookStore.Core.Features.Books.DTOs
{
    public record BookCreateDTO(string Title, string Description, string ISBN, string Language, int Pages, decimal Price, DateTime PublicationDate);
}
