using AutoMapper;
using FluentAssertions;
using Tests.TestSetup;
using WebApi.Application.AuthorOperations.Queries.GetAuthorDetail;
using WebApi.DbOperations;

namespace Tests.Application.AuthorOperation.Queries.GetAuthorDetail;


public class GetAuthorDetailQueryValidationTest : IClassFixture<CommonTestFixture>
{
    [Fact]
    public void WhenIdEqualsZero_Validator_ShouldBeReturnError()
    {
        GetAuthorDetailQuery query =new GetAuthorDetailQuery(null,null);
        query.authorId=0;

        GetAuthorDetailValidation validator= new GetAuthorDetailValidation();
        var result= validator.Validate(query);

        result.Errors.Count.Should().BeGreaterThan(0);

    }
}