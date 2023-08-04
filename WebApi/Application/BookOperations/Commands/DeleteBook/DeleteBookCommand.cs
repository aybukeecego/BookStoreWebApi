
using WebApi.DbOperations;
using Microsoft.AspNetCore.Mvc;
using System;
namespace WebApi.Application.BookOperations.DeleteBook;

public class DeleteBookCommand
{
    private readonly IBookStoreDbContext _context;

    public int bookId {get; set;}

    public DeleteBookCommand(IBookStoreDbContext context)
    {
        _context=context;
    }

    public void Handle()
    {
        var book=_context.Books.SingleOrDefault(x=> x.Id==bookId);

        if(book==null)
        throw new InvalidOperationException("silmek istediğiniz ürüne ait id bulunamadı");

            _context.Books.Remove(book);
            _context.SaveChanges();
    }



}