using AutoMapper;
using FluentAssertions;
using Tests.TestSetup;
using WebApi.Application.AuthorOperations.Commands.CreateAuthor;
using WebApi.Application.BookOperations.CreateBook;
using WebApi.DbOperations;
using WebApi.Entities;
using static WebApi.Application.BookOperations.CreateBook.CreateAuthorCommand;

namespace Tests.Application.AuthorOperations.Commands.CreateAuthor;

public class CreateAuthorCommandValidationTest: IClassFixture<CommonTestFixture>
{
    private readonly IBookStoreDbContext _context;
    private readonly IMapper _mapper;

    public CreateAuthorCommandValidationTest(CommonTestFixture fixture)
    {
        _mapper=fixture.Mapper;
        _context=fixture.Context;
    }
    [Theory]
    [InlineData("","")]
    [InlineData(" "," ")]
    public void WhenInvalidNameIsGiven_Validator_ShouldBeReturnError( string name, string surname)
    {
        CreateAuthorCommand command= new CreateAuthorCommand(null,null);

        command.Model=new CreateAuthorModel(){
            Name= name,
            Surname=surname
            
        };

        CreateAuthorCommandValidation validator= new CreateAuthorCommandValidation();
        var result=validator.Validate(command);
        
        result.Errors.Count.Should().BeGreaterThan(0);

    }
     [Fact]
    public void WhenValidAuthorIsGiven_Validator_ShouldNotBeReturnError()
    {
        CreateAuthorCommand command= new CreateAuthorCommand(null,null);
        command.Model=new CreateAuthorModel(){
            Name="Name",
            Surname="Surname"
            
        };

        CreateAuthorCommandValidation validator= new CreateAuthorCommandValidation();
        var result=validator.Validate(command);

        result.Errors.Count.Should().Be(0);

    }

    [Fact]

    public void WhenBirthDayTimeIsEqualsNow_Validator_ShouldBeReturnError()
    {
        CreateAuthorCommand command= new CreateAuthorCommand(null,null);
        command.Model=new CreateAuthorModel{
            Name="Sinan",
            Surname="Canan",
            Birthday=DateTime.Now.Date
        };
        CreateAuthorCommandValidation validator= new CreateAuthorCommandValidation();
        var result=validator.Validate(command);

        result.Errors.Count.Should().BeGreaterThan(0);


    }

}