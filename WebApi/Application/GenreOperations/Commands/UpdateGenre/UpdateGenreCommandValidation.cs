using FluentValidation;
using WebApi.Application.GenreOperations.Commands.UpdateGenre.UpdateGenreCommand;

namespace WebApi.Application.GenreOperations.Commands.UpdateGenre.UpdateGenreCommand;

public class UpdateGenreCommandValidation: AbstractValidator<UpdateGenreCommand>
{
    public UpdateGenreCommandValidation()
    {
        RuleFor(command=> command.Model.Name).MinimumLength(4).When(x=> x.Model.Name.Trim() != string.Empty);

    }

}