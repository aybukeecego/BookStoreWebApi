using FluentValidation;
using WebApi.Application.AuthorOperations.Commands.CreateAuthor;
using WebApi.Application.BookOperations.CreateBook;

namespace WebApi.Application.AuthorOperations.Commands.CreateAuthor;


public class CreateAuthorCommandValidation : AbstractValidator<CreateAuthorCommand>
{
    public CreateAuthorCommandValidation()
    {
        RuleFor(command=>command.Model.Name).NotEmpty();
        RuleFor(command=>command.Model.Surname).NotEmpty();
        RuleFor(command=>command.Model.Birthday).NotEmpty().LessThan(DateTime.Now.Date);


    }
}