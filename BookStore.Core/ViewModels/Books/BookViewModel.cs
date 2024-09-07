namespace BookStore.Core.ViewModels.Books
{
    public record BookViewModel(int Id,
        string Title,
        string Description,
        string ISBN,
        string Language,
        int Pages,
        decimal Price,
        DateTime PublicationDate);
}
