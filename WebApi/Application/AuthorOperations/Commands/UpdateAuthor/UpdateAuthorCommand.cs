using AutoMapper;
using WebApi.DbOperations;

namespace WebApi.Application.AuthorOperations.Commands;



public class UpdateAuthorCommand
{
    public int authorId { get; set; }

    public UpdateAuthorModel Model { get; set; }

    private readonly IBookStoreDbContext _context;
    private readonly IMapper _mapper;

    public UpdateAuthorCommand(IBookStoreDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public void Handle()
    {
        var author= _context.Authors.SingleOrDefault(x=>x.Id==authorId);
        if(author is null)
        throw new InvalidOperationException ("yazar bulunamadı");

        author.Name = string.IsNullOrEmpty (author.Name.Trim()) ? author.Name : author.Name ;

        _context.SaveChanges();

    }

    public class UpdateAuthorModel
    {
        public string Surname { get; set; }
        public string Name { get; set; }

    }

}