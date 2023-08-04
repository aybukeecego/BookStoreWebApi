using FluentAssertions;
using Tests.TestSetup;
using WebApi.Application.BookOperations.CreateBook;
using WebApi.Application.BookOperations.DeleteBook;
using WebApi.DbOperations;
using WebApi.Entities;

namespace Tests.Application.BookOperation.Commands;

public class DeleteBookCommandValidationTest: IClassFixture<CommonTestFixture>
{
   [Fact]
    public void WhenExistIdEqualsZero_Validator_ShouldBeReturnError()
    {
        DeleteBookCommand command= new DeleteBookCommand(null);
        command.bookId=0;

        DeleteBookCommandValidation validator=new DeleteBookCommandValidation();
        var result=validator.Validate(command);

        result.Errors.Count.Should().BeGreaterThan(0);
       
    }
    [Fact]
    public void WhenValidIdIsGiven_Validator_ShouldNotBeReturnError()
    {
        DeleteBookCommand command= new DeleteBookCommand(null);
        command.bookId=10;

        DeleteBookCommandValidation validator=new DeleteBookCommandValidation();
       var result= validator.Validate(command);

       result.Errors.Count.Should().Be(0);



    }

}