using FluentValidation;

namespace WebApi.Application.BookOperations.DeleteBook;

public class DeleteBookCommandValidation : AbstractValidator<DeleteBookCommand>
{
    public DeleteBookCommandValidation()
    {
        RuleFor(command=>command.bookId).GreaterThan(0);
    }

}