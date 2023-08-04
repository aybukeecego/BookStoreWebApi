using AutoMapper;
using FluentAssertions;
using Tests.TestSetup;
using WebApi.Application.GenreOperations.Commands.DeleteGenre.DeleteGenreCommand;
using WebApi.Application.GenreOperations.DeleteGenre;
using WebApi.DbOperations;
using WebApi.Entities;

namespace Tests.Application.GenreOperations.Commands.DeleteGenre;

public class DeleteGenreCommandValidationTest: IClassFixture<CommonTestFixture>
{
    private readonly BookStoreDbContext _context;

    public DeleteGenreCommandValidationTest(CommonTestFixture fixture)
    {
        _context=fixture.Context;


    }
   [Fact]
    public void WhenExistIdEqualsZero_Validator_ShouldBeReturnError()
    {
        DeleteGenreCommand command= new DeleteGenreCommand(null);
        command.GenreId=0;

        DeleteGenreCommandValidation validator=new DeleteGenreCommandValidation();
        var result=validator.Validate(command);

        result.Errors.Count.Should().BeGreaterThan(0);
       
    }
    [Fact]
    public void WhenValidIdIsGiven_Validator_ShouldNotBeReturnError()
    {
        DeleteGenreCommand command= new DeleteGenreCommand(null);
        command.GenreId=10;

        DeleteGenreCommandValidation validator=new DeleteGenreCommandValidation();
       var result= validator.Validate(command);

       result.Errors.Count.Should().Be(0);



    }
}