using Tests.TestSetup;
using WebApi.Application.BookOperations.UpdateBook;
using WebApi.DbOperations;
using FluentAssertions;
using static WebApi.Application.BookOperations.UpdateBook.UpdateBookCommand;

namespace Tests.Application.BookOperation.Commands.UpdateBook;

public class UpdateBookCommandTest : IClassFixture<CommonTestFixture>
{
    private readonly IBookStoreDbContext _context;

    public UpdateBookCommandTest(CommonTestFixture fixture)
    {
        _context = fixture.Context;
    }
    [Fact]
    public void  WhenNonExistenIdIsGivenForUpdate_InvalidOperationException_ShouldBeReturnError()
    {
        UpdateBookCommand command= new UpdateBookCommand(_context);
        command.bookId=0;

        FluentActions
        .Invoking(()=>command.Handle()).Should().Throw<InvalidOperationException>().And.Message.Should().Be("Güncellenecek ürün bulunamamıştır");

    }
}