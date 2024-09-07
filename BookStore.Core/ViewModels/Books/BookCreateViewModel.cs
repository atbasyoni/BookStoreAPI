namespace BookStore.Core.ViewModels.Books
{
    public record BookCreateViewModel(string Title,
        string Description,
        string ISBN,
        string Language,
        int Pages,
        decimal Price,
        DateTime PublicationDate);
}
