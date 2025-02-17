using System.Data;
using LibraryManagementSystem.Domain.Model;
using LibraryManagementSystem.Infrastructure.Repositories;
using Microsoft.Extensions.Configuration;
using Moq;
using Xunit;

namespace LibraryManagementSystem.Tests
{
    public class BookRepositoryTests
    {
        private readonly Mock<IDbConnection> _dbConnectionMock;
        private readonly Mock<IDbCommand> _dbCommandMock;
        private readonly Mock<IConfiguration> _configurationMock;   
        private readonly BookRepository _bookRepository;

        public BookRepositoryTests()
        {            
            _dbCommandMock = new Mock<IDbCommand>();
            _configurationMock = new Mock<IConfiguration>();
            _dbConnectionMock = new Mock<IDbConnection>();
            _bookRepository = new BookRepository(_configurationMock.Object);
        }

        [Fact]
        public void CreateBook_WhenCalled_ShouldCreateBook()
        {
            // Arrange
            var bookModel = new BookModel
            {
                Title = "Book Title",
                Author = "Book Author",
                ISBN = "123456789",
                YearPublication = 2022
            };
            _dbConnectionMock.Setup(x => x.Open());
            _dbConnectionMock.Setup(x => x.CreateCommand()).Returns(_dbCommandMock.Object);
            _dbCommandMock.Setup(x => x.CommandType).Returns(CommandType.StoredProcedure);
            _dbCommandMock.Setup(x => x.Parameters.Add(It.IsAny<IDataParameter>()));
            _dbCommandMock.Setup(x => x.ExecuteNonQuery());
            _configurationMock.Setup(x => x.GetConnectionString("DefaultConnection")).Returns("connectionString");
            // Act
            _bookRepository.CreateBook(bookModel);
            // Assert
            _dbConnectionMock.Verify(x => x.Open(), Times.Once);
            _dbConnectionMock.Verify(x => x.CreateCommand(), Times.Once);
            _dbCommandMock.VerifySet(x => x.CommandType = CommandType.StoredProcedure, Times.Once);
            _dbCommandMock.Verify(x => x.Parameters.Add(It.IsAny<IDataParameter>()), Times.Exactly(4));
            _dbCommandMock.Verify(x => x.ExecuteNonQuery(), Times.Once);
        }
    }
}
