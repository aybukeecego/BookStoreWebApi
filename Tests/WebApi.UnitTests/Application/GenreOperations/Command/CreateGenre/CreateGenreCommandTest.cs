using AutoMapper;
using FluentAssertions;
using Tests.TestSetup;
using WebApi.Application.GenreOperations.CreateGenre.CreateGenreCommand;
using WebApi.DbOperations;
using WebApi.Entities;

namespace Tests.Application.GenreOperations.Commands.CreateGenre;

public class CreateGenreCommandTest: IClassFixture<CommonTestFixture>
{
    private readonly IBookStoreDbContext _context;
    private readonly IMapper _mapper;

    public CreateGenreCommandTest(CommonTestFixture fixture)
    {
        _context=fixture.Context;
        _mapper=fixture.Mapper;
        
    }

     [Fact]
    public void WhenAlreadyExistGenreIsGiven_InvalidOperationException_ShouldBeReturnError()
    {
        var genre= new Genre(){Name="WhenAlreadyExistGenreIsGiven_InvalidOperationException_ShouldBeReturnError"};
        _context.Genres.Add(genre);
        _context.SaveChanges();

        CreateGenreCommand command= new CreateGenreCommand(_context);

        command.Model= new CreateGenreModel(){Name=genre.Name};

        FluentActions.Invoking(()=>command.Handle()).Should().Throw<InvalidOperationException>().And.Message.Should().Be("Kitap zaten mevcut");

    }
}