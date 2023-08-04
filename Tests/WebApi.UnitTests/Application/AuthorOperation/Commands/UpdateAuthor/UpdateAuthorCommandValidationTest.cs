using AutoMapper;
using FluentAssertions;
using Tests.TestSetup;
using WebApi.Application.AuthorOperations.Commands;
using WebApi.DbOperations;

namespace Tests.Application.AuthorOperation.Commands.UpdateAuthor;

public class UpdateAuthorCommandValidationTest : IClassFixture<CommonTestFixture>
{
    private readonly BookStoreDbContext _context;
    private readonly IMapper _mapper;

    public UpdateAuthorCommandValidationTest(CommonTestFixture fixture)
    {
        _context=fixture.Context;
        _mapper=fixture.Mapper;

    }

    public void WhenExistIdEqualsZero_Validator_ShouldBeReturnError()
    {
        UpdateAuthorCommand command= new UpdateAuthorCommand(null,null);
        command.authorId=0;

        UpdateAuthorCommandValidation validator= new UpdateAuthorCommandValidation();
        var result=validator.Validate(command);

        result.Errors.Count.Should().BeGreaterThan(0);
    }
}