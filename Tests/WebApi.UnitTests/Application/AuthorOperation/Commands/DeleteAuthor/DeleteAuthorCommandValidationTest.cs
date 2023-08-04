using AutoMapper;
using FluentAssertions;
using Tests.TestSetup;
using WebApi.Application.AuthorOperations.Commands;
using WebApi.Application.AuthorOperations.Commands.DeleteAuthor;
using WebApi.DbOperations;
using WebApi.Entities;

namespace Tests.Application.AuthorOperations.Commands.DeleteAuthor;

public class DeleteAuthorCommandValidationTest: IClassFixture<CommonTestFixture>
{
    private readonly BookStoreDbContext _context;

    public DeleteAuthorCommandValidationTest(CommonTestFixture fixture)
    {
        _context=fixture.Context;

    }

    [Fact]
    public void WhenExistIdEqualsZero_Validator_ShouldBeReturnError()
    {
        DeleteAuthorCommand command= new DeleteAuthorCommand(null,null);
        command.authorId=0;

        DeleteAuthorCommandValidation validator=new DeleteAuthorCommandValidation();
        var result=validator.Validate(command);

        result.Errors.Count.Should().BeGreaterThan(0);
       
    }
    [Fact]
    public void WhenValidIdIsGiven_Validator_ShouldNotBeReturnError()
    {
        DeleteAuthorCommand command= new DeleteAuthorCommand(null,null);
        command.authorId=10;

        DeleteAuthorCommandValidation validator=new DeleteAuthorCommandValidation();
       var result= validator.Validate(command);

       result.Errors.Count.Should().Be(0);



    }

}