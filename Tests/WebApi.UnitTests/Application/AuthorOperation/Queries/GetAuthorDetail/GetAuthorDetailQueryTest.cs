using AutoMapper;
using FluentAssertions;
using Tests.TestSetup;
using WebApi.Application.AuthorOperations.Queries.GetAuthorDetail;
using WebApi.DbOperations;

namespace Tests.Application.AuthorOperation.Queries.GetAuthorDetail;


public class GetAuthorDetailQueryTest: IClassFixture<CommonTestFixture>
{

    private readonly IBookStoreDbContext _context;
    private readonly IMapper _mapper;

    public GetAuthorDetailQueryTest(CommonTestFixture fixture)
    {
        _context=fixture.Context;
        _mapper=fixture.Mapper;

    }
     [Fact]
    public void WhenInvalidIdIsGiven_InvalidOperationException_ShouldBeReturnError()
    {
        GetAuthorDetailQuery query= new GetAuthorDetailQuery(_mapper,_context);
        var author = _context.Authors.Where(author=> author.Id==query.authorId).SingleOrDefault();
        author=null;

        FluentActions.Invoking(()=>query.Handle()).Should().Throw<InvalidOperationException>().And.Message.Should().Be("Yazar bulunamadı");
    }
}