using FluentValidation;
using WebApi.DbOperations;

namespace WebApi.Application.BookOperations.UpdateBook;

public class UpdateBookCommandValidation : AbstractValidator<UpdateBookCommand>
{
    public UpdateBookCommandValidation()
    {
        RuleFor(command=> command.bookId).NotEmpty().GreaterThan(0);
        RuleFor(command=> command.Model.GenreId).NotEmpty().GreaterThan(0);
        RuleFor(command=>command.Model.Title).NotEmpty().MinimumLength(4);
        RuleFor(command=>command.Model.PageCount).NotEmpty().GreaterThan(0);
    }

    
}