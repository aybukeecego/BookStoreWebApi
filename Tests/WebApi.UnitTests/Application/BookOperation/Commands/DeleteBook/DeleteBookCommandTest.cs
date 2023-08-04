using AutoMapper;
using FluentAssertions;
using Tests.TestSetup;
using WebApi.Application.BookOperations.CreateBook;
using WebApi.Application.BookOperations.DeleteBook;
using WebApi.DbOperations;
using WebApi.Entities;

namespace Tests.Application.BookOperation.Commands.DeleteBook;

public class DeleteBookCommandTest: IClassFixture<CommonTestFixture>

{
    private readonly BookStoreDbContext _context;
    private readonly IMapper _mapper;

    public DeleteBookCommandTest(CommonTestFixture testFixture)
    {
        _context=testFixture.Context;
        _mapper=testFixture.Mapper;

    }
    [Fact]
    public void WhenNonExistenIdIsGiven_InvalidOperationException_ShouldBeReturn()
    {
        DeleteBookCommand command= new DeleteBookCommand(_context);
        command.bookId=0;

        
        FluentActions
        .Invoking(()=>command.Handle()).Should().Throw<InvalidOperationException>().And.Message.Should().Be("silmek istediğiniz ürüne ait id bulunamadı");

    }
    [Fact]
    public void WhenValidIdIsGiven_Book_ShouldBeDeleted()
    {
        DeleteBookCommand command= new DeleteBookCommand(_context);
        var book= new Book(){Id=2,Title="WhenValidIdIsGiven_Book_ShouldBeDeleted",PageCount=200,GenreId=2};
        command.bookId=book.Id;
        _context.Books.Add(book);
        _context.SaveChanges();

        FluentActions.Invoking(()=>command.Handle()).Invoke();

        var assert= _context.Books.SingleOrDefault(x=>x.Id==command.bookId);
        assert.Should().NotBeNull();

    }
}