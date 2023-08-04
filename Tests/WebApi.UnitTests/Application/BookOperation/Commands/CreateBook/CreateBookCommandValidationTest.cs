
using FluentAssertions;
using Tests.TestSetup;
using WebApi.Application.BookOperations.CreateBook;
using WebApi.DbOperations;
using WebApi.Entities;
using static WebApi.Application.BookOperations.CreateBook.CreateBookCommand;

namespace Tests.Application.BookOperation.Commands;

public class CreateBookCommandValidationTest: IClassFixture<CommonTestFixture>
{
    [Theory]
    [InlineData("Lord",0,0)]
    [InlineData("Lord",200,0)]
    [InlineData("Lord",0,1)]
    [InlineData("",200,0)]
    [InlineData("",200,1)]
    [InlineData(" ",200,0)]
    [InlineData("",0,1)]
    public void WhenInvalidInputsAreGiven_Validator_ShouldBeReturnError(string title, int pageCount, int genreId)
    {
        //arrange

        CreateBookCommand command= new CreateBookCommand(null,null);
        command.Model= new CreateBookModel(){
            
            Title=title,
            PageCount=pageCount,
            GenreId=genreId,


        };

        //act

        CreateBookCommandValidation validator=new CreateBookCommandValidation();
        var result=validator.Validate(command);

        //assert

        result.Errors.Count.Should().BeGreaterThan(0);
    }
    [Fact]
    public void WhenDateTimeEqualsNowIsGiven_Validator_ShouldBeReturnError()

    {
        CreateBookCommand command =new CreateBookCommand(null,null);
        command.Model=new CreateBookModel(){

            Title="Lord of The Rings",
            PageCount=200,
            GenreId=2,
            PublishDate=DateTime.Now.Date


        };

        CreateBookCommandValidation validator= new CreateBookCommandValidation();
        var result=validator.Validate(command);

        result.Errors.Count.Should().BeGreaterThan(0);

    }
    [Fact]
    public void WhenValidInputsAreGiven_Validator_ShouldNotBeReturnError()
    {
        CreateBookCommand command =new CreateBookCommand(null,null);
        command.Model=new CreateBookModel{

            Title="Dune",
            PageCount=300,
            GenreId=2,
            PublishDate=DateTime.Now.Date.AddYears(-2)

        };

        CreateBookCommandValidation validator= new CreateBookCommandValidation();
        var result=validator.Validate(command);

        result.Errors.Count.Should().Be(0);
    }


}