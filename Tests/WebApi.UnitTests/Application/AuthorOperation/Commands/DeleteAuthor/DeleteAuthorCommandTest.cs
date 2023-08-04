using AutoMapper;
using FluentAssertions;
using Tests.TestSetup;
using WebApi.Application.AuthorOperations.Commands;
using WebApi.Application.AuthorOperations.Commands.DeleteAuthor;
using WebApi.DbOperations;
using WebApi.Entities;

namespace Tests.Application.AuthorOperation.Commands.DeleteAuthor;

public class DeleteAuthorCommandTest: IClassFixture<CommonTestFixture>

{
    private readonly BookStoreDbContext _context;

    public DeleteAuthorCommandTest(CommonTestFixture fixture)
    {
        _context=fixture.Context;

    }

     [Fact]
    public void WhenNonExistenIdIsGiven_InvalidOperationException_ShouldBeReturn()
    {
        DeleteAuthorCommand command= new DeleteAuthorCommand(null,null);
        command.authorId=0;

        
        FluentActions
        .Invoking(()=>command.Handle()).Should().Throw<InvalidOperationException>().And.Message.Should().Be("Yazar mevcut değil");

    }
    [Fact]
    public void WhenAuthorHasExistenBook_InvalidOperationException_ShouldBeReturn()
    {
        var authorBook= new Book{Title="Dune", PageCount=200,PublishDate=DateTime.Now.AddYears(-10),AuthorId=10};
        _context.Books.Add(authorBook);
        _context.SaveChanges();

        DeleteAuthorCommand command = new DeleteAuthorCommand(null,null);
        command.authorId=authorBook.AuthorId;

        FluentActions.Invoking(()=>command.Handle()).Should().Throw<InvalidOperationException>().And.Message.Should().Be("Bu yazarın yayında kitabı bulunmaktadır. Öncelikle kitabı siliniz.");

    }

    [Fact]
    public void WhenValidIdIsGiven_Author_ShouldBeDeleted()
    {
        DeleteAuthorCommand command= new DeleteAuthorCommand(null,null);
        var author= new Author(){Id=11,Name="Sinan",Surname="Canan",Birthday=DateTime.Now.AddYears(-10)};
        command.authorId=author.Id;
        _context.Authors.Add(author);
        _context.SaveChanges();

        FluentActions.Invoking(()=>command.Handle()).Invoke();

        var assert= _context.Authors.SingleOrDefault(x=>x.Id==command.authorId);
        assert.Should().NotBeNull();

    }
}