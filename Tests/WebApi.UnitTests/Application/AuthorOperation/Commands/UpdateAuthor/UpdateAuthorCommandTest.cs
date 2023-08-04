using AutoMapper;
using FluentAssertions;
using Tests.TestSetup;
using WebApi.Application.AuthorOperations.Commands;
using WebApi.DbOperations;
using WebApi.Entities;

namespace Tests.Application.AuthorOperations.Commands.UpdateAuthor;

public class UpdateAuthorCommandTest: IClassFixture<CommonTestFixture>
{
    private readonly BookStoreDbContext _context;

    public UpdateAuthorCommandTest(CommonTestFixture fixture)
    {
        _context=fixture.Context;

    }

    [Fact]
    public void  WhenNonExistenIdIsGivenForUpdate_InvalidOperationException_ShouldBeReturnError()
    {
        UpdateAuthorCommand command= new UpdateAuthorCommand(null,null);
        command.authorId=0;

        FluentActions
        .Invoking(()=>command.Handle()).Should().Throw<InvalidOperationException>().And.Message.Should().Be("yazar bulunamadı");

    }
}