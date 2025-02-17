using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryManagementSystem.Application.Commands;
using LibraryManagementSystem.Domain.Interfaces;
using LibraryManagementSystem.Domain.Model;
using Moq;
using Xunit;

namespace LibraryManagementSystem.Tests
{
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
        public void Execute_WhenCalled_ShouldCallCreateBook()
        {
            // Arrange
            var bookModel = new BookModel
            {
                Title = "Book Title",
                Author = "Book Author",
                ISBN = "1234567890",
                YearPublication = 2022
            };
            // Act
            _createBookCommand.Execute(bookModel);
            // Assert
            _bookRepositoryMock.Verify(x => x.CreateBook(bookModel), Times.Once);
        }
    }
}
