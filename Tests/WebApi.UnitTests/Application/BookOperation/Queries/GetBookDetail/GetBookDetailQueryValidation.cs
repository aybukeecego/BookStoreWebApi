using AutoMapper;
using FluentAssertions;
using Tests.TestSetup;
using WebApi.Application.BookOperations.GetBookDetail;
using WebApi.DbOperations;

namespace Tests.Application.GenreOperation.Queries.GetBookDetail;


public class GetBookDetailQueryValidationTest : IClassFixture<CommonTestFixture>
{
    [Fact]
    public void WhenIdEqualsZero_Validator_ShouldBeReturnError()
    {
        GetBookDetailQuery query =new GetBookDetailQuery(null,null);
        query.bookId=0;

        GetBookDetailQueryValidation validator= new GetBookDetailQueryValidation();
        var result= validator.Validate(query);

        result.Errors.Count.Should().BeGreaterThan(0);

    }
}