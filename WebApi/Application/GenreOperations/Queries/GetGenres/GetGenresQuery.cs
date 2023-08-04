using AutoMapper;
using WebApi.DbOperations;

namespace WebApi.Application.GenreOperations.GetGenres;

public class GetGenresQuery
{
    private readonly IBookStoreDbContext _dbcontext;
    private readonly IMapper _mapper;

    public GetGenresQuery(IBookStoreDbContext dbcontext,IMapper mapper)
    {
        _dbcontext=dbcontext;
        _mapper=mapper;

    }

    public List<GenresModel> Handle()
    {
        var genres= _dbcontext.Genres.Where(x=>x.IsActive).OrderBy(x=>x.Id);
        List<GenresModel> returnObj= _mapper.Map<List<GenresModel>>(genres);
        return returnObj;

    }



}
public class GenresModel
{
    public int Id { get; set; }
    public string Name { get; set; }

}