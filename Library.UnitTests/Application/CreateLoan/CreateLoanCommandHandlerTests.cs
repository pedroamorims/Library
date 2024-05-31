using Library.Application.Commands.CreateLoan;
using Library.Core.Entities;
using Library.Core.Repositories;
using Moq;
using System;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Library.UnitTests
{
    public class CreateLoanCommandHandlerTests
    {
        [Fact]
        public async Task Handle_BookNotFoundOrInactive_ThrowsInvalidOperationException()
        {
            // Arrange
            var loanRepositoryMock = new Mock<ILoanRepository>();
            var userRepositoryMock = new Mock<IUserRepository>();
            var bookRepositoryMock = new Mock<IBookRepository>();

            bookRepositoryMock.Setup(repo => repo.GetByIdAsync(It.IsAny<int>()))
                .ReturnsAsync((Book)null);

            var handler = new CreateLoanCommandHandler(loanRepositoryMock.Object, userRepositoryMock.Object, bookRepositoryMock.Object);
            var command = new CreateLoanCommand (1, 1, DateTime.Now.AddDays(7), DateTime.Now);

            // Act & Assert
            await Assert.ThrowsAsync<InvalidOperationException>(() => handler.Handle(command, CancellationToken.None));
        }

        [Fact]
        public async Task Handle_UserNotFoundOrInactive_ThrowsInvalidOperationException()
        {
            // Arrange
            var loanRepositoryMock = new Mock<ILoanRepository>();
            var userRepositoryMock = new Mock<IUserRepository>();
            var bookRepositoryMock = new Mock<IBookRepository>();

            var book = new Book("Title","Author","ISBN",2000);
            bookRepositoryMock.Setup(repo => repo.GetByIdAsync(It.IsAny<int>()))
                .ReturnsAsync(book);

            userRepositoryMock.Setup(repo => repo.GetByIdAsync(It.IsAny<int>()))
                .ReturnsAsync((User)null);

            var handler = new CreateLoanCommandHandler(loanRepositoryMock.Object, userRepositoryMock.Object, bookRepositoryMock.Object);
            var command = new CreateLoanCommand(1, 1, DateTime.Now.AddDays(7), DateTime.Now);

            // Act & Assert
            await Assert.ThrowsAsync<InvalidOperationException>(() => handler.Handle(command, CancellationToken.None));
        }

        [Fact]
        public async Task Handle_BookAlreadyLoaned_ThrowsInvalidOperationException()
        {
            // Arrange
            var loanRepositoryMock = new Mock<ILoanRepository>();
            var userRepositoryMock = new Mock<IUserRepository>();
            var bookRepositoryMock = new Mock<IBookRepository>();

            var book = new Book("Title", "Author", "ISBN", 2000);
            var user = new User ("FullName","email","password","admin");
            var activeLoan = new Loan(1,1,DateTime.Now.AddDays(7),DateTime.Now);

            bookRepositoryMock.Setup(repo => repo.GetByIdAsync(It.IsAny<int>()))
                .ReturnsAsync(book);
            userRepositoryMock.Setup(repo => repo.GetByIdAsync(It.IsAny<int>()))
                .ReturnsAsync(user);
            loanRepositoryMock.Setup(repo => repo.GetActiveByBookId(It.IsAny<int>()))
                .ReturnsAsync(activeLoan);

            var handler = new CreateLoanCommandHandler(loanRepositoryMock.Object, userRepositoryMock.Object, bookRepositoryMock.Object);
            var command = new CreateLoanCommand(1, 1, DateTime.Now.AddDays(7), DateTime.Now);

            // Act & Assert
            await Assert.ThrowsAsync<InvalidOperationException>(() => handler.Handle(command, CancellationToken.None));
        }

    }
}
