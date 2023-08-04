using FluentValidation;

namespace WebApi.Application.AuthorOperations.Queries.GetAuthorDetail;


public class GetAuthorDetailValidation : AbstractValidator<GetAuthorDetailQuery>
{
    public GetAuthorDetailValidation()
    {
        RuleFor(query=>query.authorId).GreaterThan(0);

    }


}