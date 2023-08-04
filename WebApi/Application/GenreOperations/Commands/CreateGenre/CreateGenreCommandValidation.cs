using FluentValidation;
using WebApi.Application.GenreOperations.CreateGenre.CreateGenreCommand;

namespace WebApi.Application.GenreOperations.Commands.CreateGenreCommandValidation;

public class CreateGenreCommandValidation : AbstractValidator<CreateGenreCommand>
{
    public CreateGenreCommandValidation()
    {
        RuleFor(command=>command.Model.Name).NotEmpty().MinimumLength(4);

    }

}