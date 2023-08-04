using AutoMapper;
using FluentAssertions;
using Tests.TestSetup;
using WebApi.Application.GenreOperations.Commands.CreateGenreCommandValidation;
using WebApi.Application.GenreOperations.CreateGenre.CreateGenreCommand;
using WebApi.DbOperations;
using WebApi.Entities;

namespace Tests.Application.GenreOperations.Commands.CreateGenre;

public class CreateGenreCommandValidationTest: IClassFixture<CommonTestFixture>
{
    private readonly IBookStoreDbContext _context;
    private readonly IMapper _mapper;

    public CreateGenreCommandValidationTest(CommonTestFixture fixture)
    {
        _mapper=fixture.Mapper;
        _context=fixture.Context;
    }
    
    [Theory]
    [InlineData("Lı")]
    [InlineData("")]
    public void WhenInvalidNameIsGiven_Validator_ShouldBeReturnError(string name)
    {
        CreateGenreCommand command= new CreateGenreCommand(null);

        command.Model=new CreateGenreModel(){
            Name= name
        };

        CreateGenreCommandValidation validator= new CreateGenreCommandValidation();
        var result=validator.Validate(command);
        
        result.Errors.Count.Should().BeGreaterThan(0);

    }
     [Fact]
    public void WhenValidNameIsGiven_Validator_ShouldNotBeReturnError()
    {
        CreateGenreCommand command= new CreateGenreCommand(null);
        command.Model=new CreateGenreModel(){
            Name="WhenValidNameIsGiven_Validator_ShouldNotBeReturnError"
        };

        CreateGenreCommandValidation validator= new CreateGenreCommandValidation();
        var result=validator.Validate(command);

        result.Errors.Count.Should().Be(0);

    }

}