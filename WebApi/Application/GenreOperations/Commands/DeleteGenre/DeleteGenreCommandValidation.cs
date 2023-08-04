using FluentValidation;

using WebApi.Application.GenreOperations.Commands.DeleteGenre.DeleteGenreCommand;

namespace WebApi.Application.GenreOperations.DeleteGenre;

public class DeleteGenreCommandValidation: AbstractValidator<DeleteGenreCommand>
{
    public DeleteGenreCommandValidation()
    {
        RuleFor(command=> command.GenreId).GreaterThan(0);

    }

}