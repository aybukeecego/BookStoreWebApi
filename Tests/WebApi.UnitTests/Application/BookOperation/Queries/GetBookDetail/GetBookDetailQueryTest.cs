using AutoMapper;
using FluentAssertions;
using Tests.TestSetup;
using WebApi.Application.BookOperations.GetBookDetail;
using WebApi.DbOperations;

namespace Tests.Application.BookOperation.Queries;


public class GetBookDetailQueryTest : IClassFixture<CommonTestFixture>
{

    private readonly BookStoreDbContext _context;
    private readonly IMapper _mapper;

    public GetBookDetailQueryTest(CommonTestFixture fixture)
    {
        _context=fixture.Context;
        _mapper=fixture.Mapper;

    }
    [Fact]
    public void WhenInvalidIdIsGiven_InvalidOperationException_ShouldBeReturnError()
    {
        GetBookDetailQuery query= new GetBookDetailQuery(_context,_mapper);
        var book = _context.Books.Where(book=> book.Id==query.bookId).SingleOrDefault();
        book=null;

        FluentActions.Invoking(()=>query.Handle()).Should().Throw<InvalidOperationException>().And.Message.Should().Be("Bu id'ye ait ürün bulunamadı");
    }
   
    
}