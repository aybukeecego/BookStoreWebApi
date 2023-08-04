using AutoMapper;
using WebApi.DbOperations;
using WebApi.Entities;

namespace WebApi.Application.AuthorOperations.Queries.GetAuthors;



public class GetAuthorQuery
{
    private readonly IBookStoreDbContext _context;
    private readonly IMapper _mapper;

    public GetAuthorQuery(IMapper mapper, IBookStoreDbContext context)
    {
        _mapper=mapper;
        _context=context;
    }

    public List<AuthorModel> Handle()
    {
        var authors= _context.Authors.OrderBy(x=>x.Id);
        List<AuthorModel> authorList= _mapper.Map<List<AuthorModel>>(authors);
        return authorList;

    }

    public class AuthorModel
    {
        public int Id  { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }

        public DateTime Birthday { get; set; }

    }
}