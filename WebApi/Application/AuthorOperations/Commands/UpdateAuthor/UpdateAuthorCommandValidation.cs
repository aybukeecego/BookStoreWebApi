using FluentValidation;
namespace WebApi.Application.AuthorOperations.Commands;


public class UpdateAuthorCommandValidation : AbstractValidator<UpdateAuthorCommand>
{

    public UpdateAuthorCommandValidation()
    {
        RuleFor(command=>command.authorId).GreaterThan(0);
        

    }

}