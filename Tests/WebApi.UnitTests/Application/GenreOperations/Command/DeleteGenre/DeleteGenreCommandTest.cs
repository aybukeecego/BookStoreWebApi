using AutoMapper;
using FluentAssertions;
using Tests.TestSetup;
using WebApi.Application.GenreOperations.Commands.DeleteGenre.DeleteGenreCommand;
using WebApi.DbOperations;
using WebApi.Entities;

namespace Tests.Application.GenreOperations.Commands.DeleteGenre;

public class DeleteGenreCommandTest: IClassFixture<CommonTestFixture>
{
    private readonly IBookStoreDbContext _context;
    private readonly IMapper _mapper;

    public DeleteGenreCommandTest(CommonTestFixture fixture)
    {
        _context=fixture.Context;
        _mapper=fixture.Mapper;
        
    }

    [Fact]
    public void WhenNonExistenIdIsGiven_InvalidOperationException_ShouldBeReturn()
    {
        DeleteGenreCommand command= new DeleteGenreCommand(_context);
        command.GenreId=0;

        
        FluentActions
        .Invoking(()=>command.Handle()).Should().Throw<InvalidOperationException>().And.Message.Should().Be("Silmek istediğiniz ürün bulunamadı");

    }
        [Fact]
    public void WhenValidIdIsGiven_Book_ShouldBeDeleted()
    {
        DeleteGenreCommand command= new DeleteGenreCommand(_context);
        var genre= new Genre(){Id=2,Name="WhenValidIdIsGiven_Book_ShouldBeDeleted"};
        command.GenreId=genre.Id;
        _context.Genres.Add(genre);
        _context.SaveChanges();

        FluentActions.Invoking(()=>command.Handle()).Invoke();

        var assert= _context.Genres.SingleOrDefault(x=>x.Id==command.GenreId);
        assert.Should().NotBeNull();

    }
}