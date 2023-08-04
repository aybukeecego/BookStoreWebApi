using FluentValidation;
using WebApi.Application.GenreOperations.Queries.GetGenreDetailQuery;

namespace WebApi.Application.GenreOperations.GetGenreDetailQueryValidation;

public class GetGenreDetailQueryValidation: AbstractValidator<GetGenreDetailQuery>
{
    public GetGenreDetailQueryValidation()
    {
        RuleFor(query=> query.genreId).GreaterThan(0);

    }

}