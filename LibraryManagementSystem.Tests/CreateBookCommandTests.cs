using LibraryManagementSystem.Application.Commands;
using LibraryManagementSystem.Domain.Interfaces;
using LibraryManagementSystem.Domain.Model;
using Moq;
using Xunit;

public class CreateBookCommandTests
{
    private readonly Mock<IBookRepository> _bookRepositoryMock;
    private readonly CreateBookCommand _createBookCommand;

    public CreateBookCommandTests()
    {
        _bookRepositoryMock = new Mock<IBookRepository>();
        _createBookCommand = new CreateBookCommand(_bookRepositoryMock.Object);
    }

    [Fact]
    public void Execute_ShouldCallRepository_WhenDataIsValid()
    {
        // Arrange
        var book = new BookModel
        {
            Title = "Novo Livro",
            Author = "Autor Teste",
            ISBN = "1234567890123",
            YearPublication = 2022
        };

        // Act
        _createBookCommand.Execute(book);

        // Assert
        _bookRepositoryMock.Verify(repo => repo.CreateBook(book), Times.Once);
    }
}
