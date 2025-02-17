using LibraryManagementSystem.Application.Queries;
using LibraryManagementSystem.Domain.Interfaces;
using Moq;
using Xunit;

namespace LibraryManagementSystem.Tests
{
    public class GetBookQueryTests
    {
        private readonly Mock<IBookRepository> _bookRepositoryMock;
        private readonly GetBooksQuery _getBookQuery;

        public GetBookQueryTests()
        {
            _bookRepositoryMock = new Mock<IBookRepository>();
            _getBookQuery = new GetBooksQuery(_bookRepositoryMock.Object);
        }

        [Fact]
        public void Execute_WhenCalled_ShouldCallGetBooks()
        {
            // Arrange
            // Act
            _getBookQuery.Execute();
            // Assert
            _bookRepositoryMock.Verify(x => x.GetBooks(), Times.Once);
        }

    }
}
