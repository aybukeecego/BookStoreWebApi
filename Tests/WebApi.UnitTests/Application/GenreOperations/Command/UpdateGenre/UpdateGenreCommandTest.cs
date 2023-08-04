using AutoMapper;
using FluentAssertions;
using Tests.TestSetup;
using WebApi.Application.GenreOperations.Commands.UpdateGenre.UpdateGenreCommand;
using WebApi.DbOperations;
using WebApi.Entities;

namespace Tests.Application.GenreOperations.Commands.UpdateGenre;

public class UpdateGenreCommandTest: IClassFixture<CommonTestFixture>
{
    private readonly BookStoreDbContext _context;

    public UpdateGenreCommandTest(CommonTestFixture fixture)
    {
        _context=fixture.Context;

    }

    [Fact]
    public void  WhenNonExistenIdIsGivenForUpdate_InvalidOperationException_ShouldBeReturnError()
    {
        UpdateGenreCommand command= new UpdateGenreCommand(_context);
        command.GenreId=0;

        FluentActions
        .Invoking(()=>command.Handle()).Should().Throw<InvalidOperationException>().And.Message.Should().Be("Aradığınız tür mevcut değil");

    }
    [Fact]

    public void WhenExistenNameIsGiven_InvalidOperationException_ShouldBeReturnError()
    {
        var genre = new Genre(){Name="WhenExistenNameIsGiven_InvalidOperationException_ShouldBeReturnError",Id=10};
        _context.Genres.Add(genre);
        _context.SaveChanges();

        UpdateGenreCommand command= new UpdateGenreCommand(null);
        command.Model=new UpdateGenreModel(){
            Name="WhenExistenNameIsGiven_InvalidOperationException_ShouldBeReturnError"
        };
        command.GenreId=genre.Id;

        FluentActions.Invoking(()=>command.Handle()).Should().Throw<InvalidOperationException>().And.Message.Should().Be("Aradığınız tür zaten mevcut");
    }
}