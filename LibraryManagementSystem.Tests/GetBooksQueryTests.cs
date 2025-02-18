using LibraryManagementSystem.Application.Queries;
using LibraryManagementSystem.Domain.Interfaces;
using LibraryManagementSystem.Domain.Model;
using Moq;
using Xunit;
using FluentAssertions;

public class GetBooksQueryTests
{
    private readonly Mock<IBookRepository> _bookRepositoryMock;
    private readonly GetBooksQuery _getBooksQuery;

    public GetBooksQueryTests()
    {
        _bookRepositoryMock = new Mock<IBookRepository>();
        _getBooksQuery = new GetBooksQuery(_bookRepositoryMock.Object);
    }

    [Fact]
    public void Execute_ShouldReturnBooks_WhenCalled()
    {
        // Arrange
        var books = new List<BookModel>
        {
            new BookModel { Id = 1, Title = "Livro Teste 1", Author = "Autor 1", ISBN = "1234567890123", YearPublication = 2020 },
            new BookModel { Id = 2, Title = "Livro Teste 2", Author = "Autor 2", ISBN = "9876543210987", YearPublication = 2021 }
        };

        _bookRepositoryMock.Setup(repo => repo.GetBooks()).Returns(books);

        // Act
        var result = _getBooksQuery.Execute();

        // Assert
        result.Should().NotBeNull();
        result.Should().HaveCount(2);
        result.Should().ContainSingle(b => b.Title == "Livro Teste 1");
        _bookRepositoryMock.Verify(repo => repo.GetBooks(), Times.Once);
    }
}
