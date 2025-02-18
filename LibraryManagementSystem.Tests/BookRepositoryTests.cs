using LibraryManagementSystem.Infrastructure.Repositories;
using LibraryManagementSystem.Domain.Model;
using Moq;
using Xunit;
using FluentAssertions;
using System.Data;
using Microsoft.Extensions.Configuration;

public class BookRepositoryTests
{
    private readonly BookRepository _bookRepository;
    private readonly IConfiguration _configurationMock;

    public BookRepositoryTests()
    {
        // 🔹 Criando uma configuração simulada sem usar Moq
        var inMemorySettings = new Dictionary<string, string>
        {
            { "ConnectionStrings:DefaultConnection", "Server=DEVBRUNO;Database=LibraryDB;User Id=sa;Password=Bru@1989;TrustServerCertificate=True" }
        };

        _configurationMock = new ConfigurationBuilder()
            .AddInMemoryCollection(inMemorySettings)
            .Build();

        // 🔹 Criando instância do repositório
        _bookRepository = new BookRepository(_configurationMock);
    }

    [Fact]
    public void GetBooks_ShouldReturnListOfBooks()
    {
        // Arrange
        var books = new List<BookModel>
        {
            new BookModel { Id = 1, Title = "Livro 1", Author = "Autor 1", ISBN = "1234567890123", YearPublication = 2020 },
            new BookModel { Id = 2, Title = "Livro 2", Author = "Autor 2", ISBN = "9876543210987", YearPublication = 2021 }
        };

        var mockReader = new Mock<IDataReader>();
        mockReader.SetupSequence(r => r.Read())
                  .Returns(true)
                  .Returns(true)
                  .Returns(false);

        mockReader.Setup(r => r["Id"]).Returns(1);
        mockReader.Setup(r => r["Title"]).Returns("Livro 1");
        mockReader.Setup(r => r["Author"]).Returns("Autor 1");
        mockReader.Setup(r => r["ISBN"]).Returns("1234567890123");
        mockReader.Setup(r => r["YearPublication"]).Returns(2020);

        var commandMock = new Mock<IDbCommand>();
        commandMock.Setup(cmd => cmd.ExecuteReader()).Returns(mockReader.Object);

        var dbConnectionMock = new Mock<IDbConnection>();
        dbConnectionMock.Setup(conn => conn.CreateCommand()).Returns(commandMock.Object);

        // Act
        var result = _bookRepository.GetBooks().ToList();

        // Assert
        result.Should().NotBeNull();
        result.Should().HaveCount(2);        
        result.Should().Contain(b => b.Title == "Livro 1" && b.Author == "Autor 1");
        result.Should().Contain(b => b.Title == "Livro 2" && b.Author == "Autor 2");
    }
}
