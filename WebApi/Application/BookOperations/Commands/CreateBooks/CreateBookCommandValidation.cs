

using FluentValidation;

namespace WebApi.Application.BookOperations.CreateBook;

public class CreateBookCommandValidation : AbstractValidator<CreateBookCommand>
{
   public CreateBookCommandValidation()
   {
    RuleFor(command=>command.Model.GenreId).GreaterThan(0);
    RuleFor(command=>command.Model.PageCount).GreaterThan(0);
    RuleFor(command=>command.Model.Title).NotEmpty().MinimumLength(4);
    RuleFor(command=>command.Model.PublishDate.Date).LessThan(DateTime.Now.Date);

   }

}