using AutoMapper;
using FluentAssertions;
using Tests.TestSetup;
using WebApi.Application.GenreOperations.GetGenreDetailQueryValidation;
using WebApi.Application.GenreOperations.Queries.GetGenreDetailQuery;
using WebApi.DbOperations;

namespace Tests.Application.GenreOperation.Queries.GetGenreDetail;


public class GetGenreDetailQueryValidationTest : IClassFixture<CommonTestFixture>
{
    private readonly BookStoreDbContext _context;
    private readonly IMapper _mapper;

    public GetGenreDetailQueryValidationTest(CommonTestFixture fixture)
    {
        _context=fixture.Context;
        _mapper=fixture.Mapper;

    }

    [Fact]
    public void WhenIdEqualsZero_Validator_ShouldBeReturnError()
    {
        GetGenreDetailQuery query =new GetGenreDetailQuery(null,null);
        query.genreId=0;

        GetGenreDetailQueryValidation validator= new GetGenreDetailQueryValidation();
        var result= validator.Validate(query);

        result.Errors.Count.Should().BeGreaterThan(0);

    }
}
