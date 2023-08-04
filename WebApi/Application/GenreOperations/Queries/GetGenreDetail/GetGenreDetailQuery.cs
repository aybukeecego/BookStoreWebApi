using AutoMapper;
using WebApi.DbOperations;

namespace WebApi.Application.GenreOperations.Queries.GetGenreDetailQuery;

public class GetGenreDetailQuery
{
    public int genreId;
    private readonly IBookStoreDbContext _dbcontext;
    private readonly IMapper _mapper;

    public GetGenreDetailQuery(IBookStoreDbContext dbcontext,IMapper mapper)
    {
        _dbcontext=dbcontext;
        _mapper=mapper;

    }

    public GenreDetailViewModel Handle()
    {
        var genre= _dbcontext.Genres.SingleOrDefault(x=> x.IsActive && x.Id==genreId);

        if(genre==null)
        throw new InvalidOperationException("Bu id'ye ait kategori bulunamadı");
        return  _mapper.Map<GenreDetailViewModel>(genre);


    }



}
public class GenreDetailViewModel
{
    public int Id { get; set; }
    public string Name { get; set; }

}