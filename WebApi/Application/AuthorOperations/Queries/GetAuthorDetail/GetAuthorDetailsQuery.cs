using AutoMapper;
using WebApi.DbOperations;

namespace WebApi.Application.AuthorOperations.Queries.GetAuthorDetail;


public class GetAuthorDetailQuery
{
    public int authorId;
    private readonly IMapper _mapper;
    private readonly IBookStoreDbContext _context;

    public GetAuthorDetailQuery(IMapper mapper, IBookStoreDbContext context)
    {
        _mapper = mapper;
        _context = context;
    }

    public GetAuthorDetailModel Handle()
    {
        var author=_context.Authors.SingleOrDefault(x=>x.Id==authorId);

        if(author is null)
        throw new InvalidOperationException("Yazar bulunamadı");
        return _mapper.Map<GetAuthorDetailModel>(author);

    }

     

    public class GetAuthorDetailModel
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime Birthday { get; set; }
    }


}