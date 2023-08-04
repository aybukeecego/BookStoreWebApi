using FluentValidation;


namespace WebApi.Application.AuthorOperations.Commands.DeleteAuthor;


public class DeleteAuthorCommandValidation : AbstractValidator<DeleteAuthorCommand>
{
    public DeleteAuthorCommandValidation()
    {
        RuleFor(command=>command.authorId).GreaterThan(0);
        

    }

}