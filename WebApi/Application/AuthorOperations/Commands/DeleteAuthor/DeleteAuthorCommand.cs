using AutoMapper;
using WebApi.DbOperations;

namespace WebApi.Application.AuthorOperations.Commands;


public class DeleteAuthorCommand
{
    public int authorId { get; set; }
    private readonly IBookStoreDbContext _context;

    private readonly IMapper _mapper;

    public DeleteAuthorCommand(IMapper mapper,IBookStoreDbContext context)
    {
        _context=context;
        _mapper=mapper;

    }


    public void Handle()
    {
        var author=_context.Authors.SingleOrDefault(x=>x.Id==authorId);

        var authorBook=_context.Books.SingleOrDefault(x=>x.AuthorId==authorId);

        if(author is null)
        throw new InvalidOperationException ("Yazar mevcut değil");

        if(authorBook is not null)
        throw new InvalidOperationException("Bu yazarın yayında kitabı bulunmaktadır. Öncelikle kitabı siliniz.");

        _context.Authors.Remove(author);
        _context.SaveChanges();

    }
}