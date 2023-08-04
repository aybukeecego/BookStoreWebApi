using AutoMapper;
using FluentAssertions;
using Tests.TestSetup;
using WebApi.Application.AuthorOperations.Commands.CreateAuthor;
using WebApi.Application.BookOperations.CreateBook;
using WebApi.DbOperations;
using WebApi.Entities;
using static WebApi.Application.BookOperations.CreateBook.CreateAuthorCommand;

namespace Tests.Application.AuthorOperation.Commands.CreateAuthor;

public class CreateAuthorCommandTest: IClassFixture<CommonTestFixture>
{
    private readonly IMapper _mapper;
    private readonly BookStoreDbContext _context;

    public CreateAuthorCommandTest(CommonTestFixture fixture)
    {
        _context=fixture.Context;
        _mapper=fixture.Mapper;

    }

    public void WhenAlreadyExistAuthorIsGiven_InvalidOperationException_ShouldBeReturnError()
    {
        var author=new Author{
            Name="Name",
            Surname="Surname"
            
        };
        _context.Authors.Add(author);
        _context.SaveChanges();

        CreateAuthorCommand command= new CreateAuthorCommand(null,null);
        command.Model.Name=author.Name;
        command.Model.Surname=author.Surname;

        FluentActions.Invoking(()=>command.Handle()).Should().Throw<InvalidOperationException>().And.Message.Should().Be("Yazar zaten mevcut");
    }


}