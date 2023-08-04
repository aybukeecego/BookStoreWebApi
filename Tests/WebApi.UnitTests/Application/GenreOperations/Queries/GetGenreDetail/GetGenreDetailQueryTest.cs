using AutoMapper;
using FluentAssertions;
using Tests.TestSetup;
using WebApi.Application.GenreOperations.Queries.GetGenreDetailQuery;
using WebApi.DbOperations;

namespace Tests.Application.BookOperation.Queries.GetBookDetail;


public class GetGenreDetailQueryTest : IClassFixture<CommonTestFixture>
{

    private readonly BookStoreDbContext _context;
    private readonly IMapper _mapper;

    public GetGenreDetailQueryTest(CommonTestFixture fixture)
    {
        _context=fixture.Context;
        _mapper=fixture.Mapper;

    }
     [Fact]
    public void WhenInvalidIdIsGiven_InvalidOperationException_ShouldBeReturnError()
    {
        GetGenreDetailQuery query= new GetGenreDetailQuery(_context,_mapper);
        var genre = _context.Genres.Where(genre=> genre.Id==query.genreId).SingleOrDefault();
        genre=null;

        FluentActions.Invoking(()=>query.Handle()).Should().Throw<InvalidOperationException>().And.Message.Should().Be("Bu id'ye ait kategori bulunamadı");
    }
}