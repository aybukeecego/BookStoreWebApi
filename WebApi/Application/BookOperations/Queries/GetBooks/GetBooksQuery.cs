
using WebApi.DbOperations;
using Microsoft.AspNetCore.Mvc;
using System;
using AutoMapper;
using System.Linq;
using WebApi.Entities;
using Microsoft.EntityFrameworkCore;

namespace WebApi.Application.BookOperations.GetBooks;

public class GetBooksQuery
{
    private readonly IBookStoreDbContext _dbcontext;
    private readonly IMapper _mapper;
    public GetBooksQuery(IBookStoreDbContext dbcontext,IMapper mapper)
    {
        _mapper=mapper;
        _dbcontext = dbcontext;
    }


    public List<BooksViewModel> Handle()
    {
        var bookList=_dbcontext.Books.Include(x=>x.Genre).OrderBy(x=>x.Id).ToList<Book>();

        List<BooksViewModel> vm=_mapper.Map<List<BooksViewModel>>(bookList);

        return vm;

    }

    public class BooksViewModel
    {
        public string Title { get; set; }
        public int PageCount { get; set; }

        public string Genre { get; set; }

        public string PublishDate { get; set; }
    }
}