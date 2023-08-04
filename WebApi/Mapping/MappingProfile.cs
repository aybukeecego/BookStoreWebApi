using AutoMapper;
using WebApi.Application.GenreOperations.CreateGenre.CreateGenreCommand;
using WebApi.Application.GenreOperations.GetGenres;
using WebApi.Application.GenreOperations.Queries.GetGenreDetailQuery;
using WebApi.Entities;
using static WebApi.Application.AuthorOperations.Queries.GetAuthorDetail.GetAuthorDetailQuery;
using static WebApi.Application.AuthorOperations.Queries.GetAuthors.GetAuthorQuery;
using static WebApi.Application.BookOperations.CreateBook.CreateAuthorCommand;
using static WebApi.Application.BookOperations.CreateBook.CreateBookCommand;
using static WebApi.Application.BookOperations.GetBookDetail.GetBookDetailQuery;
using static WebApi.Application.BookOperations.GetBooks.GetBooksQuery;
using static WebApi.Application.UserOperations.CreateUser.CreateUserCommand;

namespace WebApi.Mapping;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<CreateBookModel,Book>();
        CreateMap<Book,GetBookDetailViewModel>().ForMember(dest=>dest.Genre,opt=> opt.MapFrom(src=>src.Genre.Name));
        CreateMap<Book,BooksViewModel>().ForMember(dest=>dest.Genre,opt=> opt.MapFrom(src=>src.Genre.Name));
        CreateMap<Genre,GenreDetailViewModel>();
        CreateMap<Genre,GenresModel>();
        CreateMap<Genre,CreateGenreModel>();
        CreateMap<Author,CreateAuthorModel>().ReverseMap();
        CreateMap<Author,AuthorModel>().ReverseMap();
        CreateMap<Author,GetAuthorDetailModel>();
        CreateMap<User,CreateUserModel>();

    }

}